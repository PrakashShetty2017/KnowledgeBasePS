using System;
namespace TwitterAPIManager
{
   /// <summary>
   /// Authentication settings model. Contains the Input needed to get access token.
   /// </summary>
	public interface IAuthenticateSettings
	{
		string OAuthConsumerKey { get; set; }
		string OAuthConsumerSecret { get; set; }
		string OAuthUrl { get; set; }
	}
}
