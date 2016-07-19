<?php
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/user.class.inc");
	require_once("bin/wall.class.inc");
	
	$now = utility::now();
	
	$title = utility::getfixedtitle("Profil");
	
	$act = "";
	
	if (!empty($_GET['act']) && $_GET['act'] != null)
		$act = db::escape($_GET['act']);
	else
		$act = "wall";
	

	if ($_SESSION['ID'] != null && isset($_SESSION['ID']) && $_SESSION['ID'] > 0) {
	
		$user = utility::getcurrentuser();
		$target = "";
		
		if ($_GET['id'] != null && !empty($_GET['id']) && intval($_GET['id']) > 0) {
			$id = db::escape($_GET['id']);
			
			if ($id == $user->id)
				$target = $user;
			else
				$target = utility::getuserfromid($id);
		}
		else
			$target = $user;
			
		$title = utility::getfixedtitle(sprintf("Profil - %s %s", $target->name, $target->surname));
		
		require_once("inc/main_top.tpl");
		require_once("inc/profile_left.tpl");
		require_once("inc/profile_main_top.tpl");
		require_once("inc/profile_main.tpl");
		require_once("inc/main_right.tpl");
		require_once("inc/main_foot.tpl");
	}
?>