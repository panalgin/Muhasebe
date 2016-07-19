<?php
require_once("config.class.inc");

class db_adapter {

	/*const server = "localhost";
	const username = "kibrisze_admin";
	const password = "0!2vu{9EbCuT";
	const catalog = "kibrisze_db";*/
	
	const server = "localhost";	
	const username = "daflan_admin";
	const password = "t@dXDN(*J@TT";
	const catalog = "daflan_eset_db";
	
	private $link;
	private $result;
	private $fetch;
	public $total = 0;
	public $queue = array();
	
	public $query_cache = array();
	
	function __construct() {
		$this->connect();
	}
	
	function __destruct() {
	
		$this->close();
	}
	
	function connect() {
		try {
			$this->link = mysql_connect(self::server, self::username, self::password)
				or
			die("error[connect]:" . mysql_error());
			
			if (mysql_select_db(self::catalog)) {
				self::query("SET NAMES 'utf8', CHARACTER SET utf8, COLLATION_CONNECTION = 'utf8_turkish_ci'");
			}
			else
				die("error[cat]:" . mysql_error());
		}
		catch(Exception $e) {
			die($e->getMessage());
		}		
	}
		   	
	public function query($cmd) {
		$debug = config::mode == "debug" ? " [Cmd]: " . $cmd : "";
		
		if (preg_match("/^SELECT/i", $cmd)) {
			$index = $this->search($cmd);
			
			if ($index != -1) {
				$cached = $this->query_cache[$index]; // return cached result
				mysql_data_seek($cached['Result'], 0);
				return $cached['Result'];
				exit;
			}
		}
		
		$this->result = mysql_query($cmd) or die("Error [Query]: " . mysql_error() . $debug);
		array_push($this->query_cache, array("Cmd" => $cmd, "Result" => $this->result));
		
		if (preg_match("/^INSERT/i", $cmd) && $this->result == 1)
			$this->result = mysql_insert_id($this->link);
			
		$this->total += 1;
		array_push($this->queue, $cmd ."\r\n");
		return $this->result;
	}
	
	private function search($cmd) {
	   foreach ($this->query_cache as $key => $val) {
		   if ($val['Cmd'] == $cmd) {
			   return $key;
		   }
	   }
	   
	   return -1;
	}
	
	public function gettotal()
	{
		return $this->total;
	}
	public function getqueue() {
		return $this->queue;
	}
	
	public function getcache() {
		return $this->query_cache;
	}
	
	public function fetch($result) {
		$this->fetch = mysql_fetch_array($result);
		return $this->fetch;
	}
	
	public function count($result) {
		return mysql_num_rows($result);
	}
	
	public function first($result) {
		return mysql_fetch_row($result);
	}
	
	private function close() {
		try {
			if ($this->result != null && is_resource($this->result)) {
				mysql_free_result($this->result);
				mysql_close($this->link);
			}
		}
		catch (Exception $e) {
			
		}
	}

	public function escape($param) {
		return $this->secure($param);
	}
	
	private function secure($string)
	{
		if(get_magic_quotes_gpc()) // prevents duplicate backslashes
		{
			$string = stripslashes($string);
		}
		
		$string = $this->mysql_escape_mimic(htmlspecialchars($string, ENT_QUOTES, "UTF-8"));
		
		return $string; //return the secure string
	}
	
	private function mysql_escape_mimic($inp) { 
		if(is_array($inp)) 
			return array_map(__METHOD__, $inp); 

		if(!empty($inp) && is_string($inp)) { 
			return str_replace(array('\\', "\0", "'", '"', "\x1a"), array('\\\\', '\\0', "\\'", '\\"', '\\Z'), $inp); 
		} 

		return $inp; 
	}
}
?>