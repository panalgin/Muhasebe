<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="tr"> 
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
	<link type="image/x-icon" rel="icon" href="img/kibris.ico"  />
	<link type="image/x-icon" rel="shortcut icon" href="img/kibris.ico" />
	<link type="text/css" rel="stylesheet" href="css/main.css" />
	<link type="text/css" rel="stylesheet" href="css/validationEngine.jquery.css" />

	<script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/kibris.js"></script>
	<script src="js/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
	<script src="js/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        jQuery(document).ready(function() {
            // binds form submission and fields to the validation engine
            jQuery("#register_form").validationEngine();
        });
        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                // this allows to use i18 for the error msgs
                return options.allrules.validate2fields.alertText;
            }
        }
	</script>
	
	<title><?php echo($title); ?></title>
</head>
<body>
	<div class="top">
		<div class="top-hold">
			<div class="cell" style="width: 250px;">
				<a href="index.php" alt="Anasayfa"><img src="img/logo.png" alt="Kıbrıs Network" title="Anasayfa" /></a>
			</div>
			<div class="top-login">
				<form id="top-login-form" action="login.php" method="POST">
					<div class="cell">
						<input name="Email" class="login_box" type="text" tabindex="1" />
						<br />
						<input class="checkbox" type="checkbox" name="rememberme" id="remember-user" tabindex="4" />
						<label for="remember-user" class="sub">Oturumumu açık tut</label>
					</div>
					<div class="cell">
						<input name="Password" class="login_box" type="password" tabindex="2" />
						<br />
						<a class="sublink" href="login.php?do=lostpw" alt="Şifremi Unuttum">Şifremi unuttum</a>
					</div>
					<div class="cell">
						<input name="submit" class="button" type="submit" value="Giriş" style="width: 50px;" tabindex="3" />
					</div>
				</form>
			</div>
			
		</div>
	</div>
	<div class="wrapper">
		