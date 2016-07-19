<?php 
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");
require_once("gallery.class.inc");
require_once("message.class.inc");
require_once("mailer.class.inc");
require_once("friendrequest.class.inc");
require_once("action.class.inc");
require_once("notification.class.inc");

class user {
	
	public $id = 0;
	public $name;
	public $surname;
	public $email;
	public $password;
	public $gender;
	public $bornat;
	public $createdat;
	public $lastloginat;
	public $ipaddress;
	
	public $galleries = array();
	public $profile = null;
	public $type = "User";
	
	function __construct() {
	}
	
	function __destruct() {
	}
	
	function submit() {
		try {
			$cmd = sprintf("INSERT IGNORE INTO Users (Name, Surname, Email, Password, Gender, CreatedAt, BornAt) 
					VALUES
					('%s', '%s', '%s', '%s', '%s', '%s', '%s')", $this->name, $this->surname, $this->email, $this->password, $this->gender,
					$this->createdat, $this->bornat);
					
			$result = db::query($cmd);
		}
		catch(Exception $e) {
			die($e->getMessage());
		}		
	}
	
	function logout() {
		//logout ol, dbye son ip adresini ekle, çıkıs tarihini ekle vs
		$_SESSION['ID'] = null;
	}
	
	function login($mode = "active") {
		$success = false;
		try {
			switch($mode) {
				case "active":
					$cmd = sprintf("SELECT ID, Name, Surname, BornAt, CreatedAt, Gender, Profile FROM Users WHERE Email = '%s' AND Password = '%s' LIMIT 1;", $this->email, $this->password);
					$row = db::fetch(db::query($cmd));
					if ($row != null) {
						$this->id = $row['ID'];
						$this->name = $row['Name'];
						$this->surname = $row['Surname'];
						$this->email = $row['Email']; //.....<
						$this->bornat = $row['BornAt'];
						$this->gender = $row['Gender'];
						$this->profile = $row['Profile'];
						$this->createdat = $row['CreatedAt'];
						
						$cmd = sprintf("UPDATE Users SET LastLoginAt = '%s', LastOnlineAt = '%s'  WHERE ID = '%s'", utility::now(), utility::now(), $this->id);
						db::query($cmd);
						
						$_SESSION['ID'] = $this->id;
						$success = true;
					}
					else
						$success = false;
						
					break;
					
				case "silent":
					if ($this->id == 0) {
						$cmd = sprintf("SELECT ID FROM Users WHERE Email = '%s' AND Password = '%s'", $this->email, $this->password); // hash password
						$result = db::first(db::query($cmd));
						$this->id = $result[0];
					}
						
					$cmd = sprintf("UPDATE Users SET LastLoginAt = '%s', LastOnlineAt = '%s' WHERE ID = '%s'", utility::now(), utility::now(), $this->id); // ipaddress ?
					db::query($cmd);
						
					$_SESSION['ID'] = $this->id;
					$success = true;
					break;
			}
		}
		catch(Exception $e) {
			$success = false;
			//die($e->getMessage()); // LOGGER
		}

		return $success;
	}
	
	function avatar($size) {
		$out = "";
		switch($size) {
			case "midi":
				$pinfo = $this->get('picture-info');
				$midi = $pinfo['Midi'];
				$out = $midi; break;
			case "pre":
				$pinfo = $this->get('picture-info');
				$pre = $pinfo['Preview']['Source'];
				$out = $pre; break;
		}
		
		return $out;
	}
	
	function get($param, $id = 0) {
		switch($param) {
			case "notification-info":
				$notifications_info = array();
				$notifications = array();
				
				$cmd = sprintf("SELECT Notifications.ID, Notifications.CreatedAt, Notifications.AuthorID, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, Notifications.ObjectID, Notifications.ObjectType, Notifications.IsNoticed FROM Notifications JOIN(Users) ON (Notifications.AuthorID = Users.ID) WHERE BeholderID = '%s' ORDER BY IsNoticed ASC, CreatedAt DESC LIMIT 0, 5", $this->id);
				
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$notification = new notification();
					$notification->id = $row['ID'];
					$notification->createdat = $row['CreatedAt'];
					$notification->author = new user();
					$notification->author->id = $row['AuthorID'];
					$notification->author->name = $row['AuthorName'];
					$notification->author->surname = $row['AuthorSurname'];
					$notification->author->gender = $row['AuthorGender'];
					$notification->author->profile = $row['AuthorProfile'];
					
					$notification->isnoticed = $row['IsNoticed'];
					$notification->objectid = $row['ObjectID'];
					$notification->objecttype = $row['ObjectType'];
					
					if ($notification->objecttype == "Like" || $notification->objecttype == "Comment" || $notification->objecttype == "Tag") {
						$type = $notification->objecttype;
						
						switch($type) { // To set story, we must know what they liked or what they commented on, this should be improved for less sql queries
							case "Like":
								$cmd = sprintf("SELECT ObjectID, ObjectType FROM Likes WHERE ID = '%s'", $notification->objectid);
								$row = db::fetch(db::query($cmd));
								
								if ($row) {
									$notification->parentid = $row['ObjectID'];
									$notification->parenttype = $row['ObjectType'];
								}
								
								break;
								
							case "Comment":
								$cmd = sprintf("SELECT ObjectID, ObjectType FROM Comments WHERE ID = '%s'", $notification->objectid);
								$row = db::fetch(db::query($cmd));
								
								if ($row) {
									$notification->parentid = $row['ObjectID'];
									$notification->parenttype = $row['ObjectType'];
								}
								
								break;
								
							case "Tag":
							
								break;
						}
					}
					
					array_push($notifications, $notification);
				}
				
				$cmd = sprintf("SELECT COUNT(ID) as Count FROM Notifications WHERE BeholderID = '%s' AND IsNoticed = 'False'", $this->id);
				$row = db::fetch(db::query($cmd));
				$count = $row['Count'];
				
				$notifications_info['Notifications'] = $notifications;
				$notifications_info['Count'] = $count;
				
				return $notifications_info;
				break;
				
			case "message-info":
				$messages_info = array();
				$messages = array();
				
				$cmd = sprintf("SELECT * FROM (SELECT Messages.ID, '%s' as BaseID, IF(AuthorID = '%s', BeholderID, AuthorID) as TargetID, Value, Messages.CreatedAt, Users.Name as TargetName, Users.Surname as TargetSurname, Users.Gender as TargetGender, Users.Profile as TargetProfile, IF(AuthorID = '%s', 'True', 'False') as LastMessageByUser, Messages.IsNoticed FROM Messages JOIN (Users) ON (Users.ID = IF(AuthorID = '%s', BeholderID, AuthorID)) WHERE AuthorID = '%s' OR BeholderID = '%s' ORDER BY Messages.CreatedAt DESC) as Result GROUP BY Result.TargetID ORDER BY CreatedAt DESC LIMIT 0, 5", $this->id, $this->id, $this->id, $this->id, $this->id, $this->id);
				
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$message = new message();
					$message->id = $row['ID'];
					$message->baseid = $row['BaseID'];
					$message->value = $row['Value'];
					$message->createdat = $row['CreatedAt'];
					$message->lastmessagebyuser = $row['LastMessageByUser'];
					$message->isnoticed = $row['IsNoticed'];
					$message->target = new user();
					$message->target->id = $row['TargetID'];
					$message->target->name = $row['TargetName'];
					$message->target->surname = $row['TargetSurname'];
					$message->target->gender = $row['TargetGender'];
					$message->target->profile = $row['TargetProfile'];
					
					array_push($messages, $message);
				}
				
				$cmd = sprintf("SELECT COUNT(ID) as Count FROM Messages WHERE BeholderID = '%s' AND IsNoticed = 'False'", $this->id);
				$row = db::fetch(db::query($cmd));
				$count = $row['Count'];
				
				$messages_info['Messages'] = $messages;
				$messages_info['Count'] = $count;
				
				return $messages_info;
				break;
				
			case "request-info":
				$cmd = sprintf("SELECT FriendRequests.ID, FriendRequests.AuthorID, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, FriendRequests.IsNoticed, FriendRequests.CreatedAt FROM FriendRequests JOIN Users ON (Users.ID = FriendRequests.AuthorID) WHERE BeholderID = '%s' AND Status = 'Pending' ORDER BY FriendRequests.CreatedAt DESC LIMIT 5", $this->id);
				$result = db::query($cmd);
				$request_info = array();
				$requests = array();
				
				while($row = db::fetch($result)) {
					$friendreq = new friendrequest();
					$friendreq->author = new user();
					$friendreq->author->id = $row['AuthorID'];
					$friendreq->author->name = $row['AuthorName'];
					$friendreq->author->surname = $row['AuthorSurname'];
					$friendreq->author->gender = $row['AuthorGender'];
					$friendreq->author->profile = $row['AuthorProfile'];
					$friendreq->id = $row['ID'];
					$friendreq->isnoticed = $row['IsNoticed'];
					$friendreq->createdat = $row['CreatedAt'];
					
					array_push($requests, $friendreq);
				}
				
				$cmd = sprintf("SELECT COUNT(ID) as Count FROM FriendRequests WHERE BeholderID = '%s' AND Status = 'Pending' AND IsNoticed = 'False'", $this->id);
				$row = db::fetch(db::query($cmd));
				$count = $row['Count'];
				
				$request_info['Requests'] = $requests;
				$request_info['Count'] = $count;
				return $request_info; 
				break;
				
			case "galleries":
				$cmd = sprintf("SELECT ID, Name, CreatedAt From Galleries WHERE BeholderID = '%s' and BeholderType = '%s'", $this->id, "User");
				$result = db::query($cmd);
				$count = db::count($result);
				
				while($row = db::fetch($result)) {
					$this->galleries[$row['Name']] = array("ID" => $row['ID'],
														   "Name" => $row['Name'],
														   "CreatedAt" => $row['CreatedAt'],
														   "BeholderID" => $this->id,
														   "BeholderType" => "User");
				}
				
				if ($count == 0 || $this->galleries['Duvar Resimleri'] == null) {					
					$gallery = new gallery();
					$gallery->name = "Duvar Resimleri";
					$gallery->createdat = utility::now();
					$gallery->beholderid = $this->id;
					$gallery->beholdertype = "User";
					
					$gallery->submit();

					if ($gallery->id > 0) {
						$this->galleries = array($name => array("ID" => $gallery->id,
																"Type" => $gallery->type,
																"Name" => $gallery->name,
																"CreatedAt" => $gallery->createdat,
																"BeholderID" => $gallery->beholderid,
																"BeholderType" => $gallery->beholdertype));
					}
				}
				break;
				
			case "basic-info":
				$basic_info = array();
				
				if ($this->basic == null) {
					$cmd = sprintf("SELECT Location, Languages, Privacy, BornAt, InterestedIn, About, Gender FROM Users WHERE ID = '%s'", $this->id);
					$result = db::query($cmd);
					$row = db::fetch($result);
					$this->basic = $row;
				}
				
				if ($this->basic != null) {
					if ($this->basic['Location'] != null) {
						$location = json_decode($this->basic['Location'], true);
						
						if ($location['LivesIn'] != null || $location['BornIn'] != null) {
							$basic_info['Location'] = $location;
						}
					}
					
					if ($this->basic['Languages'] != null) {
						$languages = json_decode(stripcslashes($this->basic['Languages']), true);
						
						$basic_info['Languages'] = $languages;
					}
					
					if ($this->basic['Privacy'] != null) {
						$privacy = json_decode(stripcslashes($this->basic['Privacy']), true);
						$basic_info['Privacy'] = $privacy;
					}
					
					
					if ($this->basic['Gender'] != null)
						$basic_info['Gender'] = $this->basic['Gender'];
					
					if ($this->basic['BornAt'] != null)
						$basic_info['BornAt'] = $this->basic['BornAt'];
						
					if ($this->basic['InterestedIn'] != null)
						$basic_info['InterestedIn'] = $this->basic['InterestedIn'];
						
					if ($this->basic['About'] != null)
						$basic_info['About'] = $this->basic['About'];
				}
				
				return $basic_info; break; // interesting practice =)
			
			case "picture-info": 
				$picture_info = array();
				
				if ($this->profile == null) {
					$cmd = sprintf("SELECT Profile FROM Users WHERE ID = '%s'", $this->id);
					$result = db::query($cmd);
					$row = db::fetch($result);
					$this->profile = $row['Profile'];
				}
				
				if ($this->profile != null && $this->profile != "") {
					$json = json_decode($this->profile, true);
					
					if ($json['Original'] != null)
						$picture_info['Original'] = $json['Original'];
						
					if ($json['Midi'] != null)
						$picture_info['Midi'] = $json['Midi'];
					else {
						if ($this->gender == "Male")
							$picture_info['Midi'] = "img/default_profile_male[Midi].png";
						else if ($this->gender == "Female")
							$picture_info['Midi'] = "img/default_profile_female[Midi].png";
					}
					
					if ($json['Preview'] != null)
						$picture_info['Preview'] = $json['Preview'];
					else {
						if ($this->gender == "Male") {
							$picture_info['Preview'] = array("Source" => "img/default_profile_male.png", "Coords" => array("X" => 0, "Y" => 0, "Width" => 50, "Height" => 50, "Strech" => "False"), "Width" => 142, "Height" => 188);
						}
						else if ($this->gender == "Female") {
							$picture_info['Preview'] = array("Source" => "img/default_profile_female.png", "Coords" => array("X" => 0, "Y" => 0, "Width" => 50, "Height" => 50, "Strech" => "False"), "Width" => 142, "Height" => 188);
						}
					}
				}
				else {
					if ($this->gender == "Male") {
						$picture_info['Midi'] = "img/default_profile_male[Midi].png";
						$picture_info['Preview'] = array("Source" => "img/default_profile_male.png", "Coords" => array("X" => 0, "Y" => 0, "Width" => 50, "Height" => 50, "Strech" => "False"), "Width" => 142, "Height" => 188);
					}
					else if ($this->gender == "Female") {
						$picture_info['Midi'] = "img/default_profile_female[Midi].png";
						$picture_info['Preview'] = array("Source" => "img/default_profile_female.png", "Coords" => array("X" => 0, "Y" => 0, "Width" => 50, "Height" => 50, "Strech" => "False"), "Width" => 142, "Height" => 188);
					}
				}

				return $picture_info; break;
				
			case "acquaintances":
				$basic_info = $this->get('basic-info');
				$value = "";
				$people = array();
				
				if ($basic_info['Location'] != null) {
					if ($basic_info['Location']['LivesIn'] != null)
						$value = $basic_info['Location']['LivesIn']['Name'];
				
					if ($value != "") {
						$value = utility::searchable($value);
						
						$cmd = sprintf("SELECT ID, Name, Surname, Gender, Profile, 
						(SELECT COUNT(ID) FROM FriendShips WHERE BaseID = Users.ID AND TargetID IN (SELECT BaseID From FriendShips WHERE TargetID = '%s')) as AcqCount
						From Users WHERE ID <> '%s' AND ID NOT IN (SELECT BeholderID FROM FriendRequests Where AuthorID = '%s' UNION SELECT AuthorID FROM FriendRequests WHERE BeholderID = '%s') AND ID NOT IN (SELECT BaseID FROM FriendShips WHERE TargetID = '%s') AND (ID IN (SELECT BaseID FROM FriendShips WHERE TargetID IN (SELECT BaseID FROM FriendShips WHERE TargetID = '%s')) OR ID IN (SELECT ID FROM Users WHERE LOWER(Location) REGEXP '%s')) ORDER BY RAND() LIMIT 0, 5", $this->id, $this->id, $this->id, $this->id, $this->id, $this->id, $value);
						
						$result = db::query($cmd);
						
						while($row = db::fetch($result)) {
							$person = new user();
							$person->id = $row['ID'];
							$person->name = $row['Name'];
							$person->surname = $row['Surname'];
							$person->gender = $row['Gender'];
							$person->profile = $row['Profile'];
							$person->acquaintance_count = $row['AcqCount'];
							
							array_push($people, $person);
						}
					}
					
				} 
				
				return $people; break;
				
			case "friends-mini":
				$friends = array();
				$cmd = sprintf("SELECT ID, Name, Surname, Gender, Profile FROM Users WHERE Users.ID IN (SELECT TargetID FROM FriendShips WHERE BaseID = '%s') ORDER BY RAND() LIMIT 0, 10", $this->id);
				
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$friend = new user();
					$friend->id = $row['ID'];
					$friend->name = $row['Name'];
					$friend->surname = $row['Surname'];
					$friend->gender = $row['Gender'];
					$friend->profile = $row['Profile'];
					
					array_push($friends, $friend);
				}
				return $friends; break;
				
			case "friends-total":
				$count = 0;
				
				$cmd = sprintf("SELECT COUNT(ID) as Total FROM FriendShips WHERE BaseID = '%s'", $this->id);
				$row = db::fetch(db::query($cmd));
				
				if ($row['Total'] > 0)
					$count = $row['Total'];
					
				return $count; break;
				
			case "friends-all":
				$friends = array();
				$cmd = sprintf("SELECT ID, Name, Surname, Gender, Profile FROM Users WHERE Users.ID IN (SELECT TargetID FROM FriendShips WHERE BaseID = '%s') ORDER BY Name", $this->id);
				
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$friend = new user();
					$friend->id = $row['ID'];
					$friend->name = $row['Name'];
					$friend->surname = $row['Surname'];
					$friend->gender = $row['Gender'];
					$friend->profile = $row['Profile'];
					
					array_push($friends, $friend);
				}
				
				return $friends; break;
				
			case "messages-all":
				$messages = array();
				
				$cmd = sprintf("SELECT * FROM (SELECT Messages.ID, '%s' as BaseID, IF(AuthorID = '%s', BeholderID, AuthorID) as TargetID, Value, Messages.CreatedAt, Users.Name as TargetName, Users.Surname as TargetSurname, Users.Gender as TargetGender, Users.Profile as TargetProfile, IF(AuthorID = '%s', 'True', 'False') as LastMessageByUser FROM Messages JOIN (Users) ON (Users.ID = IF(AuthorID = '%s', BeholderID, AuthorID)) WHERE AuthorID = '%s' OR BeholderID = '%s' ORDER BY Messages.CreatedAt DESC) as Result GROUP BY Result.TargetID ORDER BY CreatedAt DESC", $this->id, $this->id, $this->id, $this->id, $this->id, $this->id);
				
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$message = new message();
					$message->id = $row['ID'];
					$message->baseid = $row['BaseID'];
					$message->value = $row['Value'];
					$message->createdat = $row['CreatedAt'];
					$message->lastmessagebyuser = $row['LastMessageByUser'];
					$message->target = new user();
					$message->target->id = $row['TargetID'];
					$message->target->name = $row['TargetName'];
					$message->target->surname = $row['TargetSurname'];
					$message->target->gender = $row['TargetGender'];
					$message->target->profile = $row['TargetProfile'];
					
					array_push($messages, $message);
				}
				
				return $messages; break;
				
			case "conversation":
				if ($id > 0) {
					$tid = $id;
					$conversations = array();
					$cmd = sprintf("SELECT ID, AuthorID, Value, CreatedAt FROM Messages WHERE (AuthorID = '%s' AND BeholderID = '%s') OR (AuthorID = '%s' AND BeholderID = '%s') ORDER BY CreatedAt ASC", $this->id, $tid, $tid, $this->id);
					
					$result = db::query($cmd);
					$index = 0;
					$last_author_id = 0;
					
					while($row = db::fetch($result)) {						
						$message = array();
						$message = array("ID" => $row['ID'], "BaseID" => $row['AuthorID'], "Value" => $row['Value'], "CreatedAt" => $row['CreatedAt']);
						
						if ($last_author_id != $message['BaseID'])
							$index++;
						
						$conversations[$index][] = $message;
						$last_author_id = $message['BaseID'];
					}
					
					return $conversations; break;
				}
				
				return null; break;
		}
	}
	
	function isfriendwith($target) {
		$cmd = sprintf("SELECT Status, AuthorID FROM FriendRequests WHERE (AuthorID = '%s' OR AuthorID = '%s') AND (BeholderID = '%s' OR BeholderID = '%s') LIMIT 1", $this->id, $target->id, $this->id, $target->id);
		$row = db::fetch(db::query($cmd));
		
		if (!$row)
			return "False";
		
		if ($row['Status'] == "Pending") {
			if ($row['AuthorID'] == $target->id)
				return "Response";
			else if ($row['AuthorID'] == $this->id)
				return "Pending";
			else
				return "False";
		}
		else if ($row['Status'] == "Approved") 
			return "True";
			
		return "False";
	}
	
	function notify($event, $author = null, $object = null) {
		if (is_array($event)) { // todo: is online
			$type = $event['Type'];
			$isonline = $this->isonline();
			if ($isonline == false) {
				switch($type) {
					case "Post":
						mailer::queue($this, "Post", $author, $object); break;
					case "Comment":
						mailer::queue($this, "Comment", $author, $object); break;
					case "Message":
						mailer::queue($this, "Message", $author); break;
					case "FriendRequest":
						mailer::queue($this, "FriendRequest", $author); break;
						
					// todo: implement other email types
				}
			}
			
			switch($type) {
				case "FriendRequest": 
					if ($isonline) {
						$name = "poll/user-" . $this->id . ".p";
						file_put_contents($name, utility::json_encode($event), LOCK_EX);
					}
					break;
				case "Message":
					if ($isonline) {
						$name = "poll/user-" . $this->id . ".p";
						file_put_contents($name, utility::json_encode($event), LOCK_EX);
					}
					break;
				case "FriendApproval":
						$action = new action();
						$action->authorid = $author->id;
						$action->beholderid = $this->id;
						$action->createdat = utility::now();
						$action->actiontype = $type;
						$action->objectid = $object->id;
						$action->objecttype = $object->type;
						
						$action->submit();
						
						$cmd = sprintf("INSERT INTO Notifications (AuthorID, BeholderID, CreatedAt, ObjectID, ObjectType) VALUES('%s', '%s', '%s', '%s', '%s')", $author->id, $this->id, utility::now(), $action->id, $action->actiontype);
						
						$result = db::query($cmd);
						
						if ($isonline) {
							$event['ID'] = $result;
							$name = "poll/user-" . $this->id . ".p";
							file_put_contents($name, utility::json_encode($event), LOCK_EX);
						}
					break;
					
				case "Post":
						$cmd = sprintf("INSERT INTO Notifications (AuthorID, BeholderID, CreatedAt, ObjectID, ObjectType) VALUES('%s', '%s', '%s', '%s', '%s')", $author->id, $this->id, utility::now(), $object->id, $object->type);
						
						$result = db::query($cmd);
						
						if ($isonline) {
							$event['ID'] = $result;
							$name = "poll/user-" . $this->id . ".p";
							file_put_contents($name, utility::json_encode($event), LOCK_EX);
						}
					break;
					
				case "Comment":
						$cmd = sprintf("INSERT INTO Notifications (AuthorID, BeholderID, CreatedAt, ObjectID, ObjectType) VALUES('%s', '%s', '%s', '%s', '%s')", $author->id, $this->id, utility::now(), $object->id, $object->type);
						
						$result = db::query($cmd);
						
						if ($isonline) {
							$event['ID'] = $result;
							$name = "poll/user-" . $this->id . ".p";
							file_put_contents($name, utility::json_encode($event), LOCK_EX);
						}
					break;
					
				case "Like":
						$cmd = sprintf("INSERT INTO Notifications (AuthorID, BeholderID, CreatedAt, ObjectID, ObjectType) VALUES('%s', '%s', '%s', '%s', '%s')", $author->id, $this->id, utility::now(), $object->id, $object->type);
						
						$result = db::query($cmd);
						
						if ($isonline) {
							$event['ID'] = $result;
							$name = "poll/user-" . $this->id . ".p";
							file_put_contents($name, utility::json_encode($event), LOCK_EX);
						}
					break;
					
				case "EventInvite":
				
					break;
					
				case "Poke":
				
					break;
			}
		}
	}
	
	// may crash when lastonlineat is null
	function isonline() {
		$cmd = sprintf("SELECT LastOnlineAt FROM Users WHERE ID = '%s'", $this->id);
		$row = db::first(db::query($cmd));
		$lastonlineat = strtotime($row[0]);
		
		if ((time() - $lastonlineat) > 40) {
			return false;
		}
		else
			return true;
	}
	
	private function invoke($parameter, $value = null) {
		if ($value == null)
			$value = "None";
			
		switch ($parameter) {				
			case "LivesInChanged":
				$value = $value['Name'];
				break;
				
			case "BornInChanged":
				$value = $value['Name'];
				break;
		}
	
		$past = date("Y-m-d H:i:s", strtotime("-5 hours"));
		$cmd = sprintf("SELECT ID FROM Actions WHERE AuthorID = '%s' AND BeholderID = '%s' AND ActionType = '%s' AND UpdatedAt >= '%s' LIMIT 0, 1", $this->id, $this->id, $parameter, $past);
		
		$result = db::query($cmd);
		
		if (db::count($result) > 0) {
			while($row = db::fetch($result)) {
				$cmd = sprintf("UPDATE Actions SET UpdatedAt = '%s' WHERE ID = '%s'", utility::now(), $row['ID']);
				db::query($cmd);
			}
		}
		else {
			$cmd = sprintf("INSERT INTO Actions (AuthorID, BeholderID, ActionType, ActionValue, ObjectID, ObjectType, CreatedAt, UpdatedAt) VALUES('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')", $this->id, $this->id, $parameter, $value, 0, "None", utility::now(), utility::now());
			db::query($cmd);
		}
	}
	
	public function update($property, $value = null) {
		if (isset($property)) {
			switch($property) {
				case "online":
					$cmd = sprintf("UPDATE Users SET LastOnlineAt = '%s' WHERE ID = '%s'", utility::now(), $this->id);
					db::query($cmd);
					break;
					
				case "profile":
					$cmd = sprintf("UPDATE Users SET Profile = '%s' WHERE ID = '%s'", utility::json_encode($value), $this->id);
					db::query($cmd);
					
					$this->invoke("ProfilePictureChanged");
					break;
				
				case "livesin":
					$this->invoke("LivesInChanged", $value);
					break;
				
				case "bornin":
					$this->invoke("BornInChanged", $value);
					break;
					
				case "interestedin":
					$this->invoke("InterestedInChanged");					
					break;
					
				case "about":
					$this->invoke("AboutChanged");
					break;
					
				case "languages":
					$this->invoke("LanguagesChanged");
					break;
			}
		}
	}
}
?>