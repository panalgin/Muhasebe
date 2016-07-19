<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class like {
	
	public $id = 0; // gets setted internally
	public $authorid;
	public $createdat;
	public $beholderid;
	public $beholdertype;
	public $objectid;
	public $objecttype;
	public $type = "Like";
	
	function __construct() {
	
	}
	
	function submit() {
		$cmd = sprintf("INSERT INTO Likes (AuthorID, CreatedAt, ObjectID, ObjectType, BeholderID, BeholderType) VALUES ('%s', '%s', '%s', '%s', '%s', '%s')", $this->authorid, $this->createdat, $this->objectid, $this->objecttype, $this->beholderid, $this->beholdertype);
						
		$result = db::query($cmd);
						
		if ($result > 0) {
			$this->id = $result;
		}
	}
}
?>