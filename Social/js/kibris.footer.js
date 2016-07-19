var lp = null;

$(window).unload(function() {
	if (lp)
		lp.abort();
});

$(document).ready(function() {
	if (lp) {
		lp.abort();
		Poll();
	}
	else
		Poll(); //setTimeout("Poll()", 0);
});

function Poll() {
	if (lp)
		lp.abort();
		
	lp = null;
	lp = $.ajax({
				cache: false,
				timeout: 25000,
				url: "poll.php",
				type: "GET",
				async: true,
				data: 	{ 
							"ac": Math.random()
						},
				error: function(x, t, m) {
							if (t == "timeout")
								Poll();
						},
				success: function(response) {
					if (response) {
						var json = $.parseJSON(response);
						
						if (json.Type == "FriendRequest") {
							$(".friends-drop .content").prepend("<div class=\"drop-element new\">" +
							"<div class='left'>" +
							"<a href='profile.php?id=" + json.Author['ID'] +"' class='avatar'><img class='midi' src='" + json.Author['Midi'] + "' alt='" + json.Author['Name'] + " " + json.Author['Surname'] + "' /></a>" +
							"<a href='profile.php?id=" + json.Author['ID'] +"' class='user'><span>" + json.Author['Name'] + " " + json.Author['Surname'] + "</span></a>" +
							"</div>" +
							"<div class='right'>" +
							"<input type='hidden' value='" + escape($.toJSON(json)) + "' />" +
							"<div id='app-friend-button' class='button-white'><img src='img/add-friend.png' />Onayla</div>" +
							"</div>" +
							"</div>");
							
							if ($(".friends-drop .content .drop-element").length == 1)
								$(".friends-drop .content .drop-element").addClass("last");
							
							var count = $(".friends-drop .content .new").length;
							
							if (count > 0)
								$(".jewels #friends-jewel").next().text(count).removeClass('hidden').css('display', 'block');
							
							$(".notifier-pop").html("<div class='left'>" +
							"<a class='avatar' href='profile.php?id=" + json.Author['ID'] + "'><img class='midi' src='" + json.Author['Midi'] + "' alt='" + json.Author['Name'] + " " + json.Author['Surname'] +"' /></a>" +
							"</div>" +
							"<div class='right'>" +
							"<a class='user' href='profile.php?id=" + json.Author['ID'] + "'><span>" + json.Author['Name'] + " " + json.Author['Surname'] +"</span></a> sizinle arkadaş olmak istiyor</div>").css("display", "block").animate({ opacity : 1.0 }, 'slow').delay(3000).animate( { opacity : 0.0, display : 'none' }, 'slow');
						}
						
						else if (json.Type == "FriendApproval" || json.Type == "Post" || json.Type == "Comment" || json.Type == "Like") {
							RetrieveNotifications();
						}
						
						else if (json.Type == "Message") {
							RetrieveMessages("None");
						}
					}
					
					Poll();	
				} 
			});
}