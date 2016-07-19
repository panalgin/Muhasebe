<div class="main-right">
	<div class="pymk-hold">
		<div class="header">Tanıyor Olabileceklerin</div>
		<div class="content">
			<?php
				if ($user == null)
					$user = utility::getcurrentuser();
				
				$people = array();
				$people = $user->get("acquaintances");
				
				if (count($people) > 0):
					foreach($people as $person): ?>
						<div class="item">
							<div class="left">
								<a class="avatar" href="profile.php?id=<?php print($person->id); ?>"><img class="midi" src="<?php print($person->avatar("midi")); ?>" alt="<?php printf("%s %s", $person->name, $person->surname); ?>" /></a>
							</div>
							<div class="right">
								<a class="user" href="profile.php?id=<?php print($person->id); ?>"><?php printf("%s %s", $person->name, $person->surname); ?></a>
								<br />
								<span><?php print($person->acquaintance_count); ?> ortak arkadaş</span>
								<br />
								<img src="img/add-friend.png" /><a id="person-<?php print $person->id; ?>" href="#">Arkadaşı Ekle</a>
							</div>
						</div>
				<?php
					endforeach;
				else:
					echo("<img src='img/user-edit.png' class='x32' />Şuan size önerebileceğimiz birilerini bulamadık."); 
				endif; ?>
		</div>
	</div>
	<script type="text/javascript">var uid = <?php print($user->id); ?>;</script>
	<script type="text/javascript" src="js/kibris.pymk.js"></script>
</div>