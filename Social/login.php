<?php 
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/user.class.inc");
	require_once("bin/mailer.class.inc");
	
	$now = utility::now();
	
	$title = utility::getfixedtitle("Giriş Yap");
	
	if ($_POST['submit'] == "Giriş") {
		$user = new user();
		$user->email = db::escape($_POST['Email']);
		$user->password = db::escape($_POST['Password']);
		
		if ($user->login()) {
			utility::redirect("index.php");
		}
		else
			utility::redirect("login.php?do=wrongpw");
	}
	else if ($_GET['do'] == 'logout') {
		$user = utility::getcurrentuser();
		$user->logout();
	}
	
	require_once("inc/index_top.tpl");
	require_once("inc/index_main.tpl");
	require_once("inc/index_foot.tpl");
?>