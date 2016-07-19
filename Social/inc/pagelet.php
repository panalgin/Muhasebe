<?php
	if (!empty($_GET['p']) && $_GET['p'] != null)
		$page = $_GET['p'];
	
	$page =  $_SERVER['DOCUMENT_ROOT'] . "/inc/pagelet/" . $page . ".plet";

	if (is_file($page) && file_exists($page))
		require_once($page);
	else {
		echo("<div class=\"error-con\">The page you requested wasn't found on the server.</div>");
		/*print_r($_GET);
		print($page);*/
	}
	
?>