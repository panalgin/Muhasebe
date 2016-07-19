<div class="profile-edit-left">
		<ul>
			<li <?php $act == "basic" ? print("class=\"active\"") : ""; ?> ><a href="?act=basic"><i class="basic-item"></i>Temel Bilgiler <img id="basic-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "picture" ? print("class=\"active\"") : ""; ?> ><a href="?act=picture"><i class="pictures-item"></i>Profil Resmi <img id="picture-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "relations" ? print("class=\"active\"") : ""; ?> ><a href="?act=relations"><i class="relations-item"></i>Arkadaşlar ve Aile <img id="relations-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "eduwork" ? print("class=\"active\"") : ""; ?> ><a href="?act=eduwork"><i class="eduwork-item"></i>Eğitim ve İş <img id="eduwork-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "philosophy" ? print("class=\"active\"") : ""; ?> ><a href="?act=philosophy"><i class="philosophy-item"></i>Felsefe <img id="philosophy-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "activities" ? print("class=\"active\"") : ""; ?> ><a href="?act=activities"><i class="activities-item"></i>Hobiler<img id="activities-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "entertainment" ? print("class=\"active\"") : ""; ?> ><a href="?act=entertainment"><i class="entertainment-item"></i>Sanat ve Eğlence <img id="entertainment-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "sports" ? print("class=\"active\"") : ""; ?> ><a href="?act=sports"><i class="sports-item"></i>Spor <img id="sports-load" src="img/ajax-load.gif"></a></li>
			<li <?php $act == "contacts" ? print("class=\"active\"") : ""; ?> ><a href="?act=contacts"><i class="contacts-item"></i>İletişim <img id="contacts-load" src="img/ajax-load.gif"></a></li>
		</ul>
</div>
<script type="text/javascript">
	$(document).ready(function() {
		$("div.profile-edit-left").on("click", "a", function(event) {
			event.preventDefault();
			event.stopPropagation();
			
			var act = $(this).attr('href').replace(/\?act=/g, "");
			$('img#' + act + "-load").css("display", "block");
			Select(act);
		});
	});
	
	function Invalidate() {
		$('li').removeClass('active');
	}
	
	function Select(segment) {
		var pagelet = "profile-edit-" + segment;
		
		$.ajax({
			type: 'GET',
			url: 'inc/pagelet.php?p=' + pagelet,
			cache: false,
			success: function(data) {
				if (data) {
					Invalidate();
					if ($('div#profile-edit-hold').html() != data) {			
						$('div#profile-edit-hold').html(data);
					}
					
					$('img#' + segment + "-load").css("display", "none");
					
					var curtab = $("li > a[href='?act=" + segment + "']").parent();
						
					if (curtab.hasClass('active') == false)
							curtab.addClass('active');
					
				}
			}
		});
	}
</script>