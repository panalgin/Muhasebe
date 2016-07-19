<?php
date_default_timezone_set("Asia/Istanbul");
global $context;

require_once("db_adapter.class.inc");

abstract class db {
	
	static function query($cmd) {
		global $context;
		
		db::singleton();
		return $context->query($cmd);
	}
	
	static function total() {
		global $context;
		
		db::singleton();
		return $context->gettotal();
	}
	
	static function queue() {
		global $context;
		
		db::singleton();
		return $context->getqueue();
	}
	
	static function cache() {
		global $context;
		
		db::singleton();
		return $context->getcache();
	}
	
	static function fetch($result) {
		global $context;
		
		db::singleton();
		return $context->fetch($result);
	}
	
	static function count($result) {
		global $context;
		
		db::singleton();
		return $context->count($result);
	}
	
	static function first($result) {
		global $context;
		
		db::singleton();
		return $context->first($result);
	}
	
	static function escape($param) {
		global $context;
		
		db::singleton();
		return $context->escape($param);
	}
		
	static function singleton() {
		global $context;
		
		if (!isset($context)) {
			$type = 'db_adapter';
			$context = new $type;
		}
	}
}
?>