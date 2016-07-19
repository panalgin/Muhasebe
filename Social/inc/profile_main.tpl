<div class="profile-main">
<?php
	session_start();
	
	global $user;
	
	$page = "";
	if ($act == "wall") {
		global $target;
		$page = "profile-wall";	
	}
	else if ($act == "photos") $page = "profile-photos";
	else if ($act == "videos") $page = "profile-videos";
	else if ($act == "friends") {
		global $target;
		$page = "profile-friends";
	}
	else $page = "profile-wall";
	require_once("pagelet.php");
?>
</div>