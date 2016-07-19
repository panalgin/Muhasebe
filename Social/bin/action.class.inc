<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class action {
	
	public $id = 0; // gets setted internally
	public $authorid;
	public $beholderid;
	public $createdat;
	public $updatedat;
	public $type = "Action";
	public $actiontype;
	public $actionvalue;
	public $objectid;
	public $objecttype;
	
	public $author = null;
	public $target = null;
	
	function __construct() {
		
	}
	
	function __destruct() {
	
	}
	
	function submit() {
		try {
			$cmd = sprintf("INSERT INTO Actions (AuthorID, BeholderID, CreatedAt, ActionType, ObjectID, ObjectType, UpdatedAt) VALUES('%s', '%s', '%s', '%s', '%s', '%s', '%s')", $this->authorid, $this->beholderid, $this->createdat, $this->actiontype, $this->objectid, $this->objecttype, utility::now());
			
			$result = db::query($cmd);
			
			if ($result > 0)
				$this->id = $result;
		}
		catch(Exception $e) {
			die($e->getMessage());
		}		
	}
	
	function get($param, $viewer = null) {
		switch($param) {
			case "icon":
				if ($this->actiontype == "FriendApproval")
					return "<img src=\"img/add-friend.png\" alt=\"Arkadaşlık Başladı\" />";
				else if ($this->actiontype == "ProfilePictureChanged")
					return "<img src=\"img/pictures.png\" alt=\"Profil Resimi Değiştirildi\" />";
				else if ($this->actiontype == "LivesInChanged" || $this->actiontype == "BornInChanged" || $this->actiontype == "InterestedInChanged"
						|| $this->actiontype == "LanguagesChanged" || $this->actiontype == "AboutChanged")
					return "<i class=\"basic-item\"></i>";
					
				break;
			case "story":
				if ($this->actiontype == "FriendApproval")
					return sprintf("%s, <a href=\"profile.php?id=%s\">%s %s</a> ile arkadaş oldu.", $this->author->name, $this->target->id, $this->target->name, $this->target->surname);
				else if ($this->actiontype == "ProfilePictureChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return "Profil resminizi değiştirdiniz.";
					else
						return sprintf("%s profil resmini değiştirdi.", $this->author->name);
				}
				else if ($this->actiontype == "LivesInChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return sprintf("Yaşadığınız yeri %s olarak değiştirdiniz.", $this->actionvalue);
					else
						return sprintf("%s yaşadığı yeri %s olarak değiştirdi.", $this->author->name, $this->actionvalue);
				}
				else if ($this->actiontype == "BornInChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return sprintf("Memleketinizi %s olarak değiştirdiniz.", $this->actionvalue);
					else
						return sprintf("%s memleketini %s olarak değiştirdi.", $this->author->name, $this->actionvalue);
				}
				else if ($this->actiontype == "LanguagesChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return sprintf("Bildiğiniz dilleri güncellediniz.", $this->actionvalue);
					else
						return sprintf("%s <a href=\"profile.php?id=%s&act=basic\">bildiği diller</a>i güncelledi.", $this->author->name, $this->author->id);
				}
				else if ($this->actiontype == "InterestedInChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return sprintf("İlgilendiklerinizi değiştirdiniz.", $this->actionvalue);
					else
						return sprintf("%s <a href=\"profile.php?id=%s&act=basic\">ilgilendikleri</a>ni değiştirdi.", $this->author->name, $this->author->id);
				}
				else if ($this->actiontype == "AboutChanged") {
					if ($viewer != null && $viewer->id == $this->target->id)
						return sprintf("Hakkında bölümünü güncellediniz.", $this->actionvalue);
					else
						return sprintf("%s <a href=\"profile.php?id=%s&act=basic\">hakkında</a> içeriğini güncelledi.", $this->author->name, $this->author->id);
				}
					
				break;
		}
	}
}
?>