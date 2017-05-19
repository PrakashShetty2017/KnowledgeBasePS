<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="_Default1" %>
 
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Refresh" content="60" />
  <script type="text/javascript" src="/js/jquery-1.7.2.min.js"></script>
  <%--  <script type="text/javascript" src="/js/twitter-text.js"></script>--%>
    <title></title>
    <script type="text/javascript">

        //var time = new Date().getTime();
        //$(document.body).bind("mousemove keypress", function (e) {
        //    time = new Date().getTime();
        //    test();
        //});

     //   function refresh() {
     //       if(new Date().getTime() - time >= 60000) 
     //           window.location.reload(true);
     //       else 
     //           setTimeout(refresh, 10000);
     //   }
     //   setTimeout(refresh, 10000);
      function CheckSearchValExist(searchVal, searchText) {
          // some code
          if (searchVal == "")
              return true;
          else
          {
              if (searchText.indexOf(searchVal) == -1)
                  return false;
              else
                  return true;
          }
            return true;
      }

        function LoadTwitterFeed () {
            $('#results').html('');
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
                var json = $.parseJSON(result);
                for (var i = 0; i < json.length; i++) {
                    if (CheckSearchValExist($('#txtSearch')[0].value, json[i].text) == true)
                      {
                            $("#results").append('<div class="tweet"><p><a href="' + json[i].user.profile_image_url + '" ><img src="' + json[i].user.profile_image_url + '" /></a>'
                                + '<span vertical-align:middle><strong>' + json[i].user.name + '</span></strong></span>'
                                  + '<span><strong> @' + json[i].user.screen_name + '</span></strong></span>'
                                + '<span><strong> - ' + json[i].created_at.substring(0, 16) + '</span></strong></span><br/>'
                                  + '<span><strong> - Retweet Count : ' + json[i].retweet_count + '</span></strong></span><br/>'
                                + '<span><strong> - ' + json[i].text + '</span></strong></span><br/>'
                                //+ twttr.txt.autoLink(json[i].text) + '</p>'
                                );                    
                            try {
                                for (var j = 0; j < json[i].entities.media.length; j++) {
                                    $("#results").append('<a href="' + json[i].entities.media[j].media_url + '" ><img src="' + json[i].entities.media[j].media_url + ':thumb" /></a>');
                                }

                            } catch (e) {
                            }
                            }
                        }
            }

        }
    </script>
</head>
<body onload="LoadTwitterFeed()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
            <input id="txtSearch" type="text" />&nbsp;&nbsp;&nbsp;<input id="btnSearch" type="button" value="Search" onclick="LoadTwitterFeed()" />
        <div id="search">

        </div>
    <div id="results" />
    </form>
</body>
</html>