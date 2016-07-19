$(document).ready(function() {
			$('#settings-jewel').mouseover( function() {
				$(this).attr("src", "img/settings-hover.png");
			}).mouseout( function() {
				$(this).attr("src", "img/settings.png");
			}).click( function() {
				if ($('.settings-drop').css('display') == 'none') {
					var offset = $(this).parent('li').offset().left + $(this).parent('li').width();
					$('.settings-drop').css('left', offset - $('.settings-drop').width() + 3 );
					$('#settings-jewel-hold').css('border-bottom', '1px solid #FFF'); 
					$('.settings-drop').css('display', 'block');
				}
				else {
					$('.settings-drop').css('display', 'none');
					$('#settings-jewel-hold').css('border-bottom', '1px solid #141512');
				}
					
				$('#settings-jewel-hold').toggleClass('dropped');
				
			});
			
			$(document).click(function(e) {				
				$('div[class$=drop]').each(function() {
					if ($(this).css('display') == 'block') {
						var offset = $(this).offset();
						offset.right = offset.left + $(this).width();
						offset.bottom = offset.top + $(this).height();
						
						var jewel = $(this).attr('class').replace('drop', 'jewel');
						var mini = $('#' + jewel).parent('li').offset();
						mini.right = mini.left + 21;
						mini.bottom = mini.top + 27;
						
						if (((e.pageX >= offset.left && e.pageX <= offset.right) &&
							(e.pageY >= offset.top && e.pageY <= offset.bottom)) || 
							((e.pageX >= mini.left && e.pageX <= mini.right) &&
							(e.pageY >= mini.top && e.pageY <= mini.bottom))){
							return;
						}
						else {
							$('#' + jewel).focusout();
						}
					}
				});				
			});
			
			$('img#settings-jewel').focusout( function() {
				var drop = $(this).attr('id').replace('jewel', 'drop');	
				$('.' + drop).css('display', 'none');
				$(this).parent('li').css('background-color', '');
				$(this).parent('li').css('border-bottom', '1px solid #141512');
				$(this).parent('li').removeClass('dropped');
			});
			
			$('div.count').mouseover(function() {
				$(this).prev().mouseover();
			}).mousedown(function(e) {
				e.preventDefault();
				e.stopPropagation();
				$('img#notifications-jewel, img#friends-jewel, img#messages-jewel').focusout();
				$(this).prev().mouseup();
			}).mouseout(function() {
				$(this).prev().mouseout();
			});
			//$('#notifications-jewel, #friends-jewel, #messages-jewel').each( function() {
				$('img#notifications-jewel, img#friends-jewel, img#messages-jewel').mouseup( function() {
					var drop = $(this).attr('id').replace('jewel', 'drop');
						
					if ($('.' + drop).css('display') == 'none') {
						var offset = $(this).parent('li').offset();
						$('.' + drop).css('display', 'block');
						$('.' + drop).css('margin-left', offset.left - 1 );
						$(this).parent('li').css('background-color', '#FFF');
						$(this).parent('li').css('border-bottom', '1px solid #FFF');
					}
					else {
						$('.' + drop).css('display', 'none');
						$(this).parent('li').css('background-color', '');
						$(this).parent('li').css('border-bottom', '0px');
					}
						
					$(this).parent('li').toggleClass('dropped');
				}).mouseover( function() {
					if ($(this).parent('li').hasClass('dropped') == false)
						$(this).parent('li').css('background-color', '#1f1f1e');
					else
						$(this).parent('li').css('background-color', '#FFF');
				}).mouseout( function() {
					$(this).parent('li').css('background-color', '');
				}).focusout( function() {
					var drop = $(this).attr('id').replace('jewel', 'drop');	
					$('div.' + drop).css('display', 'none');
					$(this).parent('li').css('background-color', '');
					$(this).parent('li').css('border-bottom', '0px');
					$(this).parent('li').removeClass('dropped');
				});
			//});
		});