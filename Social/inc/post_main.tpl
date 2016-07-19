<div class="post-main">
<?php
	if (isset($_GET['id']) && $_GET['id'] > 0) {
		$pid = (int) $_GET['id'];
		
		require_once("main_wall.tpl");
	}
?>
</div>