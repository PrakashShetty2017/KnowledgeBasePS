using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;



namespace TwitterAPIManager
{
/// <summary>
/// Provides the timeline feed information using twitter APIs.
/// Returns empty string if any of the parameter is empty.
/// </summary>
    public  class TwitterFeed : ITwitterFeed 
    {
        public IAuthenticateSettings AuthenticateSettings { get; set; }
    
        /// <summary>
        /// Gets the Twitter feed based on API URL pased and access token
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="tokenType"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetTwitterFeedJson(string apiUrl, string tokenType, string accessToken)
        {
            try
            {

                // Also all 3 properties should have values, otherwise return empty.
                if (apiUrl == null || tokenType == null || accessToken == null)
                    return string.Empty;
                else if (apiUrl == string.Empty || tokenType == string.Empty || accessToken == string.Empty)
                    return string.Empty;  

                string twitterFeedjson = string.Empty;
                //HTTP Request object 
                HttpWebRequest apiRequest = (HttpWebRequest)WebRequest.Create(apiUrl);

                // Prepare request header by passing token information.
                var timelineHeaderFormat = "{0} {1}";
                apiRequest.Headers.Add("Authorization",
                                            string.Format(timelineHeaderFormat, tokenType,
                                                          accessToken));
                //Request Method
                apiRequest.Method = "Get";

                // Get the response by calling twitter feed API
                WebResponse timeLineResponse = apiRequest.GetResponse();

                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        twitterFeedjson = reader.ReadToEnd();
                     }
                }
                return twitterFeedjson;
            }
            catch (Exception ex)
            {
                //Handle specific action like Logging if needed. Then throw the original exception
                throw ex;
            }
        }
        /// <summary>
        /// Gets the Twitter feed for the user based on the configuration settings
        /// </summary>
        /// <returns></returns>
        public string GetTwitterFeed()
        {
            //Reference : https://dev.twitter.com/rest/reference/get/statuses/user_timeline

            // Get Configuration details needed for Authentication Token.
            string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
            string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
            string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];


            //Get the Configuration settings needed for twitter timeline feed
            string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];
            string screenname = ConfigurationManager.AppSettings["screenname"];
            int count = Convert.ToInt16(ConfigurationManager.AppSettings["count"]);
            string include_rts = ConfigurationManager.AppSettings["include_rts"];
            string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];

            // Return variable
            string timeLineJson = string.Empty;

            // Get Authentication token details
            AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };
            IAuthenticate authenticate = new Authenticate();
            AuthResponse twitAuthResponse = authenticate.AuthenticateConsumer(AuthenticateSettings);   
           
            //Create a URL to get twitter feed with appropriate Parameter.
           string TimelineUrl = string.Format(timelineFormat, screenname, include_rts, exclude_replies, count);
            // Get Twitter feed in Json format.
            if (twitAuthResponse != null)
            {
                timeLineJson = GetTwitterFeedJson(TimelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
            }            

            return timeLineJson;
        }
    }
}