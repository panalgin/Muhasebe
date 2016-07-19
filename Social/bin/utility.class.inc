<?php
require_once("db_wrapper.class.inc");
require_once("config.class.inc");
require_once("user.class.inc");
require_once("like.class.inc");
	
abstract class utility {

	static function getfixedtitle($page) {
		return config::title . " - " . $page;
	}
	
	static function now() {
		date_default_timezone_set("Asia/Istanbul");
		return date("Y-m-d H:i:s");
	}
	
	static function past($ago) {
		date_default_timezone_set("Asia/Istanbul");
		return date("Y-m-d H:i:s", strtotime($ago));
	}
	
	static function gettimestamp($date) {
		$date = date_create($date);
		return date_format($date, 'U');
	}
	
	///	TODO: Session Hash Algorithm
	///
	///
	static function getcurrentuser() {		
		if (isset($_SESSION['ID'])) {
			$user = null;
			$id = (int)$_SESSION['ID'];
			$user = self::getuserfromid($id); 
			
			return $user;
		}
		else
			return null;
	}
	
	static function getobject($id, $type) {
		$object = null;
		
		switch($type) {
			case "Post":
				$cmd = sprintf("SELECT ID, AuthorID, BeholderID, BeholderType, Value, PostType, CreatedAt FROM Posts WHERE ID = '%s'", $id);
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$object = new post();
					$object->id = $row['ID'];
					$object->authorid = $row['AuthorID'];
					$object->beholderid = $row['BeholderID'];
					$object->beholdertype = $row['BeholderType'];
					$object->posttype = $row['PostType'];
					$object->value = $row['Value'];
					$object->createdat = $row['CreatedAt'];
				}
				
				break;
				
			case "Comment":
				$cmd = sprintf("SELECT ID, AuthorID, BeholderID, BeholderType, Value, ObjectID, ObjectType, CreatedAt FROM Comments WHERE ID = '%s'", $id);
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$object = new comment();
					$object->id = $row['ID'];
					$object->authorid = $row['AuthorID'];
					$object->beholderid = $row['BeholderID'];
					$object->beholdertype = $row['BeholderType'];
					$object->objectid = $row['ObjectID'];
					$object->objecttype = $row['ObjectType'];
					$object->value = $row['Value'];
					$object->createdat = $row['CreatedAt'];
				}
				
				break;
				
			case "Like":
				$cmd = sprintf("SELECT ID, AuthorID, BeholderID, BeholderType, ObjectID, ObjectType, CreatedAt FROM Likes WHERE ID = '%s'", $id);
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$object = new like();
					$object->id = $row['ID'];
					$object->authorid = $row['AuthorID'];
					$object->beholderid= $row['BeholderID'];
					$object->beholdertype = $row['BeholderType'];
					$object->objectid = $row['ObjectID'];
					$object->objecttype = $row['ObjectType'];
					$object->createdat = $row['CreatedAt'];
				}
				
				break;
				
			case "Message":
				$cmd = sprintf("SELECT ID, BaseID, TargetID, Value, CreatedAt FROM Messages WHERE ID = '%s'", $id);
				$result = db::query($cmd);
				
				while($row = db::fetch($result)) {
					$object = new message();
					$object->id = $row['ID'];
					$object->value = $row['Value'];
				}
				
				break;
				
			case "None":
				$object = null;
				break;
		}
		
		return $object;
	}
	
	static function getuserfromid($id, $parameters="") {
		$id = intval($id);
		$cmd = "SELECT ID, Email, Name, Surname, Gender, CreatedAt, BornAt FROM Users WHERE ID = '$id' LIMIT 1";
		$row = db::fetch(db::query($cmd));
		
		$user = new user();
		$user->id = $row['ID'];
		$user->email = $row['Email'];
		$user->name = $row['Name'];
		$user->surname = $row['Surname'];
		$user->gender = $row['Gender'];
		$user->createdat = $row['CreatedAt'];
		$user->bornat = $row['BornAt']; // BornIn olarak değişecek
		
		switch($parameters) {
			case "galleries":
				$user->get("galleries"); break;
		}
		
		return $user;
	}
	static function getusername($id) {
		if ($id > 0) {
			$cmd = "SELECT Username FROM Users WHERE ID = '" . $id . "'";
			
			$result = db::query($cmd);
			$rows = db::first($result);
			$row = $rows[0];
			
			if ($result != null) {
				return $row;
			}
			else
				return "undefined";	
		}
		else if ($id == 0) {
			return "root";
		}
		else
			return "undefined";
	}
	
	static function redirect($address) {
		header("location: $address");
	}
	
	//Used too many date_create, fix it
	static function countdown($date) {
		$now = self::now();
		$difference = strtotime($now) - strtotime($date);
		
		$periods = array("saniye", "dakika", "saat", "gün", "hafta", "ay", "yıl");
		$lengths = array("60","60","24","7","4.35","12");
	 
		if ($difference > 0)
			$tense = 'önce';
		else
			$tense = 'gelecekte';
	 
		$count = count($lengths);
		for($j = 0; $difference >= $lengths[$j] && $j < $count - 1; $j++) {
			$difference /= $lengths[$j];
		}
	 
		$difference = round($difference);
		
		if ($j == 3) {
			if ($difference == 1)
				return "Dün, " . date_format(date_create($date), "H:i");
			else {
				$day = date_format(date_create($date), "N");
				$search = array("1", "2", "3", "4", "5", "6", "7");
				$replace = array("Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar");
				$day = str_replace($search, $replace, $day);
				
				$time = date_format(date_create($date), "H:i");
				return sprintf("%s, %s", $day, $time);
			}
		}
		else if ($j > 3) {
			$month = date_format(date_create($date), "n");
			$search = array("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12");
			$replace = array("Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık");
			$month = str_replace($search, $replace, $month);
			$day = date_format(date_create($date), "j");
			$year = date_format(date_create($date), "Y");
			
			if ($year == date_format(date_create($now), "Y"))
				return sprintf("%s %s", $day, $month);
			else
				return sprintf("%s %s %s", $day, $month, $year);
		}
		else {
			if ($difference == 0 && $j == 0)
				return "Az önce";
			else
				return "$difference $periods[$j] $tense ";
		}
	}
	
	static function scale($oldpath, $newpath, $width, $height, $type = "", $coords = "") {
		$extension = "." . pathinfo($oldpath, PATHINFO_EXTENSION);
		
		if ($extension == ".jpg" || $extension == ".jpeg")
			$image = imagecreatefromjpeg($oldpath);

		else if ($extension == ".png")
			$image = imagecreatefrompng($oldpath);
		
		$old_x = imagesx($image);
		$old_y = imagesy($image);
		
		$widthRatio = $old_x / $width;
		$heightRatio = $old_y / $height;
		
		$thumb_w = $old_x;
		$thumb_h = $old_y;
		
		if ($type == "profile-preview") {
			if ($old_x >= $width) {
				$thumb_w = $width;
				$thumb_h = $old_y / $widthRatio;
			}
			
			$source = array("Source" => $newpath, "Width" => intval($thumb_w), "Height" => intval($thumb_h));
		}
		else if ($type == "profile-midi") {
			$thumb_w = 50;
			$thumb_h = 50;
		}
		else {
			if ($widthRatio > $heightRatio)	{
				$thumb_w = $width;
				$thumb_h = $old_y / $widthRatio;
			}
			else {
				$thumb_h = $height;
				$thumb_w = $old_x / $heightRatio;
			}
		}
		
		$thumb = imagecreatetruecolor($thumb_w, $thumb_h);
		
		if ($extension == ".png") {
			$trnprt_indx = imagecolortransparent($image);
			
			if ($trnprt_indx >= 0) {
				$trnprt_color = imagecolorsforindex($image, $trnprt_indx);
				$trnprt_indx = imagecolorallocate($thumb, $trnprt_color['red'], $trnprt_color['green'], $trnprt_color['blue']);

				imagefill($thumb, 0, 0, $trnprt_indx);
				imagecolortransparent($thumb, $trnprt_indx);
			} 

			imagealphablending($thumb, false);
			$color = imagecolorallocatealpha($thumb, 0, 0, 0, 127);
			imagefill($thumb, 0, 0, $color);
			imagesavealpha($thumb, true);
		}

		$src_x = 0;
		$src_y = 0;
		
		if ($type == "profile-midi") {
			if ($coords['Strech'] == "False") {
				$src_x = $coords['X'];
				$src_y = $coords['Y'];
				$old_x = $coords['Width'];
				$old_y = $coords['Height'];
			}
		}
		
		imagecopyresampled($thumb, $image, 0, 0, $src_x, $src_y, $thumb_w, $thumb_h, $old_x, $old_y); 

		if($extension == ".png")
			imagepng($thumb, $newpath, -1); 
		else
			imagejpeg($thumb, $newpath, 100); 

		imagedestroy($thumb); 
		imagedestroy($image); 
		
		if ($type == "profile-preview")
			return $source;
		else
			return $newpath;
	}
	
	static function in_js_en(&$item, $key) { 
		if (is_string($item)) 
			$item = mb_encode_numericentity($item, array (0x80, 0xffff, 0, 0xffff), 'UTF-8'); 
	}
			
	static function json_encode($arr)
	{
		array_walk_recursive($arr, "utility::in_js_en");
		return mb_decode_numericentity(json_encode($arr), array (0x80, 0xffff, 0, 0xffff), 'UTF-8');
	}
	
	static function move($old, $new) {
		if (file_exists($old)) {
			$base = pathinfo($old, PATHINFO_BASENAME);
			$target = $new . "/" . $base;
			rename($old, $target);
			
			return $target;
		}
		else
			return ""; // Handle this error
	}
	
	static function searchable($value) {
		mb_strtolower($value, "UTF-8");
		$from = array("i" => "(i|ı)", "ı" => "(ı|i)", "ç" => "(ç|c)", "c" => "(c|ç)", "ğ" => "(ğ|g)", "g" => "(g|ğ)", "s" => "(s|ş)", "ş" => "(ş|s)", "o" => "(o|ö)", "ö" => "(ö|o)", "u" => "(u|ü)", "ü" => "(ü|u)");
		$value = strtr($value, $from);
		
		return $value;
	}
}
?>