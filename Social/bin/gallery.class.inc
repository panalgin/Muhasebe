<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class gallery {
	public $id = 0;
	public $type = "Gallery";
	public $name;
	public $createdat;
	public $beholderid;
	public $beholdertype;
	
	function __construct() {
	}
	
	function __destruct() {
	}
	
	function submit() {
		try {
			$cmd = sprintf("INSERT INTO Galleries (Type, Name, CreatedAt, BeholderID, BeholderType) VALUES ('%s', '%s', '%s', '%s', '%s')", 
							$this->type, $this->name, $this->createdat, $this->beholderid, $this->beholdertype);
			
			$gid = db::query($cmd); // galleryid
			
			if ($gid != 0)
				$this->id = $gid;
		}
		catch(Exception $e) {
			die($e->getMessage());
		}			
	}
}
?>