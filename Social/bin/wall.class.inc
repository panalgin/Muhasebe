<?php
require_once("db_wrapper.class.inc");
require_once("utility.class.inc");
require_once("post.class.inc");

abstract class wall {

	// This function will have algorithms
	// for advanced wall post which may
	// have user's interest. It will be 
	// developed further for group and
	// fan page usage
	static function getnewsfor($user) {
		if ($user != null) {			
			$cmd = sprintf("SELECT Posts.ID, Posts.AuthorID, Posts.CreatedAt, Posts.Value, Posts.BeholderID, Posts.BeholderType, Posts.PostType, Posts.AttachmentID, Posts.AttachmentType, (SELECT COUNT(ID) FROM Likes WHERE Likes.ObjectID = Posts.ID AND ObjectType = Posts.PostType) as Likes, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, (SELECT COUNT(ID) FROM Likes WHERE AuthorID = '%s' and ObjectID = Posts.ID and ObjectType = Posts.PostType) as HasLiked FROM Posts JOIN Users ON(Users.ID = Posts.AuthorID) WHERE (Posts.BeholderID = '%s' AND Posts.BeholderType = 'User') OR Posts.AuthorID IN (SELECT TargetID From FriendShips WHERE BaseID = '%s') ORDER BY CreatedAt DESC LIMIT 0, 20", $user->id, $user->id, $user->id);
			$result = db::query($cmd);
			$news = array();
			
			$i = 0;
			while($row = db::fetch($result)) {
				$post = new post(array($row['ID'], $row['AuthorID'], $row['CreatedAt'], $row['Value'], $row['BeholderID'], $row['BeholderType'], $row['PostType'], $row['AttachmentID'], $row['AttachmentType'], $row['Likes'], $row['AuthorName'], $row['AuthorSurname'], $row['AuthorGender'], $row['AuthorProfile'], $row['HasLiked']), $user);
				$news[$i] = $post;
				
				$i++;
			}
			
			return $news;		
		}
		else
			return null;
	}
	static function getsinglefromid($pid, $user) {
		if ($pid > 0) {
			$cmd = sprintf("SELECT Posts.ID, Posts.AuthorID, Posts.CreatedAt, Posts.Value, Posts.BeholderID, Posts.BeholderType, Posts.PostType, Posts.AttachmentID, Posts.AttachmentType, (SELECT COUNT(ID) FROM Likes WHERE Likes.ObjectID = Posts.ID AND Likes.ObjectType = Posts.PostType) as Likes, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, (SELECT COUNT(ID) FROM Likes WHERE AuthorID = '%s' and ObjectID = Posts.ID and ObjectType = Posts.PostType) as HasLiked FROM Posts JOIN Users ON(Users.ID = Posts.AuthorID)  WHERE Posts.ID = '%s' ORDER BY CreatedAt DESC LIMIT 0, 1", $user->id, $pid);
			
			$result = db::query($cmd);
			$news = array();
			
			$i = 0;
			
			while($row = db::fetch($result)) {
				$post = new post(array($row['ID'], $row['AuthorID'], $row['CreatedAt'], $row['Value'], $row['BeholderID'], $row['BeholderType'], $row['PostType'], $row['AttachmentID'], $row['AttachmentType'], $row['Likes'], $row['AuthorName'], $row['AuthorSurname'], $row['AuthorGender'], $row['AuthorProfile'], $row['HasLiked']), $user);
				$news[$i] = $post;
				
				$i++;
			}
			
			return $news;
		}
		else
			return null;
	
	}
	static function getnewsfrom($target, $viewer) {
		if ($target != null) {
			$cmd = sprintf("SELECT Posts.ID, Posts.AuthorID, Posts.CreatedAt, Posts.Value, Posts.BeholderID, Posts.BeholderType, Posts.PostType, Posts.AttachmentID, Posts.AttachmentType, (SELECT COUNT(ID) FROM Likes WHERE Likes.ObjectID = Posts.ID AND ObjectType = Posts.PostType) as Likes, Users.Name as AuthorName, Users.Surname as AuthorSurname, Users.Gender as AuthorGender, Users.Profile as AuthorProfile, (SELECT COUNT(ID) FROM Likes WHERE AuthorID = '%s' AND ObjectID = Posts.ID AND ObjectType = Posts.PostType) as HasLiked FROM Posts JOIN Users ON(Users.ID = Posts.AuthorID)  WHERE BeholderID = '%s' AND BeholderType = 'User' ORDER BY CreatedAt DESC LIMIT 0, 20", $viewer->id, $target->id);
			$result = db::query($cmd);
			$news = array();
			
			$i = 0;
			while($row = db::fetch($result)) {
				$post = new post(array($row['ID'], $row['AuthorID'], $row['CreatedAt'], $row['Value'], $row['BeholderID'], $row['BeholderType'], $row['PostType'], $row['AttachmentID'], $row['AttachmentType'], $row['Likes'], $row['AuthorName'], $row['AuthorSurname'], $row['AuthorGender'], $row['AuthorProfile'], $row['HasLiked']), $viewer);
				$news[$i] = $post;
				
				$i++;
			}
			
			$last_date =  utility::past("-7 days");
			$news_total = count($news);
			
			if ($news_total > 0)
				$last_date = $news[$news_total - 1]->createdat;
			
			$cmd = sprintf("SELECT Actions.ID, IF(Actions.AuthorID = '%s', Actions.BeholderID, Actions.AuthorID) as TargetID, Users.Name as TargetName, Users.Surname as TargetSurname, Actions.CreatedAt, Actions.UpdatedAt, Actions.ActionType, Actions.ActionValue FROM Actions JOIN(Users) ON (Users.ID = IF(Actions.AuthorID = '%s', Actions.BeholderID, Actions.AuthorID)) WHERE (Actions.ActionType = 'FriendApproval' OR Actions.ActionType = 'ProfilePictureChanged' OR Actions.ActionType = 'LivesInChanged' OR Actions.ActionType = 'BornInChanged' OR Actions.ActionType = 'InterestedInChanged' OR Actions.ActionType = 'LanguagesChanged' OR Actions.ActionType = 'AboutChanged') AND (Actions.AuthorID = '%s' OR Actions.BeholderID = '%s') AND Actions.UpdatedAt >= '%s' ORDER BY Actions.UpdatedAt DESC LIMIT 0, 20", $target->id, $target->id, $target->id, $target->id, $last_date);
			
			$result = db::query($cmd);
			$temp = array();
			$i = 0;
			
			while($row = db::fetch($result)) {
				$action = new action();
				$action->id = $row['ID'];
				$action->target = new user();
				$action->target->id = $row['TargetID'];
				$action->target->name = $row['TargetName'];
				$action->target->surname = $row['TargetSurname'];
				$action->author = $target;
				$action->createdat = $row['CreatedAt'];
				$action->updatedat = $row['UpdatedAt'];
				$action->actiontype = $row['ActionType'];
				$action->actionvalue = $row['ActionValue'];
				
				$temp[$i] = $action;
				$i++;
			}
			
			$count = count($temp);
			
			if ($count > 0) { // find a good place for most recent actions
				$i = 0;
				for($i = 0; $i < $count; $i++) {
					$action = $temp[$i];
					$place = self::closest($news, $action->updatedat);
					array_splice($news, $place, 0, array($action));
				}
			}
			
			return $news;
		}
		else
			return null;
	}
	
	private static function closest($news, $date) {
		$date = strtotime($date);
		$count = count($news);
		$index = -1;
		
		for($i = 0; $i < $count; $i++) {
			$element = $news[$i];
			$edate = $element->createdat;
			
			if (get_class($element) == "action")
				$edate = $element->updatedat;
				
			if (strtotime($edate) > $date)
				continue;
			else {
				$index = $i;
				break;
			}
		}
		
		if ($index == -1) // we didn't find anything
			$index++; // so to prepend as top
			
		return $index;
	}
	
	static function ajax_post_callback($post) {
		$author = utility::getuserfromid($post->authorid);
		
		$data = array();
		
		$data['Author'] 	= array(	"ID" => intval($author->id),
								"Name" => $author->name,
								"Surname" => $author->surname,
								"Picture" => $author->avatar("midi") );
								
		$data['Post'] 	= array(	"ID" => intval($post->id),
								"CreatedAt" => utility::countdown($post->createdat),
								"Value" => $post->value,
								"BeholderID" => $post->beholderid,
								"BeholderType" => $post->beholdertype,
								"PostType" => $post->posttype);
								
		$data['Info'] 	= db::escape(json_encode(array( 'ID' => intval($post->id), 
													'BeholderID' => $post->beholderid, 
													'BeholderType' => $post->beholdertype, 
													'PostType' => $post->posttype,
													'AuthorID' => $post->authorid,
													'AuthorType' => $author->type)));
													
		// damn this code :D
		if ($post->posttype == "Status|Photo") {
			$photo = new photo($post->attachmentid);
			$data['Attachment'] = array( "ID" => $photo->id,
										 "Type" => $photo->type, //needless isn't it ?
										 "OriginalPath" => urldecode($photo->originalpath),
										 "PreviewPath" => urldecode($photo->previewpath), // needless urldecode
										 "ThumbnailPath" => urldecode($photo->thumbnailpath),
										 "CreatedAt" => $photo->createdat,
										 "GalleryID" =>  $photo->galleryid );
		}
		else if ($post->posttype == "Status|Video") {
			$video = new video($post->attachmentid);
			$data['Attachment'] = array( "ID" => $video->id,
										 "Type" => $video->type, //needless isn't it ?
										 "OriginalPath" => urldecode($video->originalpath),
										 "ThumbnailPath" => urldecode($video->thumbnailpath),
										 "CreatedAt" => $video->createdat );
										 
										 
			$data['Info'] 	= db::escape(json_encode(array( 'ID' => intval($post->id), 
													'BeholderID' => $post->beholderid, 
													'BeholderType' => $post->beholdertype, 
													'PostType' => $post->posttype,
													'Attachment' => array( "ID" => $video->id,
																			"Type" => $video->type, //needless isn't it ?
																			"OriginalPath" => urldecode($video->originalpath),
																			"ThumbnailPath" => urldecode($video->thumbnailpath),
																			"CreatedAt" => $video->createdat ) )));
		}
								
		return $data;		
	}
	static function ajax_comment_callback($comment) {
		$author = $comment->author;
		
		if ($author == null)
			$author = utility::getuserfromid($comment->authorid);
		
		$data = array();
		
		$data['Author'] 	= array(	"ID" => $author->id, 
								"Name" => $author->name, 
								"Surname" => $author->surname, 
								"Picture" => $author->avatar("midi") );
								
		$data['Comment'] 	= array(	"ID" => $comment->id, 
								"CreatedAt" => utility::countdown($comment->createdat), 
								"Value" => $comment->value,
								"ObjectID" => $comment->objectid, 
								"ObjectType" => $comment->objecttype, 
								"BeholderID" => $comment->beholderid, 
								"BeholderType" => $comment->beholdertype,
								"HasLikedByCurrent" => $comment->haslikedbycurrent ? "True" : "False",
								"Likes" => $comment->likes);
								
		$data['Info'] 	= db::escape(json_encode(array( 'ID' => $comment->id, 
													'BeholderID' => $comment->beholderid, 
													'BeholderType' => $comment->beholdertype,
													'AuthorID' => $comment->authorid,
													'AuthorType' => $author->type)));
		
		return $data;
	}
	
	static function ajax_all_comments_callback($post) {
		$post->getcomments();
		
		$data = array();
		$comments = $post->comments;
		$count = count($comments);
		
		for($i = 0; $i < $count; $i++) {
			$data[$i] = self::ajax_comment_callback($comments[$i]);
		}
		
		return $data;
	}
}
?>