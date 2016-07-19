<div class="profile-main-top">
	<div class="cell"><h2><?php printf("%s %s", $target->name, $target->surname); ?></h2></div>
	<div class="toolkit">
		<script type="text/javascript" src="js/boxy.js"></script>
		<script type="text/javascript">
			$(document).ready(function() {					
				$('div#message-button').click( function(event) {
					event.preventDefault();
					
					var template = "<div class='row'><div class='cell left'>Alıcı :</div><div class='cell right'><?php printf("%s %s", $target->name, $target->surname); ?></div></div>" +
					"<div class='row'><div class='cell left'>Mesaj :</div><div class='cell right'><div class='message-wrapper'><textarea id='message-box' spellcheck='false'></textarea></div></div></div>";
								   
					var boxy = Boxy.ask(template, ["Gönder", "İptal"], function(value) {
						if (value == "Gönder") {
							var uid = <?php print($user->id); ?>;
							var tid = <?php print($target->id); ?>;
							var request = $.ajax({
									url: "ajax.php",
									type: "POST",
									dataType: "json",
									contentType: "application/x-www-form-urlencoded;charset=UTF-8",
									data: { 
									"do" : "add-message",
									"value" : $('textarea#message-box').val(),
									"authorid" : uid,
									"beholderid" : tid,
									"beholdertype" : "User" }
							});

							request.done(function(reply) {
								if (reply  == "true") {
								}
							});
						}
					}, {title: "Yeni Mesaj", afterShow: function() { 
						var mozspace = $.browser.mozilla ? 3 : 0;
						$('textarea#message-box').autoResize({
							maxHeight: 400,
							minHeight: 50,
							extraSpace: mozspace
						});
					}});
					
					return false;
				});
			});
		
		</script>
	<?php	 if ($target->id != $user->id): 
				$friendstatus = $user->isfriendwith($target); ?>
				<?php if ($friendstatus== "False"): ?>
					<div class="button-white" id="add-friend-button"><img src="img/add-friend.png">Arkadaşı Ekle</div>
				<?php elseif ($friendstatus == "Pending"): ?>
					<div class="button-white" id="add-friend-button"><img src="img/add-friend.png">İstek Gönderildi</div>
				<?php elseif($friendstatus == "True"): ?>
					<div class="button-white"><img src="img/tick.png">Arkadaşınız</div>
				<?php elseif($friendstatus == "Response"): ?>
					<div class="button-white" id="add-friend-button"><img src="img/add-friend.png">Onayla</div>
				<?php endif; ?>
					<script type="text/javascript">
						$(document).ready(function() {
							$("div#add-friend-button").click(function(event) {
								event.preventDefault();
								
								var uid = <?php print($user->id); ?>;
								var tid = <?php print($target->id); ?>;
								
								if ($(this).html().indexOf("Arkadaşı Ekle") > -1) {
									var request = $.ajax({
											url: "ajax.php",
											type: "POST",
											dataType: "json",
											contentType: "application/x-www-form-urlencoded;charset=UTF-8",
											data: { 
												"do" : "add-friend-req",
												"value" : "none",
												"authorid" : uid,
												"beholderid" : tid,
												"beholdertype" : "User" }
											});

									request.done(function(reply) {
										if (reply  == "true") {
											$("div#add-friend-button").html("<img src=\"img/add-friend.png\">İstek Gönderildi");
										}
									});
								}
								else if ($(this).html().indexOf("İstek Gönderildi") > -1) {
									var template = "<a class=\"avatar\"><img class=\"midi\" src=\"<?php print($target->avatar("midi")); ?>\" alt=\"<?php printf("%s %s", $target->name, $target->surname); ?>\" /></a><a class=\"user\"><span><?php printf("%s %s", $target->name, $target->surname); ?></span></a> <br /> <br /><span>Bu kişiye gönderdiğiniz arkadaşlık isteği silinecek. Devam etmek istiyor musunuz?</span><br /><br />";
									
									Boxy.ask(template, ["Evet", "Hayır"], function(value) {
										if (value == "Evet") {
											var request = $.ajax({
															url: "ajax.php",
															type: "POST",
															dataType: "json",
															contentType: "application/x-www-form-urlencoded;charset=UTF-8",
															data: { 
																"do" : "rem-friend-req",
																"value" : "none",
																"authorid" : uid,
																"beholderid" : tid,
																"beholdertype" : "User" }
															});
											request.done(function(reply) {
												if (reply  == "true") {
													$("div#add-friend-button").html("<img src=\"img/add-friend.png\">Arkadaşı Ekle");
												}
											});
										}
									}, {title: "Arkadaşlık isteğini iptal et"});
									
									return false;
								}
								else if ($(this).html().indexOf("Onayla") > -1) {
									var template = "<a class=\"avatar\"><img class=\"midi\" src=\"<?php print($target->avatar("midi")); ?>\" alt=\"<?php printf("%s %s", $target->name, $target->surname); ?>\" /></a><a class=\"user\"><span><?php printf("%s %s", $target->name, $target->surname); ?></span></a> <br /> <br /><span>Bu kişi sizinle arkadaş olmak istiyor, onaylıyor musunuz?</span><br /><br />";
									
									Boxy.ask(template, ["Onayla", "Reddet", "İptal"], function(value) {
										if (value == "Onayla") {
											var request = $.ajax({
															url: "ajax.php",
															type: "POST",
															dataType: "json",
															contentType: "application/x-www-form-urlencoded;charset=UTF-8",
															data: { 
																"do" : "app-friend-req",
																"value" : "none",
																"authorid" : tid,
																"beholderid" : uid,
																"beholdertype" : "User" }
															});
											request.done(function(reply) {
												if (reply  == "true") {
													$("div#add-friend-button").html("<img src='img/tick.png' alt='Arkadaşınız' />Arkadaşınız").removeAttr('id');
												}
											});
										}
										else if (value == "Reddet") {
											var request = $.ajax({
															url: "ajax.php",
															type: "POST",
															dataType: "json",
															contentType: "application/x-www-form-urlencoded;charset=UTF-8",
															data: { 
																"do" : "rej-friend-req",
																"value" : "none",
																"authorid" : tid,
																"beholderid" : uid,
																"beholdertype" : "User" }
															});
											request.done(function(reply) {
												if (reply  == "true") {
													$("div#add-friend-button").html("<img src='img/add-friend.png' alt='Arkadaşı Ekle' />Arkadaşı Ekle");
												}
											});
										}
									}, {title: "Arkadaşlık İsteğini Onayla"});
								}
								
							});
						});
					</script>
		<?php endif; ?>
		<?php if ($target->id != $user->id): ?>
			<div class="button-white" id="message-button"><img src="img/message-friend.png" alt='Mesaj' />Mesaj</div>
		<?php endif; ?>
	</div>
</div>
<div class="profile-target-info">
	<div class="hold">
	<?php 	if ($user->id == $target->id)	
				$basic_info = $user->get('basic-info');
			else
				$basic_info = $target->get('basic-info'); ?>
				
			<?php if ($basic_info['Languages']) { ?>
			<span><img src="img/language.png" />
			<?php $last = end($basic_info['Languages']); 
					foreach($basic_info['Languages'] as $language):  
						if ($language != $last)
							print($language['Name'] . ", ");
						else
							print($language['Name']);
					endforeach; ?> biliyor </span>
			<?php }	if ($basic_info['Location']['LivesIn']) { ?>
				<span><img src="img/livesin.png" alt="Yaşadığı Yer" />Yaşadığı yer: <a><?php print($basic_info['Location']['LivesIn']['Name']); ?></a></span>
			<?php } if ($basic_info['Location']['BornIn']) { ?>
				<span><img src="img/bornin.png" alt="Doğduğu Yer" />Memleketi: <a><?php print($basic_info['Location']['BornIn']['Name']); ?></a></span>
			<?php } if ($basic_info['BornAt']) { ?>
					<?php if (!$basic_info['Privacy']): ?>
						<span><img src="img/bornat.png" /><?php print($basic_info['BornAt']); ?> tarihinde doğdu</span>
					<?php elseif($basic_info['Privacy']['ShowBirthday'] == "Full"): ?>
						<span><img src="img/bornat.png" /><?php print($basic_info['BornAt']); ?> tarihinde doğdu</span>
					<?php elseif($basic_info['Privacy']['ShowBirthday'] == "DayAndMonth"): ?>
						<span><img src="img/bornat.png" /><?php
						
						$months = array("01" => "Ocak", "02" => "Şubat", "03" => "Mart", "04" => "Nisan", "05" => "Mayıs", "06" => "Haziran", "07" => "Temmuz",
									  "08" => "Ağustos", "09" => "Eylül", "10" => "Ekim", "11" => "Kasım", "12" => "Aralık");
									  
						$birth = date_parse($basic_info['BornAt']);
						$month = $months[sprintf("%02d", $birth['month'])];
						$day = $birth['day'];
						
						printf("%d %s", $day, $month); ?> tarihinde doğdu</span>
					<?php endif; ?>
			<?php } ?>
			<?php if ($user->id == $target->id): ?>
				<img src="img/edit2.png" style="width: 12px; height: 12px;" /><a href="profile-edit.php?act=basic">Düzenle</a>
			<?php endif; ?>
	</div>
</div>