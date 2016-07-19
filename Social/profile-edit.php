<?php
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/user.class.inc");
	
	$now = utility::now();
	
	$title = utility::getfixedtitle("Profil");
	$act = "";
	
	if (!empty($_GET['act']) && $_GET['act'] != null)
		$act = db::escape($_GET['act']);
	else
		$act = "basic";

	if ($_SESSION['ID'] != null && isset($_SESSION['ID']) && $_SESSION['ID'] > 0) {
	
		$user = utility::getcurrentuser();
		$title = utility::getfixedtitle(sprintf("Profil Düzenle - %s %s", $user->name, $user->surname));
		
		require_once("inc/main_top.tpl");
		require_once("inc/profile-edit_left.tpl");
		require_once("inc/profile-edit_main.tpl");
		require_once("inc/main_foot.tpl");
	}
?>