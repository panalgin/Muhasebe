<?php
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/user.class.inc");
	require_once("bin/mailer.class.inc");
	require_once("bin/wall.class.inc");
	
	$now = utility::now();
	
	$title = utility::getfixedtitle("Anasayfa");
	
	if ($_POST['submit'] != null && $_POST['submit'] == "Kaydol") {
		$cmd = "SELECT * FROM Users WHERE Email = '". db::escape($_POST['Email']) . "'";
		$result = db::count(db::query($cmd));
		
		if ($result > 0) {
			utility::redirect("index.php");
		}
		else {
			$user = new user();
			$user->name = db::escape($_POST['Name']);
			$user->surname = db::escape($_POST['Surname']);
			$user->email = db::escape($_POST['Email']);
			$user->password = db::escape($_POST['Password']); // security::hash($_POST['Password']);
			$user->createdat = date("Y-m-d H:i:s", time());
			$user->gender = db::escape($_POST['Gender']);
			$user->bornat = date("Y-m-d", mktime(0, 0, 0, db::escape($_POST['Month']), db::escape($_POST['Day']), db::escape($_POST['Year'])));
			$user->submit();
			
			mailer::send($user, "Welcome");
			if ($user->login("silent"))
				utility::redirect("index.php");
			else
				utility::redirect("login.php?do=wrongpw");
		}
	}
	
	if ($_SESSION['ID'] != null && isset($_SESSION['ID']) && $_SESSION['ID'] > 0) {
		$user = utility::getcurrentuser();
		
		$act = db::escape($_GET['act']);
		
		if ($act == "")
			$act = "news";
		
		require_once("inc/main_top.tpl");
		require_once("inc/main_left.tpl");
		require_once("inc/main_main.tpl");
		require_once("inc/main_right.tpl");
		require_once("inc/main_foot.tpl");
	}
	else {
		require_once("inc/index_top.tpl");
		require_once("inc/index_main.tpl");
		require_once("inc/index_foot.tpl");
	}
?>