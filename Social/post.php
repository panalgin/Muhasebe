<?php
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/config.class.inc");
	require_once("bin/utility.class.inc");
	require_once("bin/user.class.inc");
	require_once("bin/wall.class.inc");

	if ($_SESSION['ID'] != null && isset($_SESSION['ID']) && $_SESSION['ID'] > 0) {
	
		$user = utility::getcurrentuser();
		
		$title = utility::getfixedtitle(sprintf("Gönderi - %s %s", $user->name, $user->surname));
		
		require_once("inc/main_top.tpl");
		/*require_once("inc/profile_left.tpl");
		require_once("inc/profile_main_top.tpl");
		require_once("inc/profile_main.tpl");*/
		require_once("inc/post_main.tpl");
		require_once("inc/main_right.tpl");
		require_once("inc/main_foot.tpl");
	}
?>