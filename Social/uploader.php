<?php 
	require_once("bin/utility.class.inc");
	require_once("bin/config.class.inc");
	
	$up_id = uniqid();
	$error = "";
	$preview = false;
	$thumb = "";
	$size = "";
	$type = "";
	$info = "";
	
	if ($_POST) {
		$path = "upload/temp/";
		$name = md5($up_id . rand(0, 100) . utility::now());
		$extension = explode(".", $_FILES["uploaded"]["name"]);
		$extension = strtolower("." . $extension[count($extension) - 1]);
		$type = $_FILES['uploaded']['type'];
		$size = $_FILES['uploaded']['size'];
		
		/*var_dump($_FILES);
			if ($_FILES["uploaded"]["error"] > 0) {
				echo "Error: " . $_FILES["uploaded"]["error"] . "<br />";
			}
			else {
				echo "Upload: " . $_FILES["uploaded"]["name"] . "<br />";
				echo "Type: " . $_FILES["uploaded"]["type"] . "<br />";
				echo "Size: " . ($_FILES["uploaded"]["size"] / 1024) . " Kb<br />";
				echo "Stored in: " . $_FILES["uploaded"]["tmp_name"];
			}*/

		
		if (validateUpload($extension, $type, $size) == true) {
			if (move_uploaded_file($_FILES["uploaded"]["tmp_name"], $path . $name . $extension)) {
				if ($_GET['type'] == "photo") {
					//photo::createThumbnail();
					$thumb = utility::scale($path . $name . $extension, $path . $name . "[Thumb]". $extension, 100, 75);
					$preview = true;
					
					$info = array("OriginalPath" => urlencode($path.$name.$extension),
					"ThumbnailPath" => urlencode($thumb),
					"CreatedAt" => utility::now(),
					"Size" => $size,
					"Type" => $type);
				}
				else if ($_GET['type'] == "profile") {
					$thumb = utility::scale($path . $name . $extension, $path . $name . "[Preview]" . $extension, 240, 180, "profile-preview");
					$preview = false;
					
					$info = array("OriginalPath" => $path.$name.$extension,
					"Preview" => array("Source" => $thumb['Source'],
									   "Width" => $thumb['Width'],
									   "Height" => $thumb['Height']),
					"CreatedAt" => utility::now(),
					"Size" => $size,
					"Type" => $type);
				}
				else if ($_GET['type'] == "video") {
					$ffmpeg = "ffmpeg";
					$video  = $path.$name.$extension;
					
					$output = $path.$name."[Thumb].jpg";
						
					$second = 1;
					$duration = "";
					
					// get the duration and a random place within that
					$cmd = "$ffmpeg -i $video 2>&1";
					$return = shell_exec($cmd);
					if (preg_match('/Duration: ((\d+):(\d+):(\d+))/s', $return, $time)) {
						$total = ($time[2] * 3600) + ($time[3] * 60) + $time[4];
						$second = rand(1, ($total - 1));
						
						if (intval($time[2]) != 0)
							$duration = sprintf("%02d:%02d:%02d", $time[2], $time[3], $time[4]);
						else
							$duration = sprintf("%02d:%02d", $time[3], $time[4]);
					}	
					
					$cmd = "$ffmpeg -i $video -deinterlace -s 150x100 -an -ss $second -t 00:00:01 -r 1 -y -vcodec mjpeg -f mjpeg $output 2>&1";
					$retval = "";
					$ff_error = array(); // trace ffmpeg errors
					exec($cmd, $ff_error, $retval);
					
					if (!file_exists($output) && config::mode == "debug")
						$output = "video.jpg";
					
					$image = imagecreatefromjpeg($output);
					
					$font = "data/monofont.ttf";
					$fontsize = 11;
					$angle = 0;
					
					$bbox = imagettfbbox($fontsize, $angle, $font, $duration);
					$width = abs($bbox[2] - $bbox[0]);
					$height = abs($bbox[7] - $bbox[1]);
					$x = imagesx($image) - $width;
					$y = imagesy($image) - $height;
					
					$trans = imagecolorallocatealpha($image, 0, 0, 0, 25);
					imagefilledrectangle($image, $x - 6, $y - 6, imagesx($image) - 3, imagesy($image) - 3 , $trans);
						
					$color = imagecolorallocate($image, 255, 255, 255);
					imagettftext($image, $fontsize, $angle, $x - 4, imagesy($image) - 4, $color, $font, $duration);
						
					// Save the image (overwrite)
					imagejpeg($image, $output, 100);
					imagedestroy($image);
					
					$preview = true;
					$thumb = $output;
					
					$info = array("OriginalPath" => urlencode($path.$name.$extension),
					"ThumbnailPath" => urlencode($thumb),
					"CreatedAt" => utility::now(),
					"Size" => $size,
					"Type" => $type,
					"Duration" => $duration);
				}
			}
		}
	}
	
	function validateUpload($extension, $type, $size) {
		global $error;
		
		if ($_GET['type'] == "photo" || $_GET['type'] == "profile") {
			if (!($type == "image/jpeg" || $type == "image/png")) {
				$error = "Yüklediğiniz dosya uygun değil. Geçerli dosyalar: jpeg, png";
				return false;
			}
			else if ($size / (1024 * 1024) > 4) {
				$error = "Yüklediğiniz dosyanın boyutu 4mb'tan büyük.";
				return false;
			}
			else if ($extension != ".jpg" && $extension != ".png" && $extension != ".jpeg") {
				$error = "Yüklediğiniz dosyanın uzantısı geçerli değil.";
				return false;
			}
			else
				return true;
		}
		else if ($_GET['type'] == "video") {
			if (!($type == "video/mp4" || $type == "video/x-flv" || $type == "video/flv" || $type == "video/h264")) {
				$error = "Yüklediğiniz dosya uygun değil. Geçerli dosyalar: .mp4, .h264, .flv";
				return false;
			}
			else if ($size / (1024 * 1024) > 50) {
				$error = "Yüklediğiniz dosyanın boyutu 50mb'tan büyük.";
				return false;
			}
			else if ($extension != ".flv" && $extension != ".h264" && $extension != ".mp4") {
				$error = "Yüklediğiniz dosyanın uzantısı geçerli değil.";
				return false;
			}
			else
				return true;
		}
	}
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="tr"> 
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
	<link type="text/css" rel="stylesheet" href="css/main.css" />
</head>
<body style="background-color: transparent;">
	<script type="text/javascript">
		$ = window.parent.$;
		jQuery = window.parent.jQuery;
		
		$(window).load(function() {
					$('#uploaded', document).mouseover(function() {
						$(this).css('cursor', 'pointer');
						$('.upload-browse', document).css('background-color', '#D1D1D1');
					}).mouseout(function() { $('.upload-browse', document).css('background-color', '#E6E6E6'); });
					
					$('#uploaded', document).change( function(event) {
						var path = $(this).val().split("\\");
						path = path[path.length - 1];
						
						if (path.length > 25)
							path = "..." + path.substr(path.length - 25, 25);
							
						$('#upload-over', document).text(path);
						$(this).attr("readonly", "readonly");
					});
					$('#upload-submit', document).click(function(event) {
						event.preventDefault();
						event.stopPropagation();
						
						if ($(this).is(':animated'))
							return;
						
						
						$('#uploaded', document).attr('readonly', 'readonly');
						
						
						setTimeout("ProgressCallback()", 1000);
						$('#form1', document).submit();
						$(this).attr('readonly', 'readonly');
						
						$(this).off("click").animate({
							opacity: 1.0,
						}, 3000);
					});
		});
		
		function ProgressCallback()
		{
			var request = $.ajax({
								url: "ajax.php?id=Progress&key=<?php echo($up_id); ?>&value=null",
								type: "GET",
								dataType: "json"
						  });
			request.done(function(data) {
				if (data[0] != null || data[0] != 'undefined') {
					if ($('.progress-con', document).hasClass('hidden'))
						$('.progress-con', document).removeClass('hidden');
						
					if (data[2] == "marqueue") {
						if ($('.progress-in', document).css('width') >= $('.progress-in', document).css('max-width'))
							$('.progress-in', document).css('width', '0px');
						else {
							$('.progress-in', document).animate( { 'width' : '+=10px' }, 'fast');
							$('.progress-label', document).text('Yükleniyor');
						}
					}
					else if (parseFloat(data[2]) > 0.0) {
						if (parseInt(data[2]) >= 100)
							$('.progress-in', document).css('width', '100px');
						else {
							$('.progress-in', document).animate( { 'width' : parseInt(data[2]) + 'px' }, 'fast');
							$('.progress-label', document).text('%' + data[2].toFixed(2) + "");
							ProgressCallback();
						}
					}
				}
			});
		}
	</script>
	<?php if ($_POST && $preview == true): ?>
	<div class="upload-preview">
		<?php if ($_GET['type'] == 'photo'): ?>
			<input type="hidden" id="photo-info" value="<?php print(db::escape(json_encode($info))); ?>" />
		<?php elseif ($_GET['type'] == 'video'): ?>
			<input type="hidden" id="video-info" value="<?php print(db::escape(json_encode($info))); ?>" />
		<?php endif; ?>
		<div class="cell left">
			<img src="<?php print($thumb); ?>" />
		</div>
		<div class="cell right">
			Yükleme başarılı.<br />
			Boyut: <?php print(floor($size / 1024) . " kb"); ?><br />
			Tarih: <?php print(utility::now()); ?><br />
			Tür: <?php print($type); ?>
		</div>
	</div>
	<?php else: ?>
		<div class="title">
		<?php if ($error == ""): ?>
			<?php if ($_GET['type'] == "photo" || $_GET['type'] == "profile"): ?>
				Bir fotoğraf seçin.
			<?php elseif ($_GET['type'] == "video"): ?>
				Bir video dosyası yükleyin. [flv, h264, mp4]
			<?php endif; ?>
		<?php else: ?>
			Hata: <?php print($error); ?>
		<?php endif; ?>
		</div>
		<form method="post" enctype="multipart/form-data" name="form1" id="form1">		
			<?php if (function_exists("uploadprogress_get_info")): ?>
			<input type="hidden" name="UPLOAD_IDENTIFIER" id="pecl-upload-identifier" value="<?php echo $up_id; ?>" /> 
			<?php endif; ?>
			
			<input id="uploaded" name="uploaded" class="file" type="file" /> <div id="upload-over" class="upload-over"></div>
			<div class="upload-browse"><img src="img/magnifier.png" />Gözat</div> <input id="upload-submit" name="submit2" class="button-black" type="button" value="Yükle" />
			<div id="upload-progress" class="progress-con hidden">
				<div class="progress-in"></div>
			</div>
			<div class="progress-label"></div>
		</form>
	<?php endif; ?>
	
	<?php if ($_POST): ?>
	<script type="text/javascript">
		$(window, document).load( function() {
			DelayedFix();
			//setTimeout("DelayedFix()", 100);
		});
		function DelayedFix() {
			<?php if ($_GET['type'] == "photo"): ?>
				$('#sc-photo-frame').animate( { 'height' : $('.upload-preview', document).css('height') }, 'slow');
			<?php elseif ($_GET['type'] == "video"): ?>
				$('#sc-video-frame').animate( { 'height' : $('.upload-preview', document).css('height') }, 'slow');
			<?php elseif ($_GET['type'] == "profile"): ?>
				$('#image-info').val(escape('<?php 
				
				print(utility::json_encode(array("Source" => $info['Preview']['Source'],
												 "Width" => $info['Preview']['Width'],
												 "Height" => $info['Preview']['Height']))); ?>')).change();
			
			<?php endif;
				  if (strlen($error) == 0 && $_GET['type'] != "profile"): ?>
						$('#share-button').removeClass('disabled').removeAttr('disabled');
			<?php endif; ?>
			
		}
	</script>
	<?php endif; ?>
</body>
</html>