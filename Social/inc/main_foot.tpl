	</div>
	<script type="text/javascript">
		var beholderid  = <?php print($user->id); ?>;
	</script>
	<script type="text/javascript" src="js/kibris.footer.js"></script>
	<script type="text/javascript">
		var _gaq = _gaq || [];
		_gaq.push(['_setAccount', 'UA-29713451-1']);
		_gaq.push(['_trackPageview']);

		(function() {
			var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
			ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
			var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
		})();
	</script>
	<div class="notifier-pop">
		<?php /*<div class="left">
			<a class="avatar" href="profile.php?id=<?php print($user->id); ?>"><img class="midi" src="<?php print($user->avatar("midi")); ?>" alt="<?php printf("%s %s", $user->name, $user->surname); ?>" /></a>
		</div>
			
		<div class="right">
			<a class="user" href="profile.php?id=<?php print($user->id); ?>"><span><?php printf("%s %s", $user->name, $user->surname); ?></span></a> sizinle arkadaş olmak istiyor
		</div> */ ?>
	</div>
	
	<?php print(db::total());
		  //print_r(db::cache()); ?>
		  
</body>
</html>