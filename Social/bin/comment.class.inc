<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class comment {
	
	public $id = 0; // gets setted internally
	public $authorid;
	public $createdat;
	public $value;
	public $beholderid;
	public $beholdertype;
	public $objectid;
	public $objecttype;
	public $likes;
	public $likedby;
	public $author = null;
	public $haslikedbycurrent = false;
	public $type = "Comment";
	
	function __construct($params = null) {
		if (func_num_args() != 0) {
			if (is_array($params)) {
				$this->id = $params[0];
				$this->authorid = $params[1];
				$this->createdat = $params[2];
				$this->value = $params[3];
				$this->beholderid = $params[4];
				$this->beholdertype = $params[5];
				$this->objectid = $params[6];
				$this->objecttype = $params[7];
				$this->likes = $params[8];
				
				$this->author = new user();
				$this->author->id = $this->authorid;
				$this->author->name = $params[9];
				$this->author->surname = $params[10];
				$this->author->gender = $params[11];
				$this->author->profile = $params[12];
				
				if ($params[13] > 0)
					$this->haslikedbycurrent = true;
			}
		}
	}
	
	function __destruct() {
		unset($this->likedby);
	}
	
	function submit() {
		try {
			$cmd = sprintf("INSERT INTO Comments (AuthorID, CreatedAt, Value, ObjectID, ObjectType, BeholderID, BeholderType) VALUES (".
				   "'%s', '%s', '%s', '%s', '%s', '%s', '%s')", $this->authorid, $this->createdat, $this->value, $this->objectid, $this->objecttype, $this->beholderid, $this->beholdertype);
				   
			$this->id = db::query($cmd);
		}
		catch(Exception $e) {
			die($e->getMessage()); // log it
		}
	}
}
?>