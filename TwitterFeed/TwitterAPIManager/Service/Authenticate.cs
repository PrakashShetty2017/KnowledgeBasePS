using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
namespace TwitterAPIManager
{
    /// <summary>
    ///  Provides the access token information using twitter oAuth APIs.
    /// </summary>
	public class Authenticate : IAuthenticate
	{
       
        /// <summary>
        /// Provides authentication application token based on consumer key information.
        /// Returns null if any of the input parameter does not contains the values.
        /// 
        /// </summary>
        /// <param name="authenticateSettings"></param>
        /// <returns></returns>
        //Reference: "Issuing application-only requests"  https://dev.twitter.com/oauth/application-only
        public AuthResponse AuthenticateConsumer(IAuthenticateSettings authenticateSettings)
		{
            try
            {  
            // Validate the Parameter value. Parameter should have value, otherwise return null.
            // Also all 3 properties should have values, otherwise return null.
            if (authenticateSettings == null)
                return null;
            else if (authenticateSettings.OAuthConsumerKey== null || authenticateSettings.OAuthConsumerSecret == null || authenticateSettings.OAuthUrl== null)
                return null;
            else if (authenticateSettings.OAuthConsumerKey == string.Empty || authenticateSettings.OAuthConsumerSecret == string.Empty || authenticateSettings.OAuthUrl == string.Empty)
                return null;  

            AuthResponse twitAuthResponse = new AuthResponse();
			
            //Prepare the Authentication header
			var authHeaderFormat = "Basic {0}";

			var authHeader = string.Format(authHeaderFormat,
										   Convert.ToBase64String(
											   Encoding.UTF8.GetBytes(Uri.EscapeDataString(authenticateSettings.OAuthConsumerKey) + ":" +

																	  Uri.EscapeDataString((authenticateSettings.OAuthConsumerSecret)))

											   ));
		
            //HTTP Request object 
			HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(authenticateSettings.OAuthUrl);

            //Add header information as per detail provided in twitter api
			authRequest.Headers.Add("Authorization", authHeader);
			authRequest.Method = "POST";
			authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            
            //Write below grant type details to Request
            var postBody = "grant_type=client_credentials";
            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
			authRequest.Headers.Add("Accept-Encoding", "gzip");
			WebResponse authResponse = authRequest.GetResponse();
			// read the response and return as AuthResponse object
			using (authResponse)
			{
				using (var reader = new StreamReader(authResponse.GetResponseStream()))
				{                  
					string objectText = reader.ReadToEnd();				
                    if (objectText!= "" || objectText!=null )
                    {
                        //Convert the token detils in Jason format to AuthResponse object
                        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                        var authToken = json_serializer.Deserialize<Dictionary<string, string>>(objectText);
                        if (authToken != null)
                        {
                            twitAuthResponse.TokenType = authToken["token_type"];
                            twitAuthResponse.AccessToken = authToken["access_token"];
                        }
                    }

				}
			}

			return twitAuthResponse;
            }
            catch (Exception ex)
            {
                //Handle specific action like Logging if needed. Then throw the original exception
                throw ex;
            }
		}
	}
}
