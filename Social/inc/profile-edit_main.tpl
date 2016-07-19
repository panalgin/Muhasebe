<script type="text/javascript" src="js/sublay.js"></script>

<div class="profile-edit-main">
	<div class="profile-edit-header"><a href="profile.php"><?php print($user->name . " " . $user->surname); ?></a><img src="img/right-arrow.png" />Profil Düzenle</div>
	<div id="profile-edit-hold">
<?php 	$page = "";
		if ($act == "basic") $page = "profile-edit-basic";
		else if ($act == "picture") $page = "profile-edit-picture";
		else if ($act == "relations") $page = "profile-edit-relations";
		else if ($act == "eduwork") $page = "profile-edit-eduwork";
		else if ($act == "philosopy") $page = "profile-edit-philosophy";
		else if ($act == "activities") $page = "profile-edit-activities";
		else if ($act == "entertainment") $page = "profile-edit-entertainment";
		else if ($act == "sports") $page = "profile-edit-sports";
		else if ($act == "contacts") $page = "profile-edit-contacts";
		else $page = "profile-edit-basic";
		require_once("pagelet.php");
?>
	</div>
</div>