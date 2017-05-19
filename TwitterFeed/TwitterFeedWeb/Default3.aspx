<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default1" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
      <%--  <script type="text/javascript" src="/js/twitter-text.js"></script>--%>
    <title></title>
    <style>
        .TweetText {
            font-size: 14px;
            line-height: 20px;
            white-space: pre-wrap;
            word-wrap: break-word;
            padding-left: 5%;
        }
        .tweet-text-container {
            left: 10%;
        }
        .time {
            font-size: 10px;
            font-style: oblique;
        }
        .stream-Item-Footer {
            padding-left: 1.5%;
        }
    </style>
    <script type="text/javascript">
        $(function () {

            $.ajax({
                url: "/Default1.aspx/GetTwitterFeed",
                data: {},
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                timeout: 10000,
                success: function (result) {
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

            function bindTweets(result) {
                debugger;
                var json = $.parseJSON(result);
                for (var i = 0; i < json.length; i++) {
                    $("#results")
                        .append('<div class="tweet"><a href="' + json[i].user.profile_image_url + '" ><img src="' + json[i].user.profile_image_url + '" /></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'
                           
                        + '<span class="FullNameGroup">'
                        + '<strong class="fullname show-popup-with-id " data-aria-label-part="">' + json[i].user.name + '</strong>'
                        + '<span>‏</span><span class="UserBadges"></span>'
                        + '<span class="UserNameBreak">&nbsp;</span></span><span class="username u-dir" dir="ltr" data-aria-label-part="">@<b>' + json[i].user.screen_name + '</b></span></a>'
                        + '<small class="time">' + json[i].created_at.substring(0, 16) + ''
                        + '</small></div>'
                        + '&nbsp;&nbsp;<div class="tweet-text-container">'
                        + '<p style="left: 5%" class="TweetText" lang="en" data-aria-label-part="0">' + json[i].text + '</p></div>'
                        );                    
                    try {
                        for (var j = 0; j < json[i].entities.media.length; j++) {
                            $("#results").append('</br><div class="AdaptiveMedia-container">'
                                + '<div class="AdaptiveMedia-singlePhoto">'
                                + '<div class="AdaptiveMedia-photoContainer js-adaptive-photo" data-image-url="' + json[i].entities.media[j].media_url + '" data-element-context="platform_photo_card">'
                                + '<img data-aria-label-part="" src="' + json[i].entities.media[j].media_url + '" alt="" style="width: 30%; height: 30%; top: -0px; left: 5%">'
                                + '</div></div></div>'
                                );
                        }

                    } catch (e) {
                    }
                    $("#results").append('<div class="stream-Item-Footer">'
                        + '</br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="ProfileTweet-actionCountForPresentation" aria-hidden="true">Re-Tweet Count: ' + json[i].retweet_count + '</span>'
                        + '</div></div></div>');
                }
            }

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <div id="results" />
    </form>
</body>
</html>