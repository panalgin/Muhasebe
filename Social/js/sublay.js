	($).fn.sublay = function(_output, _segment) {
		var request = "";
		var cache = "";
		var result;
		var ul;
		var target = $(this);
		var output = _output;
		var segment = _segment;
		
		$(this).unbind("keydown").unbind('focusout').unbind('click').unbind('keyup');
		
		$(this).on("keydown", $(this), OnListKeyDown);
		$(this).on("focusout", $(this), OnLostFocus);
		$(this).on("click", $(this), OnClick);
			
		$(this).keyup( function(event) {
			if (target.val().length < 3) {
				$(".sublay").remove();
				ul = "";
				cache = "";
				result = "";
				
				return;
			}
			var key = event.which;
			
			if (key != 13 && key != 38 && key != 40) {
				doSearch($(this));
			}
		});
		
		function doSearch(object) {
			if ($('.sublay') != null)
				$('.sublay').remove();
					
			var value = object.val();
			var base = object;
			
			if (value.replace(/\s/g, "").length > 2 && request == "") {
			
				if (cache == value) {
					prepareLay(result, base.attr('id'));
					return;
				}
				
				request = 	$.ajax({
									url: "sublay/ajax.php?do=" + output + "&value=" + encodeURI(value),
									type: "GET",
									dataType: "json"
								});

				request.done(function(reply) {
					if (reply[0]) {
						prepareLay(reply);
						result = reply;
						cache = value;
					}
				});
				request.always(function() {
					request = "";
				});
			}
			else {
				cache = "";
				result = "";
			}
		}
		function prepareLay(data) {
			var width =  target.css('width');
			var id = "sublay-" + target.attr('id');
			var lay = $("<div class='sublay' id='" + id + "'><ul></ul></div>");
			ul = $("ul", lay);
			
			var i = 0;
			for(var key in data) {
				var item = "";
				
				if (output == "location")
					item = data[key]['Location'];
				else if (output == "language")
					item = data[key]['Language'];
				else if (output == "friends")
					item = data[key]['Friend'];
				
				var lid = item.ID;
				var name = item.Name;
				var img = unescape(item.Image);
				var total = "";
				
				if (item.Total)
					total = item.Total;
					
				var li = $("<li><img src='" + img + "' /> " + name + "</li>");
				
				if (total != "")
					li.append(" - <span>" + total + " kişi</span>");
					
					
				li.append("<input id='" + output + "-" + lid + "-item' type='hidden' value='" + escape($.toJSON(data[key])) + "' />");
				
				li.on("click", li, OnItemClick);
				li.on("mouseenter", li, OnItemMouseEnter);
				
				if (i == 0)
					li.addClass('active');
				
				
				ul.append(li);
				i++;
			}
			
			lay.css('width', width);
			
			if (output == 'friends') {
				lay.css('left', "0px"); //target.offset().left + "px");
				lay.css('top', "21px"); //(target.offset().top + target.height() + 1) + "px");
			}
			else {
				lay.css('left', target.offset().left + "px");
				lay.css('top', (target.offset().top + target.height() + 1) + "px");
			}
			target.after(lay);
		}
		
		function OnItemClick(event) {			
			ChooseItem();
		}
		
		function OnItemMouseEnter() {
			SelectItem($(this));
		}
		
		function OnListKeyDown(event) {
			if (!ul && event.which == 8 && output == "location") {
				if($("#" + target.attr('id') + "-over").css('display') == "block") {
					$("#" + target.attr('id') + "-over > img").click();
					return;
				}
			}
			
			if (!ul)
				return;
			
			if (event.which == 13) // enter
				ChooseItem();
			else if (event.which == 38) { //up
				event.preventDefault();
				event.stopPropagation();
				SelectItem("Previous");
			}
			else if (event.which == 40) { //down
				//alert('called');
				event.preventDefault();
				event.stopPropagation();
				SelectItem("Next");
			}
		}
		
		function OnLostFocus() {
			if (ul) {
				var left = ul.offset().left;
				var right = left + ul.width();
				var top = ul.offset().top;
				var bottom = top + ul.height();
				if ((window.mouseXPos >= left && window.mouseXPos <= right) &&
					(window.mouseYPos >= top && window.mouseYPos <= bottom)) {
						return;
					}
			}
			
			ChooseItem();
		}
		
		function OnClick(event) {
			event.preventDefault();
			doSearch($(this));
		}
		
		function SelectItem(item) {
			if (item == "Next") {
				var selected = $("li[class='active']", ul);
				var next = selected.next();
				
				ClearSelected(ul);
				
				if (next.length == 0)
					$("li:first", ul).addClass("active");
				else
					next.addClass("active");
			}
			else if (item == "Previous") {
				var selected = $("li[class='active']", ul);
				var previous = selected.prev();
				
				ClearSelected(ul);
				
				if (previous.length == 0)
					$("li:last", ul).addClass("active");
				else
					previous.addClass("active");
			}
			else {
				ClearSelected(ul);
				
				item.addClass("active");
			}
		}
		
		function ClearSelected(list) {
			$("li", list).each(function() {
				$(this).removeClass('active');
			});
		}
		
		function ChooseItem() {
			if (!ul)
				return; 
				
			var active = ul.find(".active");
			if (active) {
				var info = active.find("input[type=hidden]");
				data = $.parseJSON(unescape(info.val()));
				
				if (output == "location") {
					var out = $.parseJSON(unescape($("input[id='location-info']").val()));
					
					if (segment == "lives-in") {
						if (out) {
							if (out.Location.LivesIn) {
								out.Location.LivesIn['ID'] = data.Location.ID;
								out.Location.LivesIn['Name'] = data.Location.Name;
							}
							else
								out.Location['LivesIn'] = { "ID" : data.Location.ID, "Name" : data.Location.Name };
						}
						else if (!out)
							out = { 'Location': { 'LivesIn' : { 'ID': data.Location.ID, 'Name' : data.Location.Name }}};
					}
					else if (segment == "born-in") {
						if (out) {
							if (out.Location.BornIn) {
								out.Location.BornIn['ID'] = data.Location.ID;
								out.Location.BornIn['Name'] = data.Location.Name;
							}
							else
								out.Location['BornIn'] = { "ID" : data.Location.ID, "Name" : data.Location.Name };
						}
						else if (!out)
							out = { 'Location': { 'BornIn' : { 'ID' : data.Location.ID, 'Name' : data.Location.Name }}};			
					}
					
					target.val('');
					target.attr("readonly", "readonly");
					$("#" + target.attr('id') + "-over").css('display', 'block').css('top', target.offset().top).children('span').append(data.Location.Name);
					
					$("input[id='location-info']").val(escape($.toJSON(out)));
					ul = "";
					Prepare();
				}
				else if (output == "friends") {
					var out = data;
					
					target.val('');
					target.attr("readonly", "readyonly");
					$("#" + target.attr('id') + "-over").css('display', 'block').css('top', '0px').children('span').text(data.Friend.Name);
					$("input[id='towho-info']").val(escape($.toJSON(out)));
					
					ul = "";
				}
				else if (output == "language") {					
					var item =  "<div class=\"list-control-item\">" + data.Language.Name + " <img src=\"img/cross.png\" /><input id=\"language-item-" + data.Language.ID + "\" type=\"hidden\" value=\"" + escape($.toJSON({ 'ID' : data.Language.ID, 'Name' : data.Language.Name })) + "\" /></div>";
					
					target.before(item);
					target.val('');
					target.change().focus();
					ul = "";
				}
			}

			$('div.sublay').remove();
		}
	};