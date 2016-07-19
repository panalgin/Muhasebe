<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");

class message {
	public $id = 0;
	public $type = "Message";
	public $createdat;
	public $value;
	public $baseid;
	public $target = null;
	public $lastmessagebyuser = "";
	
	function __construct() {
	}
	
	function __destruct() {
	}
}
?>