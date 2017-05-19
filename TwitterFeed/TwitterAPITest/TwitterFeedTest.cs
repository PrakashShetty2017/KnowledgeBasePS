using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using TwitterAPIManager;

namespace TwitterAPITest
{
    [TestClass]
    public class TwitterFeedTest
    {

        /// <summary>
        /// Event gets called when test is being initialised
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            //test initialization code  
        }

        /// <summary>
        /// Test Clean up event.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            //test cleanup code
        }
        #region GetTwitterFeedJson 

        #region GetTwitterFeedJson Method Parameter check


        /// <summary>
        /// Test method to check empty accessToken for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonEmptyaccessToken()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = "Bearer";
            string accessToken = string.Empty;

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When accessToken is empty, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }


        /// <summary>
        /// Test method to check null accessToken for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonNullaccessToken()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = "Bearer";
            string accessToken =null;

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When accessToken is null, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }

        /// <summary>
        /// Test method to check empty tokenType for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonEmptytokenType()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = string.Empty;
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When tokenType is empty, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }


        /// <summary>
        /// Test method to check null tokenType for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonNulltokenType()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = null;
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When tokenType is null, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }

        /// <summary>
        /// Test method to check empty apiUrl for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonEmptyapiUrl()
        {
            //Arrange
            string apiUrl = "";
            string tokenType = "Bearer";
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When apiUrl is empty, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }


        /// <summary>
        /// Test method to check null apiUrl for GetTwitterFeedJson
        /// </summary>
        [TestMethod]
        public void GetTwitterFeedJsonNullapiUrl()
        {
            //Arrange
            string apiUrl = null;
            string tokenType = "Bearer";
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When Consumer key is null, the expected output is empty string.
            Assert.AreEqual(twitterFeedjson, string.Empty);
        }

        #endregion

        #region Exception from method

        /// <summary>
        /// Test method AuthenticateConsumer with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException),
            "The remote server returned an error: (403) Forbidden.")]
        public void AuthenticateConsumerWithInValidAccessToken()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = "bearer";
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When tokenType is null, the expected output is empty string.
            //Exception is ecxpected
        }

        /// <summary>
        /// Test method AuthenticateConsumer with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException),
            "The remote server returned an error: (404) Not Found.")]
        public void AuthenticateConsumerWithInValidTimelineURL()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/SomeAPI.json?";
            string tokenType = "bearer";
            string accessToken = "Some Token";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When tokenType is null, the expected output is empty string.
            //Exception is ecxpected
        }

        #endregion

        #region GetTwitterFeedJson Method with Valid Return Value

        /// <summary>
        /// Test method GetTwitterFeedJson with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerWithValidParameter()
        {
            //Arrange
            string apiUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=salesforce;include_rts=1;exclude_replies=0;count=10";
            string tokenType = "bearer";
            string accessToken = "AAAAAAAAAAAAAAAAAAAAAKfL0gAAAAAA8elyR17B3kTQSeS4yAJK%2FhmA248%3DPXw0uFjXC0DtGTZnFha4aOPTs53PlcrOvgeZ88TTzWca8e44kr";

            //Act
            ITwitterFeed obTwitterFeed = new TwitterFeed();
            string twitterFeedjson = obTwitterFeed.GetTwitterFeedJson(apiUrl, tokenType, accessToken);

            //Assert
            // When tokenType is null, the expected output is empty string.
            Assert.IsTrue(twitterFeedjson != string.Empty );
        }

        #endregion

        #endregion

        #region GetTwitterFeed

        #endregion
    }
}
