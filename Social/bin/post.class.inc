<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");
require_once("comment.class.inc");
require_once("photo.class.inc");
require_once("video.class.inc");

class post {
	
	public $id = 0; // gets setted internally
	public $authorid;
	public $createdat;
	public $value;
	public $beholderid;
	public $beholdertype;
	public $posttype;
	public $attachmentid = 0;
	public $attachmenttype = "";
	public $attachment = null;
	public $comments;
	public $likes;
	public $likedby;
	public $haslikedbycurrent = false;
	public $viewer = null;
	public $type = "Post";
	
	function __construct($params = null, $viewer = null) {
		if (is_array($params)) {
			$this->id = $params[0];
			$this->authorid = $params[1];
			$this->createdat = $params[2];
			$this->value = $params[3];
			$this->beholderid = $params[4];
			$this->beholdertype = $params[5];
			$this->posttype = $params[6];
			$this->attachmentid = $params[7];
			$this->attachmenttype = $params[8];
			$this->likes = $params[9];
			
			$this->author = new user();
			$this->author->id = $this->authorid;
			$this->author->name = $params[10];
			$this->author->surname = $params[11];
			$this->author->gender = $params[12];
			$this->author->profile = $params[13];
			
			if ($params[14] > 0)
				$this->haslikedbycurrent = true;
				
			if ($this->attachmenttype == "Photo") {
				$photo = new photo($this->attachmentid);
				$this->attachment = $photo;
			}
			else if ($this->attachmenttype == "Video") {
				$video = new video($this->attachmentid);
				$this->attachment = $video;
			}
			
			if ($viewer != null && get_class($viewer) == "user")
				$this->viewer = $viewer;
			
			$this->getcomments();
		}
	}
	
	function __destruct() {
		unset($this->comments);
		unset($this->likedby);
	}
	
	/*function fetch() {
		try {
			$cmd = sprintf("SELECT ID, AuthorID, CreatedAt, Value, BeholderID, BeholderType, PostType, AttachmentID, AttachmentType FROM Posts WHERE ID = '%s'", $this->id);
			$row = db::fetch(db::query($cmd));
			
			$this->id = $row['ID'];
			$this->authorid = $row['AuthorID'];
			$this->createdat = $row['CreatedAt'];
			$this->value = $row['Value'];
			$this->beholderid = $row['BeholderID'];
			$this->beholdertype = $row['BeholderType'];
			$this->posttype = $row['PostType'];
			$this->attachmentid = $row['AttachmentID'];
			$this->attachmenttype = $row['AttachmentType'];
			
			if ($this->attachmenttype == "Photo") {
				$photo = new photo($this->attachmentid);
				$this->attachment = $photo;
			}
			else if ($this->attachmenttype == "Video") {
				$video = new video($this->attachmentid);
				$this->attachment = $video;
			}
			
			$this->getcomments();
			$this->getlikes();
		}
		catch(Exception $e) {
			die($e->getMessage()); // log it
		}
	}*/
	
	function submit() {
		try {
			$cmd = sprintf("INSERT INTO Posts (AuthorID, CreatedAt, Value, BeholderID, BeholderType, PostType, AttachmentID, AttachmentType) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')", $this->authorid, utility::now(), $this->value, $this->beholderid, $this->beholdertype, $this->posttype, $this->attachmentid, $this->attachmenttype);
					
			$result = db::query($cmd);
			
			if ($result > 0)
				$this->id = $result;
		}
		catch(Exception $e) {
			die($e->getMessage());
		}		
	}
	
	//needs performance improvements, think 1000+ comments on a post?
	function getcomments() {
		try {
			$cmd = sprintf("SELECT Comments.ID, AuthorID, Comments.CreatedAt, Value, BeholderID, BeholderType, ObjectID, ObjectType, (SELECT COUNT(ID) FROM Likes WHERE ObjectID = Comments.ID AND ObjectType = 'Comment' AND BeholderID = Comments.AuthorID AND BeholderType = 'User') as Likes, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, (SELECT COUNT(ID) FROM Likes WHERE Likes.AuthorID = '%s' and Likes.ObjectID = Comments.ID and ObjectType = 'Comment') as HasLiked FROM Comments JOIN Users ON(Users.ID = Comments.AuthorID) WHERE ObjectID = '%s' and ObjectType = '%s' and BeholderID = '%s' and BeholderType = '%s' ORDER BY CreatedAt ASC", $this->viewer->id, $this->id, $this->posttype, $this->beholderid, $this->beholdertype); // CommentsAuthorType
			$result = db::query($cmd);
			$comments = array();
			
			$i = 0;
			while($row = db::fetch($result)) {
				$comment = new comment(array($row['ID'], $row['AuthorID'], $row['CreatedAt'], $row['Value'], $row['BeholderID'], $row['BeholderType'], $row['ObjectID'], $row['ObjectType'], $row['Likes'], $row['AuthorName'], $row['AuthorSurname'], $row['AuthorGender'], $row['AuthorProfile'], $row['HasLiked']));
				$comments[$i] = $comment;
				$i++;
			}
			
			$this->comments = $comments;
		}
		catch(Exception $e) {
			die($e->getMessage()); // log it
		}
	}
	
	function get($param, $viewer, $mode) {
		switch($param) {
			case "liked-by":
				if ($this->likes > 0) {
					if ($this->likes == 1 && $this->haslikedbycurrent) 
						return "Sen bunu beğendin";
					else {
						$this->likedby = array();
						
						$cmd = sprintf("SELECT AuthorID, Users.Name as AuthorName, Users.Surname as AuthorSurname FROM Likes JOIN(Users) ON (Likes.AuthorID = Users.ID) WHERE ObjectID = '%s' AND ObjectType = '%s' AND AuthorID != '%s'", $this->id, $this->posttype, $this->viewer->id);
						
						$result = db::query($cmd);
						
						if (db::count($result) > 0) {
							while($row = db::fetch($result)) {
								$user = new user();
								$user->id = $row['AuthorID'];
								$user->name = $row['AuthorName'];
								$user->surname = $row['AuthorSurname'];
								
								array_push($this->likedby, $user);
							}
							
							$count = count($this->likedby);
							$output = "";
							if ($count < 4) {
								$last = end($this->likedby);
								for($i = 0; $i < $count; $i++) {
									$user = $this->likedby[$i];
										
									$output .= sprintf("<a href=\"profile.php?id=%s\">%s %s</a>", $user->id, $user->name, $user->surname);
									
									if ($user != $last) {
										if (($i + 1) == ($count - 1))
											$output .= " ve ";
										else
											$output .= ", ";
									}
								}
							
								if ($this->haslikedbycurrent) {
									if ($count == 1)
										$output = "Sen ve " . $output . " bunu beğendiniz";
									else
										$output = "Sen, " . $output . " bunu beğendiniz";
								}
								else {
									if ($count == 1)
										$output .= " bunu beğendi.";
									else
										$output .= " bunu beğendiler.";
								}
							}
							else {
								if ($this->haslikedbycurrent)
									$output = sprintf("Sen ve %s kişi bunu beğendiniz", $count);
								else
									$output = sprintf("%s kişi bunu beğendi", $count);
							}
						}
						
						return $output;
					}
				}
				else
					return "none";
				
				//<a href=\"#\" title=\"Bunu beğenenleri gör\">%s kişi</a> bunu beğendi
			
				break;
		}
	}
	
	function getlikes() {
		try {
			$cmd = sprintf("SELECT COUNT(ID) FROM Likes WHERE ObjectID = '%s' and ObjectType = '%s' and BeholderID = '%s' and BeholderType = '%s'", $this->id, $this->posttype, $this->beholderid, $this->beholdertype);
			
			$count = db::first(db::query($cmd));
			$count = $count[0];
			$this->likes = $count;
		}
		catch(Exception $e) {
			die($e->getMessage()); // log it
		}
	}
}
?>