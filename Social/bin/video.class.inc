<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class video {
	public $id = 0;
	public $type = "Video";
	public $originalpath;
	public $thumbnailpath;
	public $createdat;
	public $beholderid;
	public $beholdertype;
	
	function __construct($id = 0) {
		if ($id > 0) {
			$this->id = $id;
			$this->fetch();
		}
	}
	
	function __destruct() {
	}
	function fetch() {
		try {
			$cmd = sprintf("SELECT ID, Type, OriginalPath, ThumbnailPath, CreatedAt, BeholderID, BeholderType FROM Videos WHERE ID = '%s'", $this->id);
			$row = db::fetch(db::query($cmd));
			
			$this->type = $row['Type'];
			$this->originalpath = urldecode($row['OriginalPath']);
			$this->thumbnailpath = urldecode($row['ThumbnailPath']);
			$this->createdat = $row['CreatedAt'];
			$this->beholderid = $row['BeholderID'];
			$this->beholdertype = $row['BeholderType'];
		}
		catch(Exception $ex) {
			die($e->getMessage());
		}
	}
	function submit() {
		try {					
			$cmd = sprintf("INSERT INTO Videos (Type, OriginalPath, ThumbnailPath, CreatedAt, BeholderID, BeholderType) VALUES ('%s', '%s', '%s', '%s', '%s', '%s')", 
							$this->type, $this->originalpath, $this->thumbnailpath, $this->createdat, $this->beholderid, $this->beholdertype);
			
			$vid = db::query($cmd); // videoid
			
			if ($vid != 0)
				$this->id = $vid;
		}
		catch(Exception $e) {
			die($e->getMessage());
		}	
	}
}
?>