<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class notification {
	public $id = 0;
	public $type = "Notification";
	public $createdat;
	public $author = null;
	public $isnoticed;
	public $objectid;
	public $objecttype;
	public $parentid;
	public $parenttype;
	
	function __construct() {
	}
	
	function __destruct() {
	}
	
	function get($param) {
		switch($param) {
			case "story":
				$story = "";
				
				if ($this->objecttype == "FriendApproval")
					$story .= "arkadaşlık isteğinizi kabul etti.";
				else if ($this->objecttype == "Post")
					$story .= "duvarınızda bir gönderi paylaştı.";
				else if ($this->objecttype == "Comment") {
					if ($this->parenttype == "Status")
						$story .= "bir gönderinize yorum yaptı.";
					else if ($this->parenttype == "Status|Photo")
						$story .= "fotoğraflı bir gönderinize yorum yaptı.";
					else if ($this->parenttype == "Status|Video")
						$story .= "videolu bir gönderinize yorum yaptı.";
					else if ($this->parenttype == "Action")
						$story .= "bir güncelleminiz hakkında yorum yaptı.";
					else if ($this->parenttype == "Photo")
						$story .= "bir fotoğrafınıza yorum yaptı.";
					else if ($this->parenttype == "Video")
						$story .= "bir videonuza yorum yaptı.";
				}
				else if ($this->objecttype == "Like") {
					if ($this->parenttype == "Comment")
						$story .= "bir yorumunuzu beğendi.";
					else if ($this->parenttype == "Status")
						$story .= "bir gönderinizi beğendi.";
					else if ($this->parenttype == "Status|Photo")
						$story .= "fotoğraflı bir gönderinizi beğendi.";
					else if ($this->parenttype == "Status|Video")
						$story .= "videolu bir gönderinizi beğendi.";
					else if ($this->parenttype == "Action")
						$story .= "bir güncelleminizi beğendi.";
					else if ($this->parenttype == "Photo")
						$story .= "bir fotoğrafınızı beğendi.";
					else if ($this->parenttype == "Video")
						$story .= "bir videonuzu beğendi..";
				}
				else if ($this->objecttype == "Tag") {
					$story .= "sizi bir fotoğrafta etiketledi.";
				}
				
				// relationship request
				// event invite
				// page access given
			
				return $story;
				break;
			
			case "icon":
				$icon = "";
				if ($this->objecttype == "FriendApproval")
					$icon = "<img src='img/add-friend.png' alt='Onaylandınız' />";
				else if ($this->objecttype == "Post")
					$icon = "<i class='status-item'></i>";
				else if ($this->objecttype == "Comment")
					$icon = "<img src='img/message-friend.png' alt='Yorum' />";
				else if ($this->objecttype == "Like")
					$icon = "<img src='img/like.png' alt='Beğenildi' />";
				else if ($this->objecttype == "Tag")
					$icon = "<img src='img/tag.png' alt='Etiketlendi' />";
					
				// relationship request
				// event invite
				// page access given
				
				return $icon;
				break;
				
			case "href":
				$href = "notifications.php";
				
				switch($this->objecttype) {
					case "FriendApproval":
						$href = "profile.php?id=" . $this->author->id;
					break;
					
					case "Post":
						$href = "post.php?id=" . $this->objectid;						
					break;
					
					case "Comment":
						$comment = utility::getobject($this->objectid, "Comment");
						
						if ($comment->objecttype == "Status" || $comment->objecttype == "Status|Photo" || $comment->objecttype == "Status|Video")
							$href = "post.php?id=" . $comment->objectid;
						else if ($comment->objecttype == "Photo")
							$href = "photo.php?id=" . $comment->objectid;
						else if ($comment->objecttype == "Video")
							$href = "video.php?id=" . $comment->objectid;
					break;
					
					case "Like":
						$like = utility::getobject($this->objectid, "Like");
						
						if ($like->objecttype == "Status" || $like->objecttype == "Status|Photo" || $like->objecttype == "Status|Video")
							$href = "post.php?id=" . $like->objectid;
						else if ($like->objecttype == "Photo")
							$href = "photo.php?id=" . $like->objectid;
						else if ($like->objecttype == "Video")
							$href = "video.php?id=" . $like->objectid;
						else if ($like->objecttype == "Comment") {
							$comment = utility::getobject($like->objectid, "Comment");
						
							if ($comment->objecttype == "Status" || $comment->objecttype == "Status|Photo" || $comment->objecttype == "Status|Video")
								$href = "post.php?id=" . $comment->objectid;
							else if ($comment->objecttype == "Photo")
								$href = "photo.php?id=" . $comment->objectid;
							else if ($comment->objecttype == "Video")
								$href = "video.php?id=" . $comment->objectid;
						}
					break;
					
					case "Tag":
						// find tagged photo or post, or comment ? link to resource
					break;
				}
				
				return $href;
			break;
		}
	}
}
?>