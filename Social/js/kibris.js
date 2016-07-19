	$(document).ready( function () {
		$('input[type="submit"]').mousedown( function () {
			$(this).css('background-color', '#06a3d1');
		})
		.mouseup( function () {
			$(this).css('background-color', '');
		})
		.mouseout( function () {
			$(this).css('background-color', '#09ADFF');
		})
		.mouseover( function () {
			$(this).css('background-color', '#3bd3ff');
		}); });
