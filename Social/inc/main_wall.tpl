<div class="main-wall">
	<?php
	if (!($pid > 0)): ?>
	<div id="share-panel">
		<div id="share-tab">
			<a id="sp-status-img" href="#"><i class="status-item"></i></a> <a id="sp-status-link" class="share-tab-link" href="#">Durum</a>
			<a id="sp-picture-img" href="#"><i class="pictures-item"></i></a> <a id="sp-picture-link" class="share-tab-link" href="#">Fotoğraf</a>
			<a id="sp-video-img" href="#"><i class="videos-item"></i></a> <a id="sp-video-link" class="share-tab-link" href="#">Video</a>
		</div>
		<div class="share-con-fake">
			<div class="sc-arrow"><img src="img/sc-arrow-up.png" alt="" /></div>
			<div class="sc-status-fake">
					<textarea id="share-box-fake" class="inactive" spellcheck="false">Ne düşünüyorsun?</textarea>
			</div>
		</div>
		<div id="share-con" class="hidden">
			<div class="sc-arrow"><img src="img/sc-arrow-up.png" alt="" /></div>
			<div class="sc-status">
				<textarea id="share-box" class="inactive" spellcheck="false" maxlength="2048">Ne düşünüyorsun?</textarea>
			</div>
			<div class="sc-photo">
				<iframe id="sc-photo-frame" style="width: 100%; height: 38px" frameborder="0" border="0" scrolling="no"></iframe>
			</div>
			<div class="sc-video">
				<iframe id="sc-video-frame" style="width: 100%; height: 38px" frameborder="0" border="0" scrolling="no"></iframe>
			</div>
			<div id="sc-sub">
				<div class="cell right">
					<input type="submit" class="button-black" id="share-button" value="Paylaş" />
				</div>
			</div>
		</div>
	</div>
	<?php
	endif; ?>
	<div id="news-hold">
		<?php 
			if ($pid > 0) {
				$news = wall::getsinglefromid($pid, $user);
			}
			else if ($target != null) {
				if ($user->id == $target->id)
					$news = wall::getnewsfrom($user, $user);
				else
					$news = wall::getnewsfrom($target, $user);
			}
			else
				$news = wall::getnewsfor($user);
				
			$news_total = count($news);
			
			for($i = 0; $i < $news_total; $i++) {
				if (get_class($news[$i]) == "post") {
					$post = $news[$i];
					$author = $post->author;
					$post_info = array();
					
					if ($post->attachment != null && $post->attachment->type == "Video")
						$post_info = array('ID' => $post->id, "AuthorID" => $post->author->id, 'AuthorType' => $post->author->type, 'BeholderID' => $post->beholderid, 'BeholderType' => $post->beholdertype, 'PostType' => $post->posttype,
										   'Attachment' => array('ID' => $post->attachment->id, 'Type' => $post->attachment->type, 'OriginalPath' => $post->attachment->originalpath));
					else
						$post_info = array('ID' => $post->id, 'AuthorID' => $post->author->id, 'AuthorType' => $post->author->type, 'BeholderID' => $post->beholderid, 'BeholderType' => $post->beholdertype, 'PostType' => $post->posttype);
						
					$whom = "";
					
					if ($author->id == $post->beholderid)
						$whom = sprintf("<a class=\"user\" href=\"profile.php?id=%s\"><span>%s %s</span></a>", $author->id, $author->name, $author->surname);
					else {
						if ($post->beholderid != $post->author->id && $_SERVER['SCRIPT_NAME'] != "/profile.php") {
							$beholder = utility::getuserfromid($post->beholderid);
							$whom = sprintf("<a class=\"user\" href=\"profile.php?id=%s\"><span>%s %s</span></a> <img src='img/right-arrow-min.png' alt='' /> <a class=\"user\" href=\"profile.php?id=%s\"><span>%s %s</span></a>", $author->id, $author->name, $author->surname, $beholder->id, $beholder->name, $beholder->surname);
						}
						else
							$whom = sprintf("<a class=\"user\" href=\"profile.php?id=%s\"><span>%s %s</span></a>", $author->id, $author->name, $author->surname);
					}
					
					if (strlen($post->value) > 300) {
						$post->value = substr($post->value, 0, 300) . "..." . sprintf(" <a href=\"#\" id=\"post-see-rest-%s\" data=\"%s\">Devamını Gör</a>", $post->id, db::escape(utility::json_encode(array("All" => $post->value))));
					}
					
					$template = sprintf(
					"<div id=\"news-%s\" class=\"news\">" .
						"<input id=\"post-info-%s\" type=\"hidden\" value=\"%s\" />" .
						"<div class=\"cell left\">" .
							"<a href=\"profile.php?id=%s\">" .
								"<img class=\"midi\" src=\"%s\" alt=\"%s %s\" />".
							"</a>".
						"</div>".
						"<div class=\"cell right\">".
							"<div class=\"user-hold\">".
								"%s". // whom to whom
							"</div>".
							"<div class=\"post-hold\">%s</div>", $post->id, $post->id, db::escape(utility::json_encode($post_info)), $author->id, $author->avatar("midi"), $author->name, $author->surname, $whom , $post->value);
							
					if ($post->posttype == "Status|Photo") {
						$template .= sprintf("<div class=\"post-attachment-hold\"><a href=\"%s\" alt=\"%s\"><img class=\"thumbnail\" src=\"%s\" alt='' /></a></div>", "url:gallery:photo", "photo:title", $post->attachment->previewpath );
					}
					else if ($post->posttype == "Status|Video")
						$template .= sprintf("<div class=\"post-attachment-hold\"><img class=\"thumbnail\" src=\"%s\" /><img class=\"play\" src=\"img/play-on.png\" alt='Oynat' /><img class=\"loading\" src=\"img/video-load.gif\" alt='Yükleniyor' /></div>", $post->attachment->thumbnailpath );
					
					$template .= "<div class=\"post-sub\">";
					
					if ($post->posttype == "Status|Photo")
						$template .= "<img src=\"img/pictures.png\" alt='Resim Gönderi' />";
					else if ($post->posttype == "Status|Video")
						$template .= "<img src=\"img/videos.png\" alt='Video Gönderi' />";
						
					$template .= sprintf("<a id=\"like-post-%s\" href=\"#\">%s</a> - <a id=\"comment-%s\" href=\"#\">Yorum Yap</a> - <span>%s</span>".
							"</div>", $post->id, $post->haslikedbycurrent ? "Beğenmekten Vazgeç" : "Beğen", $post->id, utility::countdown($post->createdat));
							
					if ($post->likes > 0) {
						$template .=
							sprintf("<div class=\"post-likes\">".
								"<img src=\"img/like.png\" alt='Beğenenler' />%s".
							"</div>", $post->get('liked-by', $user, "html"));
					}
					
					$j = 0;
					$comments_total = count($news[$i]->comments);
					if ($comments_total > 5) {
						$j = $comments_total - 2;
						$template .= 
							sprintf("<div class=\"post-see\">".
									"<img src=\"img/message-friend.png\" alt=\"Tüm yorumları gör\" /><a id=\"see-all-comments-%s\" href=\"#\" title=\"Tüm yorumları gör\">%s yorumun tümünü gör</a><img class=\"ajax-load\" src=\"img/ajax-load.gif\" alt=\"Yükleniyor\" />".
									"</div>", $post->id, $comments_total);
							
					}
					for($j; $j < $comments_total; $j++) {
						$comment = $news[$i]->comments[$j];
						$commentor = $comment->author;
						
						$comment_info = array('ID' => $comment->id, 'AuthorID' => $comment->author->id, 'AuthorType' => $comment->author->type, 'BeholderID' => $comment->beholderid, 'BeholderType' => $comment->beholdertype);
						
						$comment_likedby = "";
						
						if ($comment->likes > 0)
							$comment_likedby = sprintf(" - <a href=\"#\" id=\"see-comment-likes-%s\" title=\"Bu yorumu beğenenleri gör\"><img src=\"img/like.png\" alt=\"Beğeniler\" />%s</a>", $comment->id, $comment->likes);
							
						if (strlen($comment->value) > 300) {
							$comment->value = substr($comment->value, 0, 300) . "..." . sprintf(" <a href=\"#\" id=\"comment-see-rest-%s\" data=\"%s\">Devamını Gör</a>", $comment->id, db::escape(utility::json_encode(array("All" => $comment->value))));
						}
						$template .= sprintf(
							"<input id=\"comment-info-%s\" type=\"hidden\" value=\"%s\" /><div class=\"comment-hold\">".
								"<div class=\"cell left\">".
									"<a href=\"profile.php?id=%s\">".
										"<img class=\"mini\" src=\"%s\" alt=\"%s %s\" />".
									"</a>".
								"</div>".
								"<div class=\"cell right\">".
									"<div class=\"comment\">".
										"<a href=\"profile.php?id=%s\"><span>%s %s</span></a> %s".
									"</div>".
									"<div class=\"comment-sub\">".
										"%s - <a id=\"like-comment-%s\" href=\"#\">%s</a>%s
									</div>
								</div>
							</div>", $comment->id, db::escape(utility::json_encode($comment_info)), $commentor->id, $commentor->avatar("midi"), $commentor->name, $commentor->surname, $commentor->id, $commentor->name, $commentor->surname, $comment->value, utility::countdown($comment->createdat), $comment->id,
							$comment->haslikedbycurrent ? "Beğenmekten Vazgeç" : "Beğen", $comment_likedby);
					}
					
					// if can comment - todo
					$control = "";
					
					if ($comments_total == 0 )
						$control = " disabled";
						
					$template .= sprintf(
							"<div id=\"do-comment-%s\" class=\"comment-hold%s off\">".
								"<div class=\"cell left\">".
									"<a href=\"profile.php\">".
										"<img class=\"mini\" src=\"%s\" alt=\"%s %s\" />".
									"</a>".
								"</div>".
								"<div class=\"cell right\">".
									"<div class=\"comment-box\">".
										"<textarea id=\"comment-box-%s\" class=\"inactive\" spellcheck=\"false\">Yorum yaz...</textarea>".
									"</div>".
								"</div>".
							"</div>", $post->id, $control, $user->avatar('midi'), $user->name, $user->surname, $post->id); 
							
					$template .= 
						"</div>".
						"<div class=\"clearfix\"></div>".
					"</div>";
					
					print($template);
				}
				else if (get_class($news[$i]) == "action") {
					$prev = $news[$i - 1];
					$next = $news[$i + 1];
					
					$first = false;
					$last = false;
					
					if ($prev == null || get_class($prev) == "post") // first action
						$first = true;
					if ($next == null || get_class($next) == "post") // last action
						$last = true;
						
					$action = $news[$i];
					$author = $action->author;
					$action_info = array();
					
					$action_info = array('ID' => $action->id, 'AuthorID' => $action->author->id, 'AuthorType' => $action->author->type, 'TargetID' => $action->target->id, 'TargetType' => $action->target->type, 'ActionType' => $action->actiontype);
						

					$ext = "";
					$template = "";
					if ($first) {
						$ext .= " first";
						$template .= "<div class=\"recently\">YAKINLARDAKİ HAREKETLER</div>";
					}
					if ($last)
						$ext .= " last";
						
					$template .= sprintf(
					"<div id=\"action-%s\" class=\"action%s\">" .
						"<input id=\"action-info-%s\" type=\"hidden\" value=\"%s\" />" .
						"<div class=\"cell left\">" .
						"</div>".
						"<div class=\"cell right\">".
							"%s%s" .
						"</div>".
						"<div class=\"clearfix\"></div>".
					"</div>", $action->id, $ext, $action->id, db::escape(utility::json_encode($action_info)), $action->get("icon"), $action->get("story"));
					
					print($template);
				}
			}
		?>
	</div>
	<script type="text/javascript"> 
		var userid = <?php print($user->id); ?>; 
		var targetid = <?php if ($target != null && $target->id != $user->id) 
								print($target->id); 
							else
								print($user->id); ?>;
	</script>
	<script type="text/javascript" src="js/kibris.wall.js"></script>
</div>

<?php  /*<div class="cell left"><img src="img/add-friend.png" class="add-friend" /></div><div id="privacy-button"><img src="img/lock.png" /><span>Sadece Ben</span><img src="img/sc-sub-arrow.png" /></div>*/ ?>
