<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class friendrequest {
	
	public $id = 0;
	public $author = null;
	public $beholder = null;
	public $isnoticed = "False";
	public $createdat = null;
	public $type = "FriendRequest";

	function __construct() {
	
	}
	
	function __destruct() {
	
	}
}
?>