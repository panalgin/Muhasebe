<?php
	session_start();
	mb_language('uni');
	mb_internal_encoding('UTF-8');
	header("Content-Type: application/json; charset=UTF-8");	
	
	require_once("../bin/db_wrapper.class.inc");
	require_once("../bin/config.class.inc");
	require_once("../bin/utility.class.inc");
	
	$do = $_GET['do'];
	$list = array();
	
	if ($do != null) {
		$do = db::escape($_GET['do']);
		$value = db::escape(urldecode($_GET["value"])); 
	
		if ($value != null && strlen($value) > 1) {
			$value = mb_strtolower($value, "UTF-8");
			$from = array("i" => "(i|ı)", "ı" => "(ı|i)", "ç" => "(ç|c)", "c" => "(c|ç)", "ğ" => "(ğ|g)", "g" => "(g|ğ)", "s" => "(s|ş)", "ş" => "(ş|s)", "o" => "(o|ö)", "ö" => "(ö|o)", "u" => "(u|ü)", "ü" => "(ü|u)");
			$value = strtr($value, $from);
					
			switch($do) {
				case "location":
					$cmd = sprintf("SELECT ID, Name, Total FROM Locations WHERE LOWER(Name) REGEXP '%s' ORDER BY Total DESC LIMIT 20", $value);
					$result = db::query($cmd);
					
					$i = 0;
					
					while($row = db::fetch($result)) {
						if ($row['Total'] == null || $row['Total'] == 0)
							$list[$i]= array("Location" => array("ID" => $row['ID'], "Name" => $row['Name'], "Image" => "img/contacts.png"));
						else
							$list[$i]= array("Location" => array("ID" => $row['ID'], "Name" => $row['Name'], "Image" => "img/contacts.png", "Total" => $row['Total']));
						$i++;
					}
					
				break;
				
				case "language":
					$cmd = sprintf("SELECT ID, Name, Total FROM Languages WHERE LOWER(Name) REGEXP '%s' ORDER BY Total DESC LIMIT 20", $value);
					$result = db::query($cmd);
					
					$i = 0;
					while($row = db::fetch($result)) {
						if ($row['Total'] == null || $row['Total'] == 0)
							$list[$i]= array("Language" => array("ID" => $row['ID'], "Name" => $row['Name'], "Image" => "img/contacts.png"));
						else
							$list[$i]= array("Language" => array("ID" => $row['ID'], "Name" => $row['Name'], "Image" => "img/contacts.png", "Total" => $row['Total']));
						$i++;
					}
					
				case "friends":
					$user = utility::getcurrentuser();
					$cmd = sprintf("SELECT ID, Name, Surname, Gender, Profile FROM Users WHERE Users.ID IN (SELECT TargetID FROM FriendShips WHERE BaseID = '%s') AND (LOWER(CONCAT(Users.Name, ' ', Users.Surname)) REGEXP '%s') ORDER BY Name LIMIT 20", $user->id, $value);
					
					$result = db::query($cmd);
					
					$i = 0;
					while($row = db::fetch($result)) {
						$friend = new user();
						$friend->id = $row['ID'];
						$friend->name = $row['Name'];
						$friend->surname = $row['Surname'];
						$friend->gender = $row['Gender'];
						$friend->profile = $row['Profile'];
						
						$list[$i] = array("Friend" => array("ID" => $friend->id, "Name" => $friend->name . " " . $friend->surname, "Image" => urlencode($friend->avatar('midi'))));
						
						$i++;
					}
					
					break;
					
			}
		}
	}	
	
	echo(str_replace("\\\\", "\\", utility::json_encode($list)));
?>