using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using OAuthTwitterWrapper.JsonTypes;

/// Summary description for TwitterFeed
/// </summary>
/// 
namespace OAuthTwitterWrapper
{
    public  class TwitterFeed
    {
        public IAuthenticateSettings AuthenticateSettings { get; set; }
        public ITimeLineSettings TimeLineSettings { get; set; }
    
        public string RequstJson(string apiUrl, string tokenType, string accessToken)
        {
            var json = string.Empty;
            HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            var timelineHeaderFormat = "{0} {1}";
            apiRequest.Headers.Add("Authorization",
                                        string.Format(timelineHeaderFormat, tokenType,
                                                      accessToken));
            apiRequest.Method = "Get";
            WebResponse timeLineResponse = apiRequest.GetResponse();

            using (timeLineResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                    // The below can be used to deserialize into a c# object
                    //var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);
                }
            }
            return json;
        }
        public string GetMyTimeline()
        {
            string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
            string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
            string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];
            AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };
            string screenname = ConfigurationManager.AppSettings["screenname"];
            string include_rts = ConfigurationManager.AppSettings["include_rts"];
            string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];
            int count = Convert.ToInt16(ConfigurationManager.AppSettings["count"]);
            string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];
            TimeLineSettings = new TimeLineSettings
            {
                ScreenName = screenname,
                IncludeRts = include_rts,
                ExcludeReplies = exclude_replies,
                Count = count,
                TimelineFormat = timelineFormat
            };

            AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };

            var timeLineJson = string.Empty;
            IAuthenticate authenticate = new Authenticate();
            AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);
                      
            timeLineJson = RequstJson(TimeLineSettings.TimelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);

            return timeLineJson;
        }
    }
}