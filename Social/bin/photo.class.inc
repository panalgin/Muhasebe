<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class photo {
	public $id = 0;
	public $type = "Photo";
	public $originalpath;
	public $previewpath;
	public $thumbnailpath;
	public $createdat;
	public $beholderid;
	public $beholdertype;
	public $galleryid;
	
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
			$cmd = sprintf("SELECT ID, Type, OriginalPath, PreviewPath, ThumbnailPath, CreatedAt, BeholderID, BeholderType, GalleryID FROM Photos WHERE ID = '%s'", $this->id);
			$row = db::fetch(db::query($cmd));
			
			$this->type = $row['Type'];
			$this->originalpath = urldecode($row['OriginalPath']);
			$this->previewpath = urldecode($row['PreviewPath']); // need url decode ? not really
			$this->thumbnailpath = urldecode($row['ThumbnailPath']);
			$this->createdat = $row['CreatedAt'];
			$this->beholderid = $row['BeholderID'];
			$this->beholdertype = $row['BeholderType'];
			$this->galleryid = $row['GalleryID'];
		}
		catch(Exception $ex) {
			die($e->getMessage());
		}
	}
	function submit() {
		try {					
			$cmd = sprintf("INSERT INTO Photos (Type, OriginalPath, PreviewPath, ThumbnailPath, CreatedAt, BeholderID, BeholderType, GalleryID) VALUES ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')", 
							$this->type, $this->originalpath, $this->previewpath, $this->thumbnailpath, $this->createdat, $this->beholderid, $this->beholdertype, $this->galleryid);
			
			$pid = db::query($cmd); // photoid
			
			if ($pid != 0)
				$this->id = $pid;
		}
		catch(Exception $e) {
			die($e->getMessage());
		}	
	}
}
?>