using System;

namespace TwitterAPIManager
{
    /// <summary>
    /// Provides the timeline feed information using twitter APIs.
    /// </summary>
	public interface ITwitterFeed
	{
         string GetTwitterFeed();
         string GetTwitterFeedJson(string apiUrl, string tokenType, string accessToken);
        
	}
}
