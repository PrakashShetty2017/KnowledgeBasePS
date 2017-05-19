<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Home" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Refresh" content="60" />
  <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <link href="Twitter-core.css" rel="stylesheet" type="text/css" />
    <title></title>
   <style>
        .TweetText {
            font-size: 14px;
            line-height: 20px;
            white-space: pre-wrap;
            word-wrap: break-word;
            padding-left: 20%;
        }
        .tweet-text-container {
            left: 10%;
        }
        .time {
            font-size: 10px;
            font-style: oblique;
        }
        .stream-Item-Footer {
            padding-left: 20%;
        }
        .MainDiv {
            padding-left: 20%;
            padding-right: 20%;
            padding-top: 1%;
            width: 30%;
        }
        .AdaptiveMedia-container {
            padding-left: 20%;
        }
        .LeftDiv {
            padding-left: 80%; 
            padding-right: 80%;
            background-image: url("/content/Images/Header-Banner.jpg");
            width: 20%;
        }
        .RightDiv { 
            padding-left: 60%; 
            padding-top: 5%;
        }
    </style>
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

                var json = $.parseJSON(result);
                for (var i = 0; i < json.length; i++) {
                    if (CheckSearchValExist(document.getElementById('txtSearch').value, json[i].text) == true) {
                        $("#results")
                         .append('<div class="MainDiv">'
                        + '<div class="tweet"><a href="' + json[i].user.profile_image_url + '" ><img src="' + json[i].user.profile_image_url + '" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'                           
                        + '<span class="FullNameGroup">'
                        + '<strong class="fullname show-popup-with-id " data-aria-label-part="">' + json[i].user.name + '</strong>'
                        + '<span>‏</span><span class="UserBadges"></span>'
                        + '<span class="UserNameBreak">&nbsp;</span></span><span class="username u-dir" dir="ltr" data-aria-label-part="">@<b>' + json[i].user.screen_name + '</b></span></a>'
                        + '<small class="time">' + json[i].created_at.substring(0, 16) + ''
                        + '</small></div>'
                        + '<div class="tweet-text-container">'
                        + '<p class="TweetText" lang="en" data-aria-label-part="0">' + json[i].text + '</p></div>'
                        );                    
                        try {
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
                        $("#results").append('<div class="stream-Item-Footer">'
                            + '</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;;&nbsp;&nbsp;'
                            +' <span class="ProfileTweet-actionCountForPresentation" aria-hidden="true"><img src="/content/images/Retweet-Icon.jpg" alt="" style="width: 1%; height: 1%; left: 7.5%"> ' + json[i].retweet_count + ' <span style="font-size: 10px;font-style: oblique"> Times</span></span>'
                            + '</div></div></div></div>');
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
     <input  id="txtSearch" type="text" style="width: 60%; height: 30%;" />&nbsp;
     <input name="submit" id="submitme" type="image" src="/content/Images/Search.png" style="width: 4%; height: 4%;  vertical-align: bottom" onclick="LoadTwitterFeed(); return false;"/>

 </div>
  <div id="results" />
    </form>
</body>
</html>