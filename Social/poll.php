<?php	
	ini_set('max_execution_time', '30');
	set_time_limit(0);
	session_start();
	
	require_once("bin/db_wrapper.class.inc");
	require_once("bin/utility.class.inc");

	$user = utility::getcurrentuser();
		
	if ($user == null)
		exit;
	else {
		$time = time();
		$user->update("online");
		
		if ($user->id > 0) {
			while((time() - $time) < 26) {
				$events = glob("poll/user-".$user->id.".p");
				if ($events != null && is_array($events) && count($events) > 0) {
					$name = $events[0];
					
					if (is_readable($name)) {
						$event = json_decode(file_get_contents($name));
						echo utility::json_encode($event);
						
						if (is_readable($name))
							unlink($name);
							
						unset($event);
						break;
					}
				}
				
				unset($events);
				session_write_close();
				usleep(500000);
			}
			exit;
		}
		else
			exit;
	}
?>