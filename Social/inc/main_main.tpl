<div class="main-main">
<?php	
	$page = "";
	$target = null;
	
	if ($act == "news") $page = "main-news";
	else if ($act == "picture") $page = "main-picture";
	else if ($act == "messages") {
		if ($_GET['cid'] != null && $_GET['cid'] > 0) {
			$cid = db::escape($_GET['cid']);
			$target = utility::getuserfromid($cid);
			$page = "main-conversation";
		}
		else
			$page = "main-messages";
	}
	else $page = "main-news";
	require_once("pagelet.php");
?>
</div>