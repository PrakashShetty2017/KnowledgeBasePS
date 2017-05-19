<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Home" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Refresh" content="60" />
  <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <link href="content/Twitter-core.css" rel="stylesheet" type="text/css" />
    <link href="content/Main.css" rel="stylesheet" type="text/css" />
    <title>Tweed Feed</title>

    <script type="text/javascript">

      function CheckSearchValExist(searchVal, searchText) {
          // Return true if search value is empty so that entire result is displayed
          if (searchVal == "")
              return true;
          else
          {
              //If search value is not found in the tweet content return false
              if (searchText.indexOf(searchVal) == -1)
                  return false;
              else
                   // Search value found in tween content
                  return true; 
          }
            return true;
      }

      function LoadTwitterFeed() {
          //Set result div content to empty
          $('#results').html('');

          $.ajax({
              url: "/Home.aspx/GetTwitterFeed",
              data: {},
              type: "POST",
              contentType: "application/json",
              dataType: "json",
              timeout: 10000,
              success: function (result) {
                  //When Jason is returned as string it lookes like {d: 'return string in json'}
                  if (result.hasOwnProperty("d")) {
                      bindTweets(result.d);
                  }
                  else {
                      bindTweets(result);
                  }

              },
              error: function (xhr, status) {
                  alert(status + " - " + xhr.responseText);
              }
          });
          
          // cancel the Pageload function
          return false;
      }
      function bindTweets(result) {
          // Generates Tweet HTML
          // Tweeter CSS classes are used
          var json = $.parseJSON(result);
                // Loop through every tweet content
          for (var i = 0; i < json.length; i++) {
                    // Check if search text has a value, if so then compare with tweet content
                    if (CheckSearchValExist(document.getElementById('txtSearch').value, json[i].text) == true) {
                        $("#results")
                         .append('<div class="MainDiv">'
                         // Tweet header - Includes ProfileImage, USer Name, Screen Name and Tweet time
                        + '<div class="tweet"><a href="' + json[i].user.profile_image_url + '" ><img src="' + json[i].user.profile_image_url + '" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'                           
                                + '<span class="FullNameGroup">'
                                + '<strong class="fullname show-popup-with-id " data-aria-label-part="">' + json[i].user.name + '</strong>'
                                + '‏</span>'
                                + '&nbsp;<span class="username u-dir" dir="ltr" data-aria-label-part="">@' + json[i].user.screen_name + '</span>'
                                + '<small class="time">' + json[i].created_at.substring(0, 16) + ''
                                + '</small>'
                        + '</div>'
                        // Tweet Content
                        + '<div class="tweet-text-container">'
                                + '<p class="TweetText" lang="en" data-aria-label-part="0">' + json[i].text + '</p>'
                        +'</div>'
                        );                    
                        try {
                            //Display Tweet Image
                            for (var j = 0; j < json[i].entities.media.length; j++) {
                                $("#results").append('</br><div class="AdaptiveMedia-container">'
                                    + '<div class="AdaptiveMedia-singlePhoto">'
                                    + '<div class="AdaptiveMedia-photoContainer js-adaptive-photo" data-image-url="' + json[i].entities.media[j].media_url + '" data-element-context="platform_photo_card">'
                                    + '<img data-aria-label-part="" src="' + json[i].entities.media[j].media_url + '" alt="" style="width: 30%; height: 30%; top: -0px; left: 7.5%">'
                                    + '</div></div></div>'
                                    );
                            }

                        } catch (e) {
                        }
                        // Retweet Count
                        $("#results").append('<div class="stream-Item-Footer ">'
                            + '</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;;&nbsp;&nbsp;'
                            +' <span class="ProfileTweet-actionCountForPresentation" aria-hidden="true">'
                            + '<img src="/content/images/Retweet-Icon.jpg" Tooltip="Retweet Count" alt="" style="width: 1%; height: 1%; "> '
                            +  json[i].retweet_count + ' <span style="font-size: 10px;font-style: oblique"> Times</span></span>'
                            + '</div>');
                    }
                }

        }
    </script>
</head>
<body onload="LoadTwitterFeed()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <div id="HeaderDiv" class="LeftDiv">
        <!--Search controls -->
        <input  id="txtSearch" type="text" style="width: 60%; height: 30%;" />&nbsp;
        <input  name="submit" id="submitme" type="image" src="/content/Images/Search.png" style="width: 4%; height: 4%;  vertical-align: bottom" onclick="LoadTwitterFeed(); return false;"/>
    </div>
    <!-- Tweitter Feed result -->
    <div id="results" />
    </form>
</body>
</html>