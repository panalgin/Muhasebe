<?php
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/user.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/mailer.class.inc");
	
	$key = "RX3uy%5E%7D6V49ox64]";
	$auth = "";
	$type = "";
	
	if (isset($_GET['auth'])) {
		$auth = $_GET['auth'];
		$type = $_GET['type'];
		
		if (!empty($auth)) {
			switch($type) {
				case "email": break; // 10 min interval
				default:
					try {
						$cmd = "SELECT ID, AuthorID, AuthorType, BeholderID, BeholderType, ObjectID, ObjectType, JobParameter FROM CronJobs WHERE Status = 'Pending' AND JobType = 'Email'";
						$result = db::query($cmd);
						
						while($row = db::fetch($result)) {
							$author = $beholder = $object = $parameter = null;
							
							if ($row['AuthorType'] == "User")
								$author = utility::getuserfromid($row['AuthorID']);
							if ($row['BeholderType'] == "User")
								$beholder = utility::getuserfromid($row['BeholderID']);
								
							
							$object = utility::getobject($row['ObjectID'], $row['ObjectType']);
							$parameter = $row['JobParameter'];
							
							$cmd = sprintf("UPDATE CronJobs SET Status = 'Done', DoneAt = '%s' WHERE ID = '%s'", utility::now(), $row['ID']);
							db::query($cmd);
							
							mailer::send($beholder, $parameter, $author, $object); // User(), 'Message', Author(), Message()
						}
					}
						
					catch(Exception $ex) 
					{
						$ex->getMessage(); // log it 
					}
				
				break;
			}
		}
		else
			utility::redirect("index.php");
	}
?>