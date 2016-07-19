<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="tr"> 
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
	<link type="text/css" rel="stylesheet" href="css/main.css" />
	<link type="text/css" rel="stylesheet" href="css/boxy.css" />
	<link type="image/x-icon" rel="icon" href="img/daflan.ico"  />
	<link type="image/x-icon" rel="shortcut icon" href="img/daflan.ico" />
	<title><?php echo($title); ?></title>
	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/jewels.js"></script>
	<script type="text/javascript" src="js/autoresize.js"></script>
	<script type="text/javascript" src="js/flowplayer.js"></script>
	<script type="text/javascript" src="js/json.js"></script>
	<script type="text/javascript" src="js/sublay.js"></script>
	<script type="text/javascript" src="js/boxy.js"></script>
</head>
<body>
	<script type="text/javascript">
		$(document).ready(function() {
			<?php if ($_SERVER['SCRIPT_NAME'] == "/index.php"): ?>
			$('a#home-link').click(function(event) {
				event.preventDefault();
				$("a[href='?act=news']").click();
			});
			<?php endif; ?>
			
			var beholderid = <?php print($user->id); ?>
			
			$(".friends-drop .content").on("click", "div#app-friend-button", function() {
				var json = $.parseJSON(unescape($(this).prev().val()));
				var button = $(this);
				
				if (json.Type && json.Author) {
					var request = $.ajax({
											url: "ajax.php",
											type: "POST",
											dataType: "json",
											contentType: "application/x-www-form-urlencoded;charset=UTF-8",
											data: 	{ 
														"do" : "app-friend-req",
														"value" : "none",
														"authorid" : json.Author['ID'],
														"beholderid" : beholderid,
														"beholdertype" : "User" 
													}
					});
					request.done(function(reply) {
						if (reply  == "true") {
							button.html("<img src='img/tick.png' alt='Arkadaşınız' />Arkadaşınız").removeAttr('id');
						}
					});
				}
			});
			$(".messages-drop .footer").on("click", "#see-all-messages", function(event) {
				event.preventDefault();
				$('#messages-jewel').focusout();
				<?php if ($_SERVER['SCRIPT_NAME'] == "/index.php"): ?>
				$("div.main-left li > a[href='?act=messages']").click();
				<?php else: ?>
				top.location = "index.php?act=messages";
				<?php endif; ?>
			});
			$(".notifications-drop .content").on("click", ".drop-element", function() {
				var json = $.parseJSON(unescape($(this).children("input[type='hidden']").val()));
				if (json && json.Href) {
					top.location = json.Href;
				}
			});
			$(".messages-drop .content").on("click", ".drop-element", function() {
				var json = $.parseJSON(unescape($(this).children("input[type='hidden']").val()));
				if (json && json.Type == "Message") {
					var uid = <?php print($user->id); ?>;
					var tid = 0;
					tid = json['Target']['ID'];
				<?php if ($_SERVER['SCRIPT_NAME'] == "/index.php"): ?>
					$('#messages-jewel').focusout();
					var pagelet = "main-conversation";
					$("img#messages-load").css('display', 'block');
					$.ajax({
						type: 'GET',
						url: 'inc/pagelet.php?p=' + pagelet + "&uid=" + uid + "&tid=" + tid,
						cache: true,
						async: true,
						success: function(data) {
							if (data) {
								if ($('div.main-main').html() != data) {			
									$('div.main-main').html(data);
								}
								
								$("img#messages-load").css('display', 'none');
								Invalidate();
								
								var curtab = $("div.main-left li > a[href='?act=messages']").parent();
								if (curtab.hasClass('active') == false)
									curtab.addClass('active');
							}
						}
					});
				<?php else: ?>
					top.location = "index.php?act=messages&cid=" + tid;
				<?php endif; ?>
				}
				
				return false;
			});
			
			$("img#friends-jewel'").mouseup(function() {
				var c = $("#friends-jewel").next().html();
				if (c != "" && c != "0") {
					SyncRequests();
				}
			});
			
			$("img#messages-jewel").mouseup( function() {
				var n = $(".messages-drop > .content > .drop-element").length;
				var c = $("#messages-jewel").next().html();
				if (c != "" && c != "0") {
					if (n == 0)
						RetrieveMessages("True");
					else if (n > 0)
						RetrieveMessages("Lazy");
				}
				else if (n == 0) {
					RetrieveMessages("None");
				}
			});
			
			$("img#notifications-jewel").mouseup( function() {
				var c = $("#notifications-jewel").next().html();
				
				if (c != "" && c != "0") {
					SyncNotifications();
				}
			});
		});
		
		function SyncRequests() {
			var unnoticed = [];
			$("div.friends-drop .content .right").children("input[type='hidden']").each(function() {
				var data = $.parseJSON(unescape($(this).val()));
				if (data && data['IsNoticed'] == "False")
				unnoticed.push(data.ID);
			});
			
			var json = $.toJSON(unnoticed);

			if (json && json != "[]" && unnoticed.length > 0) {
				var request = $.ajax({
						url: "ajax.php",
						type: "POST",
						dataType: "json",
						contentType: "application/x-www-form-urlencoded;charset=UTF-8",
						data: {'do' : 'sync-friend-reqs',
						'authorid' : beholderid,
						'value' : 'none',
						'json' : json }
				});

				request.done(function(data) {
					if (data[0] == true) {
						
						
						$("div.friends-drop .content .right").children("input[type='hidden']").each(function() {
							var data = $.parseJSON(unescape($(this).val()));
							
							if (data && data.IsNoticed == "False")
							data.IsNoticed = "True";
							
							$(this).val(escape($.toJSON(data)));
						});
						
						var count = $("img#friends-jewel").next();
						
						if (count.hasClass('count')) {
							count.html('').css('display', 'none');
						}
						
						$(".friends-drop .content .new").removeClass("new");
					}
				});

				request.fail(function(jqXHR, textStatus) {
					alert( "Hata: İsteğinizi gerçekleştiremedik." + textStatus );
				});
			}
		}
		
		function SyncNotifications() {
			var unnoticed = [];
			$("div.notifications-drop .content .drop-element").children("input[type='hidden']").each(function() {
				var data = $.parseJSON(unescape($(this).val()));
				if (data && data['IsNoticed'] == "False")
					unnoticed.push(data.ID);
			});

			var json = $.toJSON(unnoticed);
			if (json && json != "[]" && unnoticed.length > 0) {
				var request = $.ajax({
					url: "ajax.php",
					type: "POST",
					dataType: "json",
					cache: "false",
					contentType: "application/x-www-form-urlencoded;charset=UTF-8",
					data: 	{ 
						"do" : "sync-notifications",
						"value" : "none",
						"authorid" : "<?php print($user->id); ?>",
						"json": json
					}
				});
				request.done(function(reply) {
					if (reply && reply[0] == true) {					
						var counter = $("img#notifications-jewel").next();
						counter.html("").css("display", "none");
					}
				});
				request.fail(function() {
					alert("Hata: İsteğinizi gerçekleştiremedik.");
				});
			}
		}
		
		function RetrieveNotifications() {
			var request = $.ajax({
				url: "ajax.php",
				type: "POST",
				dataType: "json",
				cache: "false",
				contentType: "application/x-www-form-urlencoded;charset=UTF-8",
				data: 	{ 
					"do" : "ret-notifications-info",
					"value" : "none",
					"authorid" : "<?php print($user->id); ?>"
				}
			});
			request.done(function(reply) {
				if (reply) {
					var i = 0;
					var data = reply;
					var total = data['Notifications'].length;
					var last = data['Notifications'][total - 1];

					$('.notifications-drop .content .drop-element').remove();
					for(i = 0; i < total; i++) {
						var item = data['Notifications'][i];
						var ext = "";
						var to = "";
						
						if (item['ID'] == last['ID']) //end of
							ext = " last";
						
						var template = 
						"<div class='drop-element" + ext +"'>" +
						"<input type='hidden' value='" + escape($.toJSON(item)) + "' />" +
						"<div class='left'>" +
						"<a class='avatar' href='profile.php?id=" + item['Author']['ID'] + "'><img class='midi' src='" + item['Author']['Midi'] + "' alt='" + item['Author']['Name'] + " " + item['Author']['Surname'] + "' /></a>" +
						"</div>" +
							"<div class='right'>" +
								"<a class='user' href='profile.php?id=" + item['Author']['ID'] + "'>" + item['Author']['Name'] + " " + item['Author']['Surname'] + "</a> " +
								"<span>" + item['Story'] + "</span><br />" +
								"<span class='date'>" + item['Countdown'] + "</span>" +
							"</div>" +
						"</div>";
						
						$(".notifications-drop .content").append(template);
					}
					
					
					var counter = $("img#notifications-jewel").next();
					counter.html(data['Count']);
					
					if (data['Count'] == 0) {
						counter.css("display", "none");
					}
					else
						counter.removeClass('hidden').css("display", "block");
				}
			});
			request.fail(function() {
				alert("Hata: İsteğinizi gerçekleştiremedik.");
			});
		}
		
		function RetrieveMessages(sync) {
			var value = "none";
			if (sync == "True" || sync == "Lazy") {
				if ($(".messages-drop .content .drop-element").length == 0)
					$('.messages-drop .content .drop-ajax-load').css('display', 'block');
					
				value = "true";
			}
				
			var request = $.ajax({
				url: "ajax.php",
				type: "POST",
				dataType: "json",
				cache: "false",
				contentType: "application/x-www-form-urlencoded;charset=UTF-8",
				data: 	{ 
					"do" : "ret-messages-info",
					"value" : value,
					"authorid" : "<?php print($user->id); ?>"
				}
			});
			request.done(function(reply) {
				if (reply) {
					var i = 0;
					var data = reply;
					var total = data['Messages'].length;
					var last = data['Messages'][total - 1];
					
					$('.messages-drop .content .drop-ajax-load').css('display', 'none');
					
					if (sync != "Lazy") {
						$('.messages-drop .content .drop-element').remove();
						for(i = 0; i < total; i++) {
							var item = data['Messages'][i];
							var ext = "";
							var to = "";
							
							if (item['ID'] == last['ID']) //end of
								ext = " last";
							
							if (item['LastMessageByUser'] == "True")
								to = "<img class='to' src='img/to.png' alt='Kime' />";
							
							var template = 
							"<div class='drop-element" + ext +"'>" +
								"<input type='hidden' value='" + escape($.toJSON(item)) + "' />" +
								"<div class='left'>" +
									"<a class='avatar' href='profile.php?id=" + item['Target']['ID'] + "'><img class='midi' src='" + item['Target']['Midi'] + "' alt='" + item['Target']['Name'] + " " + item['Target']['Surname'] + "' /></a>" +
								"</div>" +
								"<div class='right'>" +
									"<a class='user' href='profile.php?id=" + item['Target']['ID'] + "'>" + item['Target']['Name'] + " " + item['Target']['Surname'] + "</a><br />" +
									"<span>" + to + item['Value'] + "..." + "</span><br />" +
									"<span class='date'>" + item['Countdown'] + "</span>" +
								"</div>" +
							"</div>";
							
							$(".messages-drop .content").append(template);
						}
					}
					
					var counter = $("img#messages-jewel").next();
					counter.html(data['Count']);
					
					if (data['Count'] == 0) {
						counter.css("display", "none");
					}
					else
						counter.removeClass('hidden').css("display", "block");
				}
			});
			request.fail(function() {
				alert("Hata: İsteğinizi gerçekleştiremedik.");
			});
		}
	</script>
	<div class="main-top">
		<?php 
				$request_info = $user->get("request-info");
				$fr_count = $request_info['Count'];
				
				$message_info = $user->get("message-info");
				$me_count = $message_info['Count'];
				
				$notification_info = $user->get("notification-info");
				$nf_count = $notification_info['Count'];
		?>
		<div class="main-top-hold">
			<div class="cell logo">
				<a id="home-link" href="index.php" title="Anasayfa"><img class="mini-logo" src="img/logo-mini.png" alt="Kıbrıs" /></a>
				<ul class="jewels">
					<li><img id="friends-jewel" src="img/friends-jewel.png" alt="Arkadaşlık İstekleri" /><div class="count <?php if($fr_count < 1) print('hidden'); ?>"><?php if ($fr_count > 0) print($fr_count); ?></div></li>
					<li><img id="messages-jewel" src="img/messages-jewel.png" alt="Son Mesajlar" /><div class="count <?php if($me_count < 1) print('hidden'); ?>"><?php if ($me_count > 0) print($me_count); ?></div></li>
					<li><img id="notifications-jewel" src="img/notification-jewel.png" alt="Bilgilendirme" /><div class="count <?php if($nf_count < 1) print('hidden'); ?>"><?php if ($nf_count > 0) print($nf_count); ?></div></li>
				</ul>
			</div>
			<div class="cell search">
				<input class="search-box" type="text" /><input class="search-btn" type="image" src="img/search-btn.png" />
			</div>
			<div class="cell righted">
				<ul class="cp-rightop">
					<li class="cp-profile"><a href="profile.php" title="Profil" class="cp-link"><img src="<?php print($user->avatar("midi")); ?>" alt="<?php printf("%s %s", $user->name, $user->surname); ?>" /> <span><?php printf("%s %s", $user->name, $user->surname); ?></span> </a></li>
					<li class="cp-split"><img src="img/top-split.png" alt="Ayraç" /></li>
					<li><a class="cp-link" href="index.php" title="Anasayfa">Anasayfa</a></li>
					<li class="cp-split"><img src="img/top-split.png" alt="Ayraç" /></li>
					<li id="settings-jewel-hold"><img id="settings-jewel" src="img/settings.png" alt="Ayarlar" class="settings-icon" /></li>
				</ul>
			</div>
		</div>
		<span class="version"><?php print config::version; ?></span>
	</div>
	<div class="drop-menu-holder">
		<div class="friends-drop">
			<div class="header">Arkadaşlık İstekleri</div>
			<div class="content">
				<?php
				$last = end($request_info['Requests']);
				foreach($request_info['Requests'] as $request): ?>
					<div class="drop-element new <?php if ($request == $last) print(' last'); ?>">
						<div class="left">
							<a class="avatar" href="profile.php?id=<?php print($request->author->id); ?>"><img class="midi" src="<?php print($request->author->avatar("midi")); ?>" alt="<?php printf("%s %s", $request->author->name, $request->author->surname); ?>" /></a>
							<a class="user" href="profile.php?id=<?php print($request->author->id); ?>"><span><?php printf("%s %s", $request->author->name, $request->author->surname); ?></span></a>
						</div>
						<div class="right">
							<input type="hidden" value="<?php print(db::escape(utility::json_encode(array("Type" => "FriendRequest", "ID" => $request->id, "IsNoticed" => $request->isnoticed, "Author" => array("ID" => $request->author->id))))); ?>" />
							<div id="app-friend-button" class="button-white"><img src="img/add-friend.png" alt="İsteği Yanıtla" />Onayla</div>
						</div>
					</div>
				<?php endforeach; ?>
			</div>
			<div class="footer"><a href="#">Tüm Arkadaşlık İsteklerini Gör</a></div>
		</div>
		<div class="messages-drop">
			<div class="header">Mesajlar</div>
			<div class="content">
				<img class="drop-ajax-load" src="img/ajax-load.gif" alt="Yükleniyor" />
				<?php /*
				$last = end($message_info['Messages']);
				foreach($message_info['Messages'] as $message): ?>
					<div class="drop-element new <?php if ($message == $last) print(' last'); ?>">
						<input type="hidden" value="<?php print(db::escape(utility::json_encode(array("Type" => "Message", "ID" => $message->id, "Target" => array("ID" => $message->target->id))))); ?>" />
						<div class="left">
							<a class="avatar" href="profile.php?id=<?php print($message->target->id); ?>"><img class="midi" src="<?php print($message->target->avatar("midi")); ?>" alt="<?php printf("%s %s", $message->target->name, $message->target->surname); ?>" /></a>
						</div>
						<div class="right">
							<a class="user" href="profile.php?id=<?php print($message->target->id); ?>"><?php printf("%s %s", $message->target->name, $message->target->surname); ?></a><br />
							<span>
							<?php 
								$to = "<img class=\"to\" src=\"img/to.png\" alt=\"Kime\" />";
								printf("%s%s", $message->lastmessagebyuser == "True" ? $to : "", substr($message->value, 0, 20)); ?>...</span><br />
							<span class="date"><?php print(utility::countdown($message->createdat)); ?></span>
						</div>
					</div>
			
				<?php endforeach;*/ ?>
			</div>
			<div class="footer"><a id="see-all-messages" href="#">Tüm Mesajları Gör</a></div>
		</div>

		<div class="notifications-drop">
			<div class="header">Bildirimler</div>
			<div class="content">
				<?php 
				$last = end($notification_info['Notifications']);
				foreach($notification_info['Notifications'] as $notification): ?>
					<div class="drop-element new <?php if ($notification == $last) print(' last'); ?>">
						<input type="hidden" value="<?php print(db::escape(utility::json_encode(array("Type" => "Notification", "ID" => $notification->id, "Author" => array("ID" => $notification->author->id), "IsNoticed" => $notification->isnoticed, "Href" => $notification->get('href'))))); ?>" />
						<div class="left">
							<a class="avatar" href="profile.php?id=<?php print($notification->author->id); ?>"><img class="midi" src="<?php print($notification->author->avatar("midi")); ?>" alt="<?php printf("%s %s", $notification->author->name, $notification->author->surname); ?>" /></a>
						</div>
						<div class="right">
							<a class="user" href="profile.php?id=<?php print($notification->author->id); ?>"><?php printf("%s %s", $notification->author->name, $notification->author->surname); ?></a>
							<span><?php print($notification->get("story")); ?></span><br />
							<span class="date"><?php printf("%s%s", $notification->get("icon"), utility::countdown($notification->createdat)); ?></span>
						</div>
					</div>
			
				<?php endforeach; ?>
			
			</div>
			<div class="footer"><a href="#">Tüm Bildirimleri Gör</a></div>
		</div>
		
		<div class="settings-drop">
			<ul style="margin: 5px;">
				<li>Hesap Ayarları</li>
				<li>Gizlilik</li>
				<li><a href="login.php?do=logout">Çıkış Yap</a></li>
			</ul>
		</div>
	</div>
	<div id="wrapper" class="wrapper">
		