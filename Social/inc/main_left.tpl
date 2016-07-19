	<script type="text/javascript">
		$(document).ready(function() {
			$("div.main-left ul").on("click", "a", function(event) {
				event.preventDefault();
				event.stopPropagation();
				
				var act = $(this).attr('href').replace(/\?act=/g, "");
				$('img#' + act + "-load").css("display", "block");
				Select(act);
			});
		});
		
		function Invalidate() {
			$('div.main-left li').removeClass('active');
		}
		
		function Select(segment) {
			var pagelet = "main-" + segment;
			
			$.ajax({
				type: 'GET',
				url: 'inc/pagelet.php?p=' + pagelet,
				cache: true,
				async: true,
				success: function(data) {
					if (data) {
						Invalidate();
						
						var curtab = $("div.main-left li > a[href='?act=" + segment + "']").parent();
						if (curtab.hasClass('active') == false)
							curtab.addClass('active');
								
						if ($('div.main-main').html() != data) {			
							$('div.main-main').html(data);
						}
						
						$('img#' + segment + "-load").css("display", "none");
							
						
					}
				}
			});
		}
	</script>
<div class="main-left">
	<div class="midi-profile">
		<a class="avatar" href="profile.php">
			<img class="midi" src="<?php print($user->avatar("midi")); ?>" alt="<?php printf("%s %s", $user->name, $user->surname); ?>" />
		</a>
		<a class="user" href="profile.php">
			<span><?php printf("%s %s", $user->name, $user->surname); ?></span>
		</a>
		
	</div>
	<div class="frequently-used">
		<b>SIK KULLANILANLAR</b>
		<ul>			
			<li <?php $act == "news" ? print("class=\"active\"") : ""; ?> ><a href="?act=news"><i class="news-item"></i>Haber Kaynağı <img id="news-load" src="img/ajax-load.gif" /></a></li>
			<li <?php $act == "messages" ? print("class=\"active\"") : ""; ?> ><a href="?act=messages"><i class="messages-item"></i>Mesajlar <img id="messages-load" src="img/ajax-load.gif" /></a></li>
			<li <?php $act == "events" ? print("class=\"actibe\"") : ""; ?> ><a href="?act=events"><i class="events-item"></i>Etkinlikler <img id="events-load" src="img/ajax-load.gif" /></a></li>
			<li <?php $act == "photos" ? print("class=\"active\"") : ""; ?> ><a href="?act=photos"><i class="pictures-item"></i>Fotoğraflar <img id="photos-load" src="img/ajax-load.gif" /></a></li>
			<li <?php $act == "videos" ? print("class=\"active\"") : ""; ?> ><a href="?act=videos"><i class="videos-item"></i>Videolar <img id="videos-load" src="img/ajax-load.gif"></a></li>
		</ul>
	</div>
	
	<div class="groups">
		<b>GRUPLAR</b>
		<ul>
			<li><i class="groups-item"></i>Daflan Yazılım Grubu</li>
			<li><i class="groups-item"></i>Php Severler</li>
		</ul>
	</div>
	
	<div class="groups">
		<b>KIBRIS NETWORK</b>
		<ul>
			<li <?php $act == "development" ? print("class=\"active\"") : ""; ?> ><a href="?act=development"><i class="announce-item"></i>Gelişmeler <img id="development-load" src="img/ajax-load.gif" /></a></li>
		</ul>
	</div>
</div>