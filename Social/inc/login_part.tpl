<div class="login_con">
	<h2>Daflan'a Giriş</h2>
	<hr />
	<div class="login_hold">
		<?php
			if ($_GET['do'] == "wrongpw") { ?>
		<div class="login_error">
			Girdiğin bilgiler doğru değil. <br />
			Hesabına kayıtlı e-posta ile giriş yapabilirsin. Lütfen bunları doğru yazdığından emin ol.
		</div>
		<?php } ?>
		<form id="login_form" method="POST">
			<div class="row">
				<div class="cell left">
					Email:
				</div>
				<div class="cell right">
					<input name="Email" id="Email" class="login_box" type="text" />
				</div>
			</div>
			<div class="row">
				<div class="cell left">
					Şifre:
				</div>
				<div class="cell right">
					<input name="Password" id="Password" class="login_box" type="password" />
				</div>
			</div>
			<div class="row">
				<div class="cell left">
					&nbsp;
				</div>
				<div class="cell right">
					<input type="checkbox" id="remember-user-2" /> <label for="remember-user-2">Oturumumu açık tut</label>
				</div>
			</div>
			<div class="row">
				<div class="cell left">
					&nbsp;
				</div>
				<div class="cell right">
					<input name="submit" type="submit" class="button nout" value="Giriş" /> ya da <a href="index.php">Kaydol</a>
				</div>
			</div>
		</form>
		<div class="clear"></div>
	</div>
	
</div>