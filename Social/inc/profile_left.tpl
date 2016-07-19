<div class="profile-left">
	<?php if ($target->id == $user->id): ?>
		<script type="text/javascript">
			$(document).ready(function() {
				$("div.pre-profile").mouseover(function() {
					$("div.change-profile-pic").css("display", "block");
				}).mouseout(function() {
					$("div.change-profile-pic").css("display", "none");
				});
			});
		</script>
	<?php endif; ?>
	<script type="text/javascript">
		$(document).ready(function() {
			$("div.profile-left ul").on("click", "a", function(event) {
				event.preventDefault();
				event.stopPropagation();
				
				var act = $(this).attr('href').replace(/\?id=<?php print $target->id; ?>&act=/g, "");
				$('img#' + act + "-load").css("display", "block");
				Select(act);
			});
			
			$("a#see-all-friends").click(function(event) {
				event.preventDefault();
				
				$("i.relations-item").parent().click();
			});
		});
		
		function Invalidate() {
			$('div.profile-left li').removeClass('active');
		}
		
		function Select(segment) {
			var pagelet = "profile-" + segment;
			
			$.ajax({
				type: 'GET',
				url: 'inc/pagelet.php?p=' + pagelet + '&uid=<?php print $user->id; ?>&tid=<?php print $target->id; ?>',
				cache: true,
				async: true,
				success: function(data) {
					if (data) {
						Invalidate();
						var curtab = $("div.profile-left li > a[href='?id=<?php print $target->id; ?>&act=" + segment + "']").parent();
						if (curtab.hasClass('active') == false)
							curtab.addClass('active');
								
						if ($('div.profile-main').html() != data) {			
							$('div.profile-main').html(data);
						}
						
						$('img#' + segment + "-load").css("display", "none");
							
						
					}
				}
			});
		}
	</script>
	<div class="pre-profile">
		<?php if ($target->id == $user->id): ?>
		<div class="change-profile-pic">
			<a href="profile-edit.php?act=picture"><img src="img/edit.png" /> Resmi Düzenle</a>
		</div>
		<?php endif; ?>
		<a href="profile.php?id=<?php print($target->id); ?>" title="">
			<img class="preview" src="<?php print($target->avatar("pre")); ?>" alt="<?php printf("%s %s", $target->name, $target->surname); ?>" />
		</a>
	</div>
	<ul>
		<li <?php $act == "wall" ? print("class=\"active\"") : ""; ?> ><a href="?id=<?php print($target->id); ?>&act=wall"><i class="wall-item"></i>Duvar <img id="wall-load" src="img/ajax-load.gif"></a></li>
		<li <?php $act == "basic" ? print("class=\"active\"") : ""; ?> ><a href="?id=<?php print($target->id); ?>&act=basic"><i class="basic-item"></i>Bilgiler <img id="basic-load" src="img/ajax-load.gif"></a></li>
		<li <?php $act == "photos" ? print("class=\"active\"") : ""; ?> ><a href="?id=<?php print($target->id); ?>&act=photos"><i class="pictures-item"></i>Fotoğraflar <img id="photos-load" src="img/ajax-load.gif"></a></li>
		<li <?php $act == "videos" ? print("class=\"active\"") : ""; ?> ><a href="?id=<?php print($target->id); ?>&act=videos"><i class="videos-item"></i>Videolar <img id="videos-load" src="img/ajax-load.gif"></a></li>
		<li <?php $act == "friends" ? print("class=\"active\"") : ""; ?> ><a href="?id=<?php print($target->id); ?>&act=friends"><i class="relations-item"></i>Arkadaşlar <img id="friends-load" src="img/ajax-load.gif"></a></li>
	</ul>
	<?php
		$friends = array();
		$friends = $target->get("friends-mini");
		$count = $target->get("friends-total");
		
		if ($count > 0): ?>
			<div class="friends-hold">
				<div class="header">Arkadaşlar (<?php print $count; ?>) <a href="#" id="see-all-friends">Tümü</a></div>
				<div class="content">
					<?php
						foreach($friends as $friend): ?>
							<div class="item">
								<div class="left">
									<a class="avatar" href="profile.php?id=<?php print($friend->id); ?>"><img class="midi" src="<?php print($friend->avatar("midi")); ?>" alt="<?php printf("%s %s", $friend->name, $friend->surname); ?>" /></a>
								</div>
								<div class="right">
									<a class="user" href="profile.php?id=<?php print($friend->id); ?>"><?php printf("%s %s", $friend->name, $friend->surname); ?></a>
									
								</div>
							</div>
					<?php
						endforeach; ?>
				</div>
			</div>
	<?php
		endif; ?>
</div>