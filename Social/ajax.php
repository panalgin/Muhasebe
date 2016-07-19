<?php 
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/wall.class.inc");
	require_once("bin/comment.class.inc");
	require_once("bin/photo.class.inc");
	require_once("bin/video.class.inc");
	require_once("bin/friendrequest.class.inc");
	require_once("bin/like.class.inc");
	
	$do = $_POST['do'];
	$list = null;
	
	if ($do == null) {
		$id = db::escape($_GET['id']);
		$value = db::escape($_GET["value"]);
	
		if ($value != null && strlen($value) > 3) {
			switch($id) {
				case "Username":
					$cmd = "SELECT * FROM Users WHERE Username = '$value'";
					
					$result = db::query($cmd);
					$passed = true;
					
					if (db::count($result) > 0)
						$passed = false;
					
					$list = array($id, $passed, "none");
						
					break;
					
				case "Email":
					$passed = true;
						
					if (strlen($value) < 6)
						$passed = false;
					else
					{
						$cmd = "SELECT * FROM Users WHERE Email = '$value'";
						$result = db::query($cmd);

						if (db::count($result) > 0)
							$passed = false;
						else if (preg_match_all("/^[^\W][a-zA-Z0-9_\-]+(\.[a-zA-Z0-9_\-]+)*\@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\.[a-zA-Z]{2,4}$/", $value, $matches) == false)
							$passed = false;
						else if (preg_match_all("/^[0-9a-zA-Z\_\@\.\-]+$/", $value, $matches) == false)
							$passed = false;
					}
							
					$list = array($id, $passed, "none");
						
					break;
				
				case "Progress":
					try {
						if(isset($_GET['key'])) {
							$key = db::escape($_GET['key']);
							
							/*if (function_exists("apc_fetch")) {
								$info = apc_fetch('upload_' . $key);
								if ($info != null)
									$list = array($id, $key, ($info['current'] / $info['total']) * 100);
							}
							else*/ if (function_exists("uploadprogress_get_info")) {
								$info = uploadprogress_get_info($key);
								
								if ($info != null)
									$list = array($id, $key, ($info['bytes_uploaded'] / $info['bytes_total']) * 100);
							}
							/*else if (strnatcmp(phpversion(),'5.4.0') >= 0) { // new feauture session.uploadprogress
								$info = ($_SESSION['upload_progress_' . $key]['bytes_processed'] / $_SESSION['upload_progress_' . $key]['content_length']) * 100;
								$list = array($id, $key, $info);
							}*/
							
							if ($list == null) {
								$list = array($id, $key, "marqueue");
							}
						}
					}
					catch(Exception $ex) {
						die($ex->getMessage());
					}
					
					break;
			}
		}
		else
			$list = array($id, false, "none");
	}
	else {
		//$token = $_POST['token'];
		$value = db::escape($_POST['value']);
		$authorid = intval($_POST['authorid']);
		$beholderid = intval($_POST['beholderid']);
		$beholdertype = db::escape($_POST['beholdertype']);
		$posttype = db::escape($_POST['posttype']);
		$objectid = intval($_POST['objectid']);
		$objecttype = db::escape($_POST['objecttype']);
		
		if ($beholderid == null) {
			$beholderid = $authorid;
			$beholdertype = "User";
		}
		
		if ($posttype == null)
			$posttype = "Status";
			
		if ($authorid == null || $authorid == 0)
			return;
		
		if ($value != null && strlen($value) > 0) {
			switch($do) {
				case "post":					
					$post = new post();
					$post->authorid = $authorid;
					$post->createdat = utility::now();
					$post->value = str_replace("\n", "<br />", $value);
					$post->beholderid = $beholderid;
					$post->beholdertype = $beholdertype;
					$post->posttype = $posttype;
					
					if ($post->posttype == "Status|Photo") {
						$originalpath = db::escape($_POST['originalpath']);
						$thumbnailpath = db::escape($_POST['thumbnailpath']);
						
						$target = "upload/photo/";
						
						$org_name = pathinfo($originalpath, PATHINFO_FILENAME);
						$org_ext = '.' . pathinfo($originalpath, PATHINFO_EXTENSION);
						$thumb_full = pathinfo($thumbnailpath, PATHINFO_BASENAME);
						
						//echo($originalpath . "\r\n" . $org_name . "\r\n" . $org_ext . "\r\n" . $thumb_full);
						//die("asfg");
						
						$previewpath = utility::scale(stripcslashes($originalpath), $target . $org_name . "[Preview]" . $org_ext, 320, 240);
						$previewpath = db::escape($previewpath);
						
						rename($originalpath, $target . $org_name . $org_ext);
						rename($thumbnailpath, $target . $thumb_full);
						$originalpath = $target . $org_name . $org_ext;
						$thumbnailpath = $target . $thumb_full;
						
						$photo = new photo();
						$photo->originalpath = $originalpath;
						$photo->previewpath = $previewpath;
						$photo->thumbnailpath = $thumbnailpath;
						$photo->createdat = utility::now();
						$photo->beholderid = $authorid;
						$photo->beholdertype = "User"; // beholder.Type
						
						$author = utility::getuserfromid($authorid, "galleries");
						$photo->galleryid = $author->galleries['Duvar Resimleri']['ID'];
						$photo->submit();
						
						$post->attachmentid = $photo->id;
						$post->attachmenttype = $photo->type;
					}
					else if ($post->posttype == "Status|Video") {
						$originalpath = db::escape($_POST['originalpath']);
						$thumbnailpath = db::escape($_POST['thumbnailpath']);
						
						$target = "upload/video/";
						
						$org_name = pathinfo($originalpath, PATHINFO_FILENAME);
						$org_ext = '.' . pathinfo($originalpath, PATHINFO_EXTENSION);
						$thumb_full = pathinfo($thumbnailpath, PATHINFO_BASENAME);
						
						rename($originalpath, $target . $org_name . $org_ext);
						rename($thumbnailpath, $target . $thumb_full);
						$originalpath = $target . $org_name . $org_ext;
						$thumbnailpath = $target . $thumb_full;
						
						//move image, video
						
						$video = new video();
						$video->originalpath = $originalpath;
						$video->thumbnailpath = $thumbnailpath;
						$video->createdat = utility::now();
						$video->beholderid = $authorid;
						$video->beholdertype = "User"; // beholder.Type
						
						$video->submit();
						
						$post->attachmentid = $video->id;
						$post->attachmenttype = $video->type;
					}
					
					$post->submit();
					
					if (($post->authorid != $post->beholderid) && $post->beholdertype == "User") {
						$author = utility::getuserfromid($post->authorid);
						$beholder = utility::getuserfromid($post->beholderid);
						
						$event = array("Type" => "Post", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");														
						$beholder->notify($event, $author, $post); 
					}
					
					$list = wall::ajax_post_callback($post);
						
					break;
				case "add-comment":
					$comment = new comment();
					$comment->authorid = $authorid;
					$comment->createdat = utility::now();
					$comment->value = str_replace("\n", "<br />", $value);
					$comment->objectid = $objectid;
					$comment->objecttype = $objecttype;
					$comment->beholderid = $beholderid;
					$comment->beholdertype = $beholdertype;
					
					$comment->submit();
					
					if ($comment->objecttype == "Status" || $comment->objectype == "Status|Photo" || $comment->objectype == "Status|Video") {
						$post = utility::getobject($comment->objectid, "Post");
					
						if ($post->beholderid != $post->authorid && $post->beholdertype == "User") { // Orhan Mustafanın duvarında yaptığı post
							if ($comment->authorid != $post->beholderid) { // Posta kim yorum yaparsa post sahibini uyar
								$author = utility::getuserfromid($comment->authorid);
								$beholder = utility::getuserfromid($post->beholderid);
								
								$event = array("Type" => "Comment", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");														
								$beholder->notify($event, $author, $comment);
							}
							if ($comment->authorid != $post->authorid) { // Posta kim yorum yaparsa post authorı uyar
								$author = utility::getuserfromid($comment->authorid);
								$beholder = utility::getuserfromid($post->authorid);
								
								$event = array("Type" => "Comment", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");														
								$beholder->notify($event, $author, $comment);
							}
						}
						else if ($post->authorid == $post->beholderid && $post->beholdertype == "User" && $comment->authorid != $post->beholderid) { 
							// Eğer kendi postuysa, yorum yapanın kim olduğunu beholdera bildir
							$author = utility::getuserfromid($comment->authorid);
							$beholder = utility::getuserfromid($post->beholderid);
								
							$event = array("Type" => "Comment", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");														
							$beholder->notify($event, $author, $comment);
						}
					}
					
					$list = wall::ajax_comment_callback($comment);
					break;
					
				case "like":
					$cmd = sprintf("SELECT COUNT(ID) as Total FROM Likes WHERE AuthorID = '%s' and ObjectID = '%s' and ObjectType = '%s' and BeholderID = '%s' and BeholderType = '%s'", $authorid, $objectid, $objecttype, $beholderid, $beholdertype);
					
					$result = db::fetch(db::query($cmd));
					
					if ($result['Total'] > 0) { // zaten begenmis
						// vazgeç kodu unlike ile, muhtemelen kod buraya gelmeyecek, biri özel bişeyler denemedikçe
						$list = array("false", "Already liked it");
					}
					else {
						$like = new like();
						$like->authorid = $authorid;
						$like->beholderid = $beholderid;
						$like->beholdertype = $beholdertype;
						$like->objectid = $objectid;
						$like->objecttype = $objecttype;
						$like->createdat = utility::now();
						$like->submit();
						
						if ($authorid != $beholderid) {
							$author = utility::getuserfromid($authorid);
							$beholder = utility::getuserfromid($beholderid);

							$event = array("Type" => "Like", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");														
							$beholder->notify($event, $author, $like);
						}
							
						$list = array("true");
					}
					
					break;
					
				case "unlike":
					$cmd = sprintf("SELECT ID FROM Likes WHERE AuthorID = '%s' AND ObjectID = '%s' AND ObjectType = '%s' AND BeholderID = '%s' AND BeholderType = '%s' LIMIT 0, 1", $authorid, $objectid, $objecttype, $beholderid, $beholdertype);
					
					$result = db::query($cmd);
					$id = 0;
					
					while ($row = db::fetch($result)) {
						$id = $row['ID'];
					}
					
					if ($id > 0) {
						$cmd = sprintf("DELETE FROM Notifications WHERE ObjectID = '%s' AND ObjectType = 'Like' AND AuthorID = '%s'", $id, $authorid);
						db::query($cmd);
					}
					
					$cmd = sprintf("DELETE FROM Likes WHERE AuthorID = '%s' and ObjectID = '%s' and ObjectType = '%s' and BeholderID = '%s' and BeholderType = '%s'", $authorid, $objectid, $objecttype, $beholderid, $beholdertype);
					
					db::query($cmd);
					
					$list = array("true");
					
					break;
					
				case "edit-profile":
					switch($value) {
						case "basic":
							$new = json_decode($_POST['json'], true);
							$user = utility::getuserfromid($beholderid);
							$info = $user->get("basic-info");
							
							if ($new['Location'] != $info['Location']) {
								if ($info['Location'] != null) {
									if ($info['Location']['LivesIn'] != null) {
										if ($new['Location']['LivesIn'] == null || $info['Location']['LivesIn'] != $new['Location']['LivesIn']) {
											// -- livesin usage
											$cmd = sprintf("UPDATE Locations SET Total = Total - 1 WHERE ID = '%s'", db::escape($info['Location']['LivesIn']['ID']));
											db::query($cmd);
										}
									}
									
									if ($info['Location']['BornIn'] != null) {
										if ($new['Location']['BornIn'] == null || $info['Location']['BornIn'] != $new['Location']['BornIn']) {
											// -- bornin usage
											$cmd = sprintf("UPDATE Locations SET Total = Total - 1 WHERE ID = '%s'", db::escape($info['Location']['BornIn']['ID']));
											db::query($cmd);
										}
									}
								}
								
								if ($new['Location'] != null) {
									if ($new['Location']['LivesIn'] != null) {
										if ($new['Location']['LivesIn']['ID'] != "New") { // livesin++ usage
											$cmd = sprintf("UPDATE Locations SET Total = Total + 1 WHERE ID = '%s'", db::escape($new['Location']['LivesIn']['ID']));
											db::query($cmd);
										}
										else { // add once
											$cmd = sprintf("INSERT INTO Locations (Name, Type, Total) VALUES ('%s', '%s', '%s')", db::escape($new['Location']['LivesIn']['Name']), "Location", "1");
											
											$result = db::query($cmd);
											
											if ($result > 0)
												$new['Location']['LivesIn']['ID'] = $result;
										}
										
										if ($new['Location']['LivesIn'] != $info['Location']['LivesIn']) { // journal
											$user->update('livesin', $new['Location']['LivesIn']);
										}
									}
									
									if ($new['Location']['BornIn'] != null) {
										if ($new['Location']['BornIn']['ID'] != "New") { // ++ bornin usage
											$cmd = sprintf("UPDATE Locations SET Total = Total + 1 WHERE ID = '%s'", db::escape($new['Location']['BornIn']['ID']));
											db::query($cmd);
										}
										else { // add once
											$cmd = sprintf("INSERT INTO Locations (Name, Type, Total) VALUES ('%s', '%s', '%s')", db::escape($new['Location']['BornIn']['Name']), "Location", "1");
											
											$result = db::query($cmd);
											
											if ($result > 0)
												$new['Location']['BornIn']['ID'] = $result;
										}
										
										if ($new['Location']['BornIn'] != $info['Location']['BornIn']) { // journal
											$user->update('bornin', $new['Location']['BornIn']);
										}
									}
								}
								
								$final = $new['Location'] != null ? utility::json_encode($new['Location']) : "{}"; // JSON_ESCAPE_UNICODE
								$cmd = sprintf("UPDATE Users SET Location = '%s' WHERE ID = '%s'", $final, $user->id);
								db::query($cmd);
							}
							
							if ($new['Gender'] != null) {
								if ($new['Gender'] != $info['Gender']) {
									$cmd = sprintf("UPDATE Users SET Gender = '%s' WHERE ID = '%s'", db::escape($new['Gender']), $user->id);
									db::query($cmd);
									
									// journal
								}
							}
							
							if ($new['Privacy'] != null) {
								if ($new['Privacy'] != $info['Privacy']) {
									$cmd = sprintf("UPDATE Users SET Privacy = '%s' WHERE ID = '%s'", utility::json_encode($new['Privacy']), $user->id);
									db::query($cmd);
								}
							}
							
							if ($new['BornAt'] != null) {
								if ($new['BornAt'] != $info['BornAt']) {
									$cmd = sprintf("UPDATE Users SET BornAt = '%s' WHERE ID = '%s'", db::escape($new['BornAt']), $user->id);
									db::query($cmd);
									
									// journal
								}
							}
							
							if ($new['InterestedIn'] != null || $info['InterestedIn'] != null) {
								if ($new['InterestedIn'] != $info['InterestedIn']) {
									if ($new['InterestedIn'] == null)
										$new['InterestedIn'] = "";
									else
										$user->update("interestedin");
										
									$cmd =  sprintf("UPDATE Users SET InterestedIn = '%s' WHERE ID = '%s'", db::escape($new['InterestedIn']), $user->id);
									db::query($cmd);
									
									// journal
								}
							}
							
							if ($new['Languages'] != null || $info['Languages'] != null) {
								if ($new['Languages'] != $info['Languages']) {
									$total = count($new['Languages']);
									
									if ($total > 0) {
										for($i = 0; $i < $total; $i++) {
											$lang =& $new['Languages'][$i];
											
											if ($lang['ID'] == "New") {
												$cmd = sprintf("INSERT INTO Languages (Name, Total) VALUES ('%s', '%s')", $lang['Name'], "1");
												$result = db::query($cmd);
												
												if ($result > 0) {
													$lang['ID'] = $result;
												}
											}
										}
									}
									
									if ($new['Languages'] == null)
										$new['Languages'] = array();
									else
										$user->update('languages');
										
									$cmd = sprintf("UPDATE Users SET Languages = '%s' WHERE ID = '%s'", utility::json_encode($new['Languages']), $user->id);
									db::query($cmd);
								}
							}
							
							if ($new['About'] != null || $info['About'] != null) {
								if ($new['About'] != $info['About']) {
									if ($new['About'] == null)
										$new['About'] = "";
									else
										$user->update('about');
										
									$cmd = sprintf("UPDATE Users SET About = '%s' WHERE ID = '%s'", db::escape($new['About']), $user->id);
									db::query($cmd);
								}
							}
							
							$list = array(true);
							
						break;
						
						case "picture": 
							$json = json_decode($_POST['preview'], true);
							$user = utility::getuserfromid($beholderid);
							
							$old = $user->get('picture-info');
							
							if ($json != null) {
								if ($json['Source'] == null && $json['Coords'] != null) { // resize midi 
									if (file_exists($old['Preview']['Source']) && file_exists($old['Original'])) {
										$midi = utility::scale($old['Preview']['Source'], str_replace("[Preview]", "[Midi]", $old['Preview']['Source']), 50, 50, "profile-midi", $json['Coords']);
										
										$old['Preview']['Coords'] = $json['Coords'];
										$old['Midi'] = $midi;
										$cmd = sprintf("UPDATE Users SET Profile = '%s' WHERE ID = '%s'", utility::json_encode($old), $user->id);
										db::query($cmd);
										$list = array(true);
									}
									else {
										$list = array(false, "Resizing midi file was not found");
									}
									
								}
								else if ($json['Source']) { // new pic, new midi, new original, move
									if (is_file($json['Source']) && file_exists($json['Source'])) {
										$original = str_replace("[Preview]", "", $json['Source']);
										$preview = $json['Source'];
										$midi = utility::scale($json['Source'], str_replace("[Preview]", "[Midi]", $json['Source']), 50, 50, "profile-midi", $json['Coords']);
										
										$original = utility::move($original, "upload/photo");
										$preview = utility::move($preview, "upload/photo");
										$midi = utility::move($midi, "upload/photo");
										
										$json['Source'] = $preview;
										
										$value = array("Original" => $original, "Preview" => $json, "Midi" => $midi);									
										$user->update("profile", $value);
										
										$list = array(true, array("Source" => $json['Source'], "Width" => $json['Width'], "Height" => $json['Height'], "Coords" => $json['Coords']));
									}
									else
										$list = array(false, "Given file wasn't found on server");
								}
								else
									$list = array(false, "Some bad things happened");
							}
							else
								$list = array(false, "No json input at all.");
						
						break;
					}
					
					break;
				case "add-friend-req":
					$author = utility::getuserfromid($authorid);
					$beholder = utility::getuserfromid($beholderid);
					
					if ($author->isfriendwith($beholder) == "False") {
						$cmd = sprintf("INSERT INTO FriendRequests (AuthorID, BeholderID, CreatedAt, Status, LastUpdatedAt) VALUES ('%s', '%s', '%s', '%s', '%s');", $authorid, $beholderid, utility::now(), "Pending", utility::now());
						
						$result = db::query($cmd);
						
						if ($result > 0) {
							$list = array(true);
							$event = array("ID" => $result, "Type" => "FriendRequest", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "IsNoticed" => "False");
							$beholder->notify($event, $author); // notify beholder that he got a friend request
						}
						else
							$list = array(false, "Couldn't create friendrequest");
					}
					else
						$list = array(false, "They seem to be in a friendship somehow");
							
					break;
				case "rem-friend-req":
					$author = utility::getuserfromid($authorid);
					$beholder = utility::getuserfromid($beholderid);
					
					$friendstatus = $author->isfriendwith($beholder);
					
					if ($friendstatus == "Pending") {
						$cmd = sprintf("DELETE FROM FriendRequests WHERE AuthorID = '%s' and BeholderID = '%s' and Status = 'Pending';", $authorid, $beholderid);
						db::query($cmd);
					
						$list = array(true);
					}
					else
						$list = array(false);
						
					break;
					
				case "app-friend-req":
					$author = utility::getuserfromid($authorid);
					$beholder = utility::getuserfromid($beholderid);
					
					$friendstatus = $beholder->isfriendwith($author);
					
					if ($friendstatus == "Response") {
						$cmd = sprintf("UPDATE FriendRequests SET Status = '%s', LastUpdatedAt = '%s' WHERE AuthorID = '%s' AND BeholderID = '%s'", "Approved", utility::now(), $author->id, $beholder->id); 
						db::query($cmd);
						
						$cmd = sprintf("SELECT ID, Type, AuthorID, BeholderID FROM FriendRequests WHERE AuthorID = '%s' AND BeholderID = '%s' LIMIT 1;", $author->id, $beholder->id);
						$row = db::fetch(db::query($cmd));
						
						
						if ($row > 0) {
							$freq = new friendrequest();
							$freq->id = $row['ID'];
						
							$cmd = sprintf("INSERT INTO FriendShips (BaseID, TargetID, CreatedAt, RequestID, LastUpdatedAt) VALUES ('%s', '%s', '%s', '%s', '%s'), ('%s', '%s', '%s', '%s', '%s');",
											$author->id, $beholder->id, utility::now(), $freq->id, utility::now(),
											$beholder->id, $author->id, utility::now(), $freq->id, utility::now());
											
							$result = db::query($cmd);
							
							if ($result > 0) {	
								$list = array(true);
								$event = array("Type" => "FriendApproval", "Author" => array("ID" => $beholder->id, "Name" => $beholder->name, "Surname" => $beholder->surname, "Midi" => $beholder->avatar('midi')), "IsNoticed" => "False");														
								$author->notify($event, $beholder, $freq); // notify author that his request got accepted
							}
							else
								$list = array(false, "Some error occurred while becoming friends");
						}
						else
							$list = array(false, "Some error occurred while updating friendrequest");
					}
					else
						$list = array(false, "Unauthorized access while updating friendrequest");
						
					break;
					
				case "rej-friend-req":
					$author = utility::getuserfromid($authorid);
					$beholder = utility::getuserfromid($beholderid);
					
					$friendstatus = $beholder->isfriendwith($author);
					
					if ($friendstatus == "Response") {
						$cmd = sprintf("DELETE FROM FriendRequests WHERE AuthorID = '%s' AND BeholderID = '%s'", $author->id, $beholder->id);
						db::query($cmd);
						
						$list = array(true);
					}
					else
						$list = array(false, "Unauthorized access while deleting friendrequest");
						
					break;
					
				case "sync-friend-reqs": // syncronize friendreq notifications
					$author = utility::getuserfromid($authorid);
					$json = json_decode($_POST['json'], true);
					
					if (count($json) > 0) {
						$last = end($json);
						$imploded = "";
						
						foreach($json as $frid) { // friend-req id
							if ($frid != $last)
								$imploded .= db::escape($frid) .", ";
							else
								$imploded .= db::escape($frid);
						}
						
						$cmd = sprintf("UPDATE FriendRequests SET IsNoticed = 'True' WHERE ID IN (%s) AND BeholderID = '%s'", $imploded, $author->id);
						db::query($cmd);
					}

					$list = array(true);
					break;
					
				case "rem-friend":
					$friend_req_id = 0;
					
					$cmd = sprintf("SELECT RequestID FROM FriendShips WHERE (BaseID = '%s' AND TargetID = '%s') OR (BaseID = '%s' AND TargetID = '%s')", $authorid, $beholderid, $beholderid, $authorid);
					
					$row = db::fetch(db::query($cmd));
					
					if ($row['RequestID'] > 0) {
						$friend_req_id = $row['RequestID'];
						
						$cmd = sprintf("DELETE FROM FriendRequests WHERE ID = '%s'", $friend_req_id);
						db::query($cmd);
						
						$cmd = sprintf("DELETE FROM FriendShips WHERE (BaseID = '%s' AND TargetID = '%s') OR (BaseID = '%s' AND TargetID = '%s')", $authorid, $beholderid, $beholderid, $authorid);
						
						db::query($cmd);
					
						$list = array(true);
					}
					else
						$list = array(false, "Something went bad, while trying to unfriend");
						
					break;
					
				case "add-message": // sending message
					$beholder = utility::getuserfromid($beholderid);
					$author = utility::getuserfromid($authorid);
					
					$cmd = sprintf("INSERT INTO Messages (AuthorID, BeholderID, Value, CreatedAt) VALUES ('%s', '%s', '%s', '%s')", $authorid, $beholderid, $value, utility::now());
					
					$result = db::query($cmd);
					
					if ($result > 0) {
						$list = array(true);
						
						$event = array("Type" => "Message", "Author" => array("ID" => $author->id, "Name" => $author->name, "Surname" => $author->surname, "Midi" => $author->avatar('midi')), "Value" => substr($value, 15));														
						$beholder->notify($event, $author, null); // notify beholder that he got a message
					}
					else
						$list = array(false);
						
					break;
					
				case "ret-messages-info": // retrieval of messages for the jewel
					$author = utility::getuserfromid($authorid);

					if ($value == "true") {
						$cmd = sprintf("UPDATE Messages SET IsNoticed = 'True' WHERE BeholderID = '%s'", $author->id);
						db::query($cmd);
					}
					
					$messages_info = $author->get('message-info');
					$output = array();

					if ($messages_info != null) {
						$output['Count'] = $messages_info['Count'];
						$output['Messages'] = array();
						
						foreach($messages_info['Messages'] as $message) {
							$output['Messages'][] = array("Type" => "Message", "ID" => $message->id, "LastMessageByUser" => $message->lastmessagebyuser, "IsNoticed" => $message->isnoticed, "Value" => substr($message->value, 0, 20), "Countdown" => utility::countdown($message->createdat), "Target" => array("ID" => $message->target->id, "Name" => $message->target->name, "Surname" => $message->target->surname, "Midi" => $message->target->avatar("midi")));
						}
						
						$list = $output;
					}
					else
						$list = array(false);
						
					break;
					
				case "ret-notifications-info": // only get no notified setter unlike ret-message-info =)
					$author = utility::getuserfromid($authorid);
					
					$notifications_info = $author->get('notification-info');
					$output = array();
					
					if ($notifications_info != null) {
						$output['Count'] = $notifications_info['Count'];
						$output['Notifications'] = array();
						
						foreach($notifications_info['Notifications'] as $notification) {
							$output['Notifications'][] = array("Type" => "Notification", "ID" => $notification->id, "IsNoticed" => $notification->isnoticed, "Countdown" => $notification->get('icon') . utility::countdown($notification->createdat), "Author" => array("ID" => $notification->author->id, "Name" => $notification->author->name, "Surname" => $notification->author->surname, "Midi" => $notification->author->avatar("midi")), "Href" => $notification->get("href"), "ObjectID" => $notification->objectid, "ObjectType" => $notification->objecttype, "Story" => $notification->get('story'));
						}
						
						$list = $output;
					}
					else
						$list = array(false);
						
					break;
				
				case "sync-notifications": // syncronize notifications
					$author = utility::getuserfromid($authorid);
					$json = json_decode($_POST['json'], true);
					
					if (count($json) > 0) {
						$last = end($json);
						$imploded = "";
						
						foreach($json as $noid) { // friend-req id
							if ($noid != $last)
								$imploded .= db::escape($noid) .", ";
							else
								$imploded .= db::escape($noid);
						}
						
						$cmd = sprintf("UPDATE Notifications SET IsNoticed = 'True' WHERE ID IN (%s) AND BeholderID = '%s'", $imploded, $author->id);
						db::query($cmd);
						
						$list = array(true);
					}
					else
						$list = array(false);

					
					break;
					
				case "get-all-comments":
					$author = utility::getuserfromid($authorid);
					$post = utility::getobject($objectid, "Post");
					$post->viewer = $author;
					$list = wall::ajax_all_comments_callback($post);
				
					break;
			}
		}
	}

	echo(str_replace("\\\\", "\\", utility::json_encode($list)));
?>