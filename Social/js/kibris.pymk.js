	$("div.pymk-hold .content .right").on("click", "a[id^='person']", function(event) {
		event.preventDefault();
		
		var tid = $(this).attr('id').replace(/person\-/g, "");
		var element = $(this);
		
		if (tid > 0) {
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
						var img = element.prev();
						element.text("İstek Gönderildi");
						img.attr('src', "img/tick.png");
					}
				});
			}
		}
	});