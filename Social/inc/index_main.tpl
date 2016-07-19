	<?php 
		$script = $_SERVER['SCRIPT_NAME']; 
		$script = explode('/', $script);
		$script = $script[count($script) - 1];
		$script = ucfirst(str_replace(".php", "", $script));
		
		switch($script) {
			case "Index":
				require_once("inc/register_part.tpl");
				break;
			case "Login":
				require_once("inc/login_part.tpl");
				break;
		}
		
	?>
	<div class="clear"></div>
	</div> <!-- Wrapper End -->