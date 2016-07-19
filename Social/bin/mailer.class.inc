<?php
require_once("config.class.inc");
require_once("swift/swift_required.php");
require_once("user.class.inc");
require_once("post.class.inc");

abstract class mailer {

	static function queue($beholder, $parameter, $author = null, $object = null) {
		$cmd = sprintf("INSERT INTO CronJobs (AuthorID, AuthorType, BeholderID, BeholderType, ObjectID, ObjectType, JobType, JobParameter, CreatedAt) VALUES " .
					"('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')", 	$author == null ? 0 : $author->id,
																				$author == null ? "None" : $author->type,
																				$beholder->id,
																				$beholder->type,
																				$object == null ? 0 : $object->id,
																				$object == null ? "None" : $object->type,
																				"Email",
																				$parameter,
																				utility::now());
																				
		db::query($cmd);
	}
	
	static function send($user, $parameter, $actor = null, $object = null) {			
		$from = array(config::smtp_from => "Kıbrıs Network");
		$to = array($user->email => $user->name . " " . $user->surname);
		
		$subject = "Merhaba";
		$text = "Umarız bu site hoşunuza gider.";
		$html = "<html><body stlye='font-family: tahoma; font-size: 11px; text-align: left'>";
		$crlf = "\n";
		
		switch($parameter) {
			case "Welcome":
				$subject = "Hoşgeldiniz.";
				$text = "Aramıza hoşgeldiniz. Bir an önce sitemizin tüm özelliklerinden yararlanabilmek için profilinizi güncelleyin ve arkadaşlarınızı bulmaya başlayın.";
				$html = "Aramıza hoşgeldiniz. Bir an önce sitemizin tüm özelliklerinden yararlanabilmek için <br />
				profilinizi güncelleyin ve arkadaşlarınızı bulmaya başlayın.";
				
				break;
				
			case "Post":
				$subject = sprintf("%s - Bildirim", $user->name . " " . $user->surname);
				$text = sprintf("Merhaba %s, %s adlı kullanıcı duvarınızda bir ", $user->name, $actor->name ." ". $actor->surname);
				$html = sprintf("Merhaba %s, <br /><br /><br />%s adlı kullanıcı duvarınızda bir ", $user->name, $actor->name ." ". $actor->surname);
				
				if (get_class($object) == "post") {
					if ($object->posttype == "Status") {
						$text .= sprintf("gönderi paylaştı. \n\n \"%s\"", $object->value);
						$html .= sprintf("gönderi paylaştı. <br /><br /> \"%s\"", $object->value);
					}
					else if ($object->posttype == "Status|Photo") {
						$text .= "fotoğraf paylaştı. Görmek için sitemize giriş yapmanız gerekiyor.";
						$html .= "fotoğraf paylaştı. Görmek için sitemize giriş yapmanız gerekiyor.";
					}
					else if ($object->posttype == "Status|Video") {
						$text .= "video paylaştı. İzlemek için sitemize giriş yapmanız gerekiyor.";
						$html .= "video paylaştı. İzlemek için sitemize giriş yapmanız gerekiyor.";
					}
				}
				
				break;
				
			case "Message":
				$subject = sprintf("%s - Bildirim", $user->name ." ". $user->surname);
				$text = sprintf("Merhaba %s, %s adlı kullanıcı size bir mesaj gönderdi. Mesajı okumak için sitemize giriş yapın.", $user->name, $actor->name ." ". $actor->surname);
				$html = sprintf("Merhaba %s, <br /><br /><br />%s adlı kullanıcı size bir mesaj gönderdi. Mesajı okumak için sitemize giriş yapın.", $user->name, $actor->name ." ". $actor->surname);
				
				break;
				
			case "Comment":
				$subject = sprintf("%s - Bildirim", $user->name ." ". $user->surname);
				$text = sprintf("Merhaba %s, %s adlı kullanıcı ", $user->name, $actor->name ." ". $actor->surname);
				$html = sprintf("Merhaba %s, %s adlı kullanıcı ", $user->name, $actor->name ." ". $actor->surname);
				
				if (get_class($object) == "comment") {
					if ($object->objecttype == "Status") {
						$text .= sprintf("bir gönderinize yorum yaptı. \n\n %s", $object->value);
						$html .= sprintf("bir gönderinize yorum yaptı. <br /><br /><br /> %s", $object->value);
					}
					else if ($object->objecttype == "Status|Photo") {
						$text .= sprintf("fotoğraflı bir gönderinize yorum yaptı. \n\n %s", $object->value);
						$html .= sprintf("fotoğraflı bir gönderinize yorum yaptı. <br /><br /><br /> %s", $object->value);
					}
					else if ($object->objecttype == "Status|Video") {
						$text .= sprintf("videolu bir gönderinize yorum yaptı. \n\n %s", $object->value);
						$html .= sprintf("videolu bir gönderinize yorum yaptı. <br /><br /><br /> %s", $object->value);
					}
					else if ($object->objecttype == "Photo") {
						$text .= sprintf("bir fotoğrafınıza yorum yaptı. \n\n %s", $object->value);
						$html .= sprintf("bir fotoğrafınıza yorum yaptı. <br /><br /><br /> %s", $object->value);
					}
					else if ($object->objecttype == "Video") {
						$text .= sprintf("bir videonuza yorum yaptı. \n\n %s", $object->value);
						$html .= sprintf("bir videonuza yorum yaptı. <br /><br /><br /> %s", $object->value);
					}
				}
				break;
				
			case "FriendRequest":
				$subject = sprintf("%s - Arkadaşlık İsteği", $user->name ." ". $user->surname);
				$text = sprintf("Merhaba %s, %s adlı kullanıcı size bir arkadaşlık isteği gönderdi. Yanıtlamak için sitemize giriş yapın.", $user->name, $actor->name ." ". $actor->surname);
				$html = sprintf("Merhaba %s, %s adlı kullanıcı size bir arkadaşlık isteği gönderdi. Yanıtlamak için sitemize giriş yapın.", $user->name, $actor->name ." ". $actor->surname);
				
				break;
				
			case "EventInvite": break;
			case "BirthdayCelebrations": break;
			case "HappyBirthday": break;
			case "UpcomingBirthdays": break;
			case "WeMissYou": break;
			case "Authenticate": break;
			case "PasswordReset": break;
			case "Newsletter": break;
			case "FreezeAccount": break;
			case "UnfreezeAccount": break;
		}
		
		$foot = "<br /><br /><br />" . config::title . " Yönetim <br /><br />
		<a href=\"". urlencode(config::domain) ."\">Anasayfa</a></body></html>";
		
		$html .= $foot;
	 
		$host = config::smtp_host;
		$username = config::smtp_user;
		$password = config::smtp_pass;
		$port = config::smtp_port;

		try {
			$transport = Swift_SmtpTransport::newInstance($host, $port)
			  ->setUsername($username)
			  ->setPassword($password);

			$mailer = Swift_Mailer::newInstance($transport);

			Swift_Preferences::getInstance()->setCharset('utf-8');
			$message = Swift_Message::newInstance($subject)
				->setCharset('utf-8')
				->setFrom($from)
				->setTo($to)
				->setBody($html, "text/html", "utf-8")
				->addPart($text, "text/plain", "utf-8");
			
			$mailer->send($message);
		}
		catch(Exception $ex) {
			print($ex->getMessage()); // todo logger
		}
	}
}
 ?>