$(document).ready(function() {
					$('#news-hold').on('mousedown', '.post-attachment-hold', function(event) {
						if (event.which != 1 && $.browser.msie == false)
							return; 
							
						event.stopPropagation();
						
						if ($(this).has('.play'))
							$(this).children('.play').attr("src", "img/play-down.png");
					});
					$('#news-hold').on('mouseup', '.post-attachment-hold', function() {
						if ($(this).has('.play') == false)
							return;
							
						if ($(this).is(':animated'))
							return;
									
						$(this).animate({
							opacity: 1.0,
						}, 3000);
							
						$(this).children('img.play').attr("src", "img/play-on.png");
						$(this).children('img.thumbnail, img.play').stop().animate({ opacity: 0.5 }, 'fast');
						$(this).children('img.loading').css('display', 'block');
						var data = $.parseJSON(unescape($(this).closest("div [id^='news']").children("input[id^='post-info']").val()));
						var playerid = 'player-' + data['ID'];
						data['Attachment']['OriginalPath'] = data['Attachment']['OriginalPath'].replace(/\\/g, "");
						var template = "<div class=\"player\" style=\"width:440px;height:0px; background-color: #111; float:left; clear: both;\" id=\"" + playerid + "\" href=\"" + data['Attachment']['OriginalPath'] + "\"></div></div>";
						$(this).after(template);	
						$("#" + playerid).click();
						$(this).off('mousedown').off('mouseup').off('mouseout');
					});
					$('#news-hold').on('mouseout', '.post-attachment-hold', function() {
						if ($(this).has('.play') == false)
							return;
							
						$(this).children('img.play').attr("src", "img/play-on.png");
					});
					$("#news-hold").on("click", "div.player", function(event) {
							event.stopPropagation();
							var id = $(this).attr('id');
							var load = $(this).prev().attr('id', id + "-loading").attr('id');	
							$(this).flowplayer("flash/flowplayer-3.2.7.swf", {
									canvas : {
										backgroundColor: '#000000',
										backgroundGradient: 'none'
									},
									screen:	{
										bottom: 0
									},
									plugins: {
										controls: {
											url: 'flash/flowplayer.controls-3.2.5.swf',
											
											backgroundColor: '#111111',
											backgroundGradient: 'none',
											progressColor: '#71f100',
											progressGradient: 'none',
											bufferColor: '#999999',
											bufferGradient: 'none',
											sliderColor: '#FFFFFF',
											sliderBorder: '1.5px solid rgba(160,160,160,0.7)',
											volumeSliderColor: '#FFFFFF',
											volumeColor: '#71f100',
											volumeBorder: '1.5px solid rgba(160,160,160,0.7)',

											timeColor: '#ffffff',
											timeSeparator:	' /',
											durationColor: '#535353',
											timeFontSize: '11',

											tooltipColor: 'rgba(255, 255, 255, 0.7)',
											tooltipTextColor: '#000000'
										}
									},
									clip: {
										autoBuffering: true,
										autoPlay: true
									}
							});
							$('div#' + load).css('display', 'none');
							$('div#' + id).animate({height:300}, 'slow', function() {
								$(this).css('margin-bottom', '5px').css('background-color', '');
							});
					});
					$('#share-box').autoResize({
						maxHeight: 400,
						minHeight: 70,
						extraSpace: 20
					}).focusout( function() {
						if ($(this).val() == "") {
							$(this).toggleClass('inactive');
							$(this).val("Ne düşünüyorsun?");
						}
					}).focusin( function() {
						if ($(this).hasClass('inactive') && $(this).val() == "Ne düşünüyorsun?") {
							$(this).toggleClass('inactive');
							$(this).val("");
						}
					});
					
					$('a[id^=comment]').live("click", function(e) {
						$('#do-' + $(this).attr('id')).removeClass('disabled');
						var id = '#comment-box' + $(this).attr('id').replace('comment', '');
						$(id).focus();
							
						e.preventDefault();
					});
					
					function GetCommentOutput(data) {
						var output;
						var template = 
							"<input id=\"comment-info-" + data['Comment']['ID'] + "\" type=\"hidden\" value=\"" + data['Info'] + "\" />" +
								"<div class=\"comment-hold\">" +
									"<div class=\"cell left\">" +
										"<a href=\"profile.php?id=" + data['Author']['ID'] + "\">" +
											"<img class=\"mini\" src=\"" + data['Author']['Picture'] + "\" alt=\"" + 
												data['Author']['Name'] + " " + data['Author']['Surname'] + "\" />" +
										"</a>" +
									"</div>" +
									"<div class=\"cell right\">" +
										"<div class=\"comment\">" +
											"<a href=\"profile.php?id=" + data['Author']['ID'] + "\"><span>" + 
												data['Author']['Name'] + " " + data['Author']['Surname'] + "</span></a> " + 
												data['Comment']['Value'] + 
										"</div>" +
										"<div class=\"comment-sub\">" +
											data['Comment']['CreatedAt'] + " - ";
											
							if (data['Comment']['HasLikedByCurrent'] && data['Comment']['HasLikedByCurrent'] == "True")
								template += "<a id=\"like-comment-" + data['Comment']['ID'] + "\" href=\"#\">Beğenmekten Vazgeç</a>";
							else
								template += "<a id=\"like-comment-" + data['Comment']['ID'] + "\" href=\"#\">Beğen</a>";
								
							if (data['Comment']['Likes'] && data['Comment']['Likes'] > 0)
								template += " - <a href='#' id='see-comment-likes-" + data['Comment']['ID'] + "' title='Bu yorumu beğenenleri gör'><img src='img/like.png' alt='Beğeniler' />" + data['Comment']['Likes'] + "</a>";
								
							template +=
										"</div>" +
									"</div>" +
								"</div>";
								
						output = $(template);
								
						return output;
					}
					
					function OnKeyDown(event) {
							if (event.which == 13 && !event.shiftKey) {	
								event.preventDefault();
								event.stopPropagation();
								var id = $(this).attr('id').replace('comment-box-', '');
								
								if ($('#comment-box-' + id).is(':animated'))
									return;
									
								$('#comment-box-' + id).animate({
									opacity: 1.0,
								}, 3000);
									
								if ($(this).val().length > 0) {
									var data = $.parseJSON(unescape($('#post-info-' + id).val()));
									var objectid = data['ID'];
									var objecttype = data['PostType'];
									var beholderid = data['BeholderID'];
									var beholdertype = data['BeholderType'];
									
									if (objectid > 0) {
										$(this).off("keydown");
										var request = $.ajax({
											url: "ajax.php",
											type: "POST",
											dataType: "json",
											contentType: "application/x-www-form-urlencoded;charset=UTF-8",
											data: {'do' : 'add-comment',
												   'authorid' : userid, //'<?php print($user->id); ?>',
												   'value' : $(this).val(),
												   'objectid' : objectid,
												   'objecttype' : objecttype,
												   'beholderid' : beholderid,
												   'beholdertype' : beholdertype }
										});

										request.done(function(data) {
											if (data[0] != null || data[0] != 'undefined') {
												$("#comment-box-" + id).val("");
												
												var output = GetCommentOutput(data);
												$("#do-comment-" + id).before(output);	
												$('#like-comment-' + data['Comment']['ID']).focus();
											}
										});

										request.fail(function(jqXHR, textStatus) {
											alert( "Hata: İsteğinizi gerçekleştiremedik." + textStatus );
										});
										
										$(this).on("keydown", $(this), OnKeyDown);
									}
								}
							}
						}
					
					var triggered = 0;
					var mozspace = $.browser.mozilla ? 3 : 0;
					$('[id^=comment-box]').autoResize({
						maxHeight: 400,
						minHeight: 14,
						extraSpace: mozspace
					}).live("focusout", function() {
						if ($(this).val() == "") {
							$(this).toggleClass('inactive');
							$(this).val("Yorum yaz...");
							
							var id = "#do-comment" + $(this).attr('id').replace('comment-box', '');
							
							$(id).removeClass('on').addClass('off');
						}
					}).live("focusin", function() {
						if ($(this).hasClass('inactive') && $(this).val() == "Yorum yaz...") {
							$(this).toggleClass('inactive');
							$(this).val("");
							
							var id = "#do-comment" + $(this).attr('id').replace('comment-box', '');
							
							$(id).removeClass('off').addClass('on');
						}
					}).live("keydown", $(this), OnKeyDown);
					
					$('[id^=like-post]').live("click", $(this), OnLikeClick);
					$('[id^=like-comment]').live("click", $(this), OnLikeClick);
					
					$('div#news-hold').on("click", "a[id^='post-see-rest'], a[id^='comment-see-rest']", function(event) {
						event.preventDefault();
						
						var target = $(this).parent();
						var data = $.parseJSON(unescape($(this).attr('data')));
						
						if (target.hasClass('comment')) {
							var user = target.children('a').first();
							var clone = user.clone();
							target.html('');
							target.append(clone);
							target.append(" " + data['All']);
							
							user.remove();
						}
						else
							target.html(data['All']);						
					});
					
					$('div#news-hold').on("click", "a[id^='see-all-comments']", function(event) {
						event.preventDefault();
						var id = $(this).attr('id').replace(/see-all-comments-/g, "");
						//alert(id);
						var parent = $(this).parent();
						var hold = parent.closest('div.right');
						var ajaxer = parent.children('img.ajax-load');
						ajaxer.toggle();
						
						var data = $.parseJSON(unescape($("input[id='post-info-" + id + "']").val()));
						var request = $.ajax({
								url: "ajax.php",
								type: "POST",
								dataType: "json",
								contentType: "application/x-www-form-urlencoded;charset=UTF-8",
								data: {'do' : 'get-all-comments',
								'authorid' : userid,
								'value' : 'none',
								'objectid' : data['ID'],
								'objecttype' : data['PostType'] }
						});

						request.done(function(data) {
							if (data[0] != null || data[0] != 'undefined') {
								hold.children("input[type='hidden'], div.comment-hold[id!='do-comment-" + id + "']").remove();
								var i;
								for(i = 0; i < data.length; i++) {
									var element = data[i];
									var output = GetCommentOutput(element);
									$("#do-comment-" + id).before(output);
								}
								
								ajaxer.css('display', 'none');
								parent.css('display', 'none');
							}
						});

						request.fail(function(jqXHR, textStatus) {
							alert( "Hata: İsteğinizi gerçekleştiremedik." + textStatus );
						});
					});
					
					$('#share-box[maxlength]').keyup(function(){  
						var limit = parseInt($(this).attr('maxlength'));  
						var text = $(this).val();   
						var chars = text.length;  
				  
						if(chars > limit){  
							var new_text = text.substr(0, limit); 
							$(this).val(new_text);  
						}  
					});  
					
					
					$('textarea#share-box-fake').mousedown( function(e) {
						e.preventDefault();
						$('a#sp-status-link').click();
					});
					var last_tab = "";
					$('#share-tab a').click( function(e) {
						clear();
						
						var id = $(this).attr('id').replace('img', 'link');

						$('#share-con').removeClass('hidden');
						
						switch(id) {
							case "sp-status-link":
								$('#sp-status-link').addClass('active'); 
								$('#share-box').focus();
								
								$('#share-button').removeAttr('disabled').removeClass('disabled');
								
								last_tab = "Status";
								break;
							
							case "sp-picture-link":
								if (last_tab != "Photo")
									$('#share-button').attr('disabled', 'disabled').addClass('disabled');
								
								$('#sp-picture-link').addClass('active'); 
								$('.sc-photo').removeClass('hidden');
								$('#sc-photo-frame').attr('src', 'uploader.php?type=photo');
																
								last_tab = "Photo";
								break;
								
							case "sp-video-link":
								if (last_tab != "Video")
									$('#share-button').attr('disabled', 'disabled').addClass('disabled');
									
								$('#sp-video-link').addClass('active'); 
								$('.sc-video').removeClass('hidden');
								$('#sc-video-frame').attr('src', 'uploader.php?type=video');
								
								last_tab = "Video";
								break;
						}
						
						id = id.replace('link', 'img');
						$('.sc-arrow').css('margin-left', $('#' + id).position().left - 17);
						e.preventDefault();
					}); 
					
					$('#share-button').on("click", $(this), OnShareClick);
					
					
				});
				
				function clear() {
					$('div.share-con-fake').remove();
					$('a#sp-status-link, a#sp-picture-link, a#sp-video-link').removeClass('active');
					$('div.sc-photo, div.sc-video').addClass('hidden');
				}
				
				function getCurrentTab() {
					if ($('#sp-status-link').hasClass('active'))
						return "Status";
					else if ($('#sp-picture-link').hasClass('active'))
						return "Photo";
					else if ($('#sp-video-link').hasClass('active'))
						return "Video";
				}
				
				
				function OnLikeClick(e) {
					e.preventDefault();
					e.stopPropagation();
					
					var val = $(this).text();
					if ($(this).is(':animated'))
						return;
						
					if (val == "Beğen") {
						if ($(this).attr('id').search(/post/) > -1) {
							
							var id = $(this).attr('id').replace('like-post-', '');
							var data = $.parseJSON(unescape($('#post-info-' + id).val()));
							var objectid = data['ID'];
							var objecttype = data['PostType'];
							var beholderid = data['AuthorID'];
							var beholdertype = data['AuthorType'];				
									
							$(this).off("click").animate({
								opacity: 1.0,
							}, 500);
							
							var request = $.ajax({
								url: "ajax.php",
								type: "POST",
								dataType: "json",
								contentType: "application/x-www-form-urlencoded;charset=UTF-8",
								data: { 'do' : 'like',
									'authorid' : userid, //'<?php print($user->id); ?>',
									'objectid' : objectid,
									'objecttype' : objecttype,
									'beholderid' : beholderid,
									'beholdertype' : beholdertype,
									'value' : 'like'
								}});

							request.done(function(data) {
								if (data[0] != null || data[0] != 'undefined') {
									$("#like-post-" + id).text("Beğenmekten Vazgeç");
									$("#like-post-" + id).on("click", $("#like-post-" + id), OnLikeClick);
								}
							});
						}
						else if ($(this).attr('id').search(/comment/) > -1) {
							var id = $(this).attr('id').replace('like-comment-', '');
							var data = $.parseJSON(unescape($('#comment-info-' + id).val()));
							var objectid = data['ID'];
							var objecttype = "Comment";
							var beholderid = data['AuthorID'];
							var beholdertype = data['AuthorType'];	
							
							$(this).off("click").animate({
								opacity: 1.0,
							}, 1000);
							
							var request = $.ajax({
								url: "ajax.php",
								type: "POST",
								dataType: "json",
								contentType: "application/x-www-form-urlencoded;charset=UTF-8",
								data: { 'do' : 'like',
									'authorid' : userid, //'<?php print($user->id); ?>',
									'objectid' : objectid,
									'objecttype' : objecttype,
									'beholderid' : beholderid,
									'beholdertype' : beholdertype,
									'value' : 'like'
								}});

							request.done(function(data) {
								if (data[0] != null || data[0] != 'undefined') {
									$("#like-comment-" + id).text("Beğenmekten Vazgeç");
									$("#like-comment-" + id).on("click", $("#like-comment-" + id), OnLikeClick);
								}
							});
						
						}
					}
					else if (val == "Beğenmekten Vazgeç") {
						if ($(this).attr('id').search(/post/) > -1) {
							var id = $(this).attr('id').replace('like-post-', '');
							var data = $.parseJSON(unescape($('#post-info-' + id).val()));
							var objectid = data['ID'];
							var objecttype = data['PostType'];
							var beholderid = data['AuthorID'];
							var beholdertype = data['AuthorType'];				
									
							$(this).off("click").animate({
								opacity: 1.0,
							}, 1000);
							
							var request = $.ajax({
								url: "ajax.php",
								type: "POST",
								dataType: "json",
								contentType: "application/x-www-form-urlencoded;charset=UTF-8",
								data: { 'do' : 'unlike',
									'authorid' : userid, //'<?php print($user->id); ?>',
									'objectid' : objectid,
									'objecttype' : objecttype,
									'beholderid' : beholderid,
									'beholdertype' : beholdertype,
									'value' : 'unlike'
								}});

							request.done(function(data) {
								if (data[0] != null || data[0] != 'undefined') {
									$("#like-post-" + id).text("Beğen");
									$("#like-post-" + id).on("click", $("#like-post-" + id), OnLikeClick);
								}
							});
						}
						else if ($(this).attr('id').search(/comment/) > -1) {
							var id = $(this).attr('id').replace('like-comment-', '');
							var data = $.parseJSON(unescape($('#comment-info-' + id).val()));
							var objectid = data['ID'];
							var objecttype = "Comment";
							var beholderid = data['AuthorID'];
							var beholdertype = data['AuthorType'];	
							
							$(this).off("click").animate({
								opacity: 1.0,
							}, 1000);
							
							var request = $.ajax({
								url: "ajax.php",
								type: "POST",
								dataType: "json",
								contentType: "application/x-www-form-urlencoded;charset=UTF-8",
								data: { 'do' : 'unlike',
									'authorid' : userid, //'<?php print($user->id); ?>',
									'objectid' : objectid,
									'objecttype' : objecttype,
									'beholderid' : beholderid,
									'beholdertype' : beholdertype,
									'value' : 'unlike'
								}});

							request.done(function(data) {
								if (data[0] != null || data[0] != 'undefined') {
									$("#like-comment-" + id).text("Beğen");
									$("#like-comment-" + id).on("click", $("#like-comment-" + id), OnLikeClick);
								}
							});
						
						}
					}
				}
				
				function OnShareClick(e) {
					e.preventDefault();
					e.stopPropagation();
						
					if ($(this).is(':animated'))
						return;
					else if ($('#share-box').val() == "Ne düşünüyorsun?") {
						$('#share-box').focus();
						return;
					}
						
					var length = $('#share-box').val().replace(/\n/g,"").length;

					if (length > 0) {
						$(this).off("click").animate({
							opacity: 1.0,
						}, 3000);
						
						var posttype = "";
						var info = "";
						var tab = getCurrentTab();
						if (tab == "Status")
							posttype = "Status";
						else if (tab == "Photo") {
							posttype = "Status|Photo";
							info = $.parseJSON(unescape($('#sc-photo-frame').contents().find('#photo-info').val()));
						}
						else if (tab == "Video") {
							posttype = "Status|Video";
							info = $.parseJSON(unescape($('#sc-video-frame').contents().find('#video-info').val()));
						}
						var request = $.ajax({
							url: "ajax.php",
							type: "POST",
							dataType: "json",
							contentType: "application/x-www-form-urlencoded;charset=UTF-8",
							data: {'do' : 'post',
								'authorid' : userid, //'<?php print($user->id); ?>',
								'beholderid' : targetid, //'<?php $user->id == $target->id ? print($user->id) : print($target->id); ?>',
								'beholdertype': 'User',
								'value' : $('#share-box').val(),
								'posttype' : posttype,
								'originalpath' : info['OriginalPath'],
								'thumbnailpath' : info['ThumbnailPath'] }
							});

						request.done(function(data) {
							if (data[0] != null || data[0] != 'undefined') {
								var template = "<div id=\"news-" + data['Post']['ID'] + "\" class=\"news\">" +
								"<input id=\"post-info-" + data['Post']['ID'] + "\" type=\"hidden\" value=\"" + data['Info'] + "\" />" +
								"<div class=\"cell left\">" +
								"<a href=\"profile.php?id=" + data['Author']['ID'] + "\">" +
								"<img class=\"midi\" src=\"" + 
								data['Author']['Picture'] + "\" alt=\"" + 
								data['Author']['Name'] + " " + data['Author']['Surname'] + "\" />" +
								"</a>" +
								"</div>" +
								"<div class=\"cell right\">" +
								"<div class=\"user-hold\">" +
								"<a class=\"user\" href=\"profile.php?id=" + data['Author']['ID'] + "\"><span>" + 
								data['Author']['Name'] + " " + data['Author']['Surname'] + "</span></a>" +
								"</div>" +
								"<div class=\"post-hold\">" + data['Post']['Value'] + "</div>";
								
								if (data['Attachment']) {
									if (data['Attachment']['Type'] == "Photo") {
										template += "<div class=\"post-attachment-hold\"><a href=\"\" title=\"\"><img class=\"thumbnail\" src=\"" + data['Attachment']['PreviewPath'] + "\" alt=\"\" /></a></div>";
									}
									else if (data['Attachment']['Type'] == "Video")
										template += "<div class=\"post-attachment-hold\"><img class=\"thumbnail\" src=\"" + data['Attachment']['ThumbnailPath'] + "\" /><img class=\"play\" src=\"img/play-on.png\" /><img class=\"loading\" src=\"img/video-load.gif\" /></div>";
								}
								template += "<div class=\"post-sub\">";
								
								if (data['Attachment']) {
									if (data['Attachment']['Type'] == "Photo")
										template += "<img src=\"img/pictures.png\" alt=\"\" />";
									else if (data['Attachment']['Type'] == "Video")
										template += "<img src=\"img/videos.png\" alt=\"\" />";
								}
									
								template += "<a id=\"like-post-" + data['Post']['ID'] + "\" href=\"#\">Beğen</a> - <a id=\"comment-" + 
								data['Post']['ID'] + "\" href=\"#\">Yorum Yap</a> - <span>" + data['Post']['CreatedAt'] + "</span>" +
								"</div>" +
								
								"<div id=\"do-comment-" + data['Post']['ID'] + "\" class=\"comment-hold disabled off\">" +
								"<div class=\"cell left\">" +
								"<a href=\"profile.php\">" +
								"<img class=\"mini\" src=\"" + data['Author']['Picture'] + "\" alt=\"" +
								data['Author']['Name'] + " " + data['Author']['Surname'] + "\" />" +
								"</a>" +
								"</div>" +
								"<div class=\"cell right\">" +
								"<div class=\"comment-box\">" +
								"<textarea id=\"comment-box-" + data['Post']['ID'] + "\" class=\"inactive\" spellcheck=\"false\">Yorum yaz...</textarea>" +
								"</div>" +
								"</div>" +
								"</div>" +

								"</div>" +
								"<div class=\"clearfix\"></div>" +
								"</div>";
								
								$("#news-hold").prepend(template).focus();
								
								clear();							
								$('#share-con').addClass('hidden');  // reload frame
								$("#share-box").val("");
								
								if (data['Attachment']) {
									if (data['Attachment']['Type'] == "Photo")
										$('#sc-photo-frame').attr('src', $('#sc-photo-frame').attr('src')).css('height', '38px');
									else if (data['Attachment']['Type'] == "Video")
										$('#sc-video-frame').attr('src', $('#sc-video-frame').attr('src')).css('height', '38px');
								}
							}
						});

						request.fail(function(jqXHR, textStatus) {
							alert( "Hata: İsteğinizi gerçekleştiremedik. " + textStatus );
						});
						
						$(this).on("click", $(this), OnShareClick);
					}
					else {
						$('#share-box').focus();
					}
					
				}