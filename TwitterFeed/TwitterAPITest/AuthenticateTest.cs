using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.QualityTools.Testing.Fakes;
using TwitterAPIManager;

namespace TwitterAPITest
{
    [TestClass]
    public class AuthenticateTest
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

    #region Authenticate Consumer Method Parameter check

        /// <summary>
        /// Test method to check null parameter for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerNullParameter()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = null;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When null parameter is passed, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }


        /// <summary>
        /// Test method to check empty OAuthConsumerKey for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerEmptyOAuthConsumerKey()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerKey = string.Empty;          

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
           AuthResponse obAuthRespose= obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Consumer key is empty, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }


        /// <summary>
        /// Test method to check null OAuthConsumerKey for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerNullOAuthConsumerKey()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerKey = null;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Consumer key is null, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }

        /// <summary>
        /// Test method to check empty OAuthConsumerSecret for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerEmptyOAuthConsumerSecret()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerSecret = string.Empty;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Consumer Secret is empty, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }


        /// <summary>
        /// Test method to check null OAuthConsumerSecret for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerNullOAuthConsumerSecret()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerSecret = null;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Consumer Secret is null, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }

        /// <summary>
        /// Test method to check empty OAuthUrl for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerEmptyOAuthUrl()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthUrl = string.Empty;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Authentication URL is empty, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }


        /// <summary>
        /// Test method to check null OAuthUrl for AuthenticateConsumer
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerNullOAuthUrl()
        {
            //Arrange
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthUrl = null;

            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When Authentication URL  is null, the expected output is null Authentication Response.
            Assert.AreEqual(obAuthRespose, null);
        }

    #endregion

    #region Exception from method

        /// <summary>
        /// Test method AuthenticateConsumer with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException),
            "The remote server returned an error: (403) Forbidden.")]
        public void AuthenticateConsumerWithInValidAuthCredential()
        {
            //Arrange
            //**This Key needs to be replaced in case if it has expired for any reason
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerKey = "DummyKey";
            obAuthSettings.OAuthConsumerSecret = "DummySecret";
            obAuthSettings.OAuthUrl = "https://api.twitter.com/oauth2/token";
            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When all valid parameter is passed, response is expected with access token
            //Exception is ecxpected
        }

        /// <summary>
        /// Test method AuthenticateConsumer with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Net.WebException),
            "The remote server returned an error: (404) Not Found.")]
        public void AuthenticateConsumerWithInValidAuthURL()
        {
            //Arrange
            //**This Key needs to be replaced in case if it has expired for any reason
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerKey = "yEkVQqHKfqeLDiPBnGk6xtOHJ";
            obAuthSettings.OAuthConsumerSecret = "ASrjZGIQCFsBewxYYlnkKM45FHkniu0Uk8saKhZ0kloXO6d2Fy";
            obAuthSettings.OAuthUrl = "https://api.twitter.com/dummy";
            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When all valid parameter is passed, response is expected with access token
            //Exception is ecxpected
        }

     #endregion

    #region Authenticate Consumer Method with Valid Return Value

        /// <summary>
        /// Test method AuthenticateConsumer with valid parameter and get auth token
        /// </summary>
        [TestMethod]
        public void AuthenticateConsumerWithValidParameter()
        {
            //Arrange
            //**This Key needs to be replaced in case if it has expired for any reason
            AuthenticateSettings obAuthSettings = new AuthenticateSettings();
            obAuthSettings.OAuthConsumerKey = "yEkVQqHKfqeLDiPBnGk6xtOHJ";
            obAuthSettings.OAuthConsumerSecret = "ASrjZGIQCFsBewxYYlnkKM45FHkniu0Uk8saKhZ0kloXO6d2Fy";
            obAuthSettings.OAuthUrl = "https://api.twitter.com/oauth2/token";
            //Act
            IAuthenticate obAuthenticate = new Authenticate();
            AuthResponse obAuthRespose = obAuthenticate.AuthenticateConsumer(obAuthSettings);

            //Assert
            // When all valid parameter is passed, response is expected with access token
            Assert.IsTrue(obAuthRespose.TokenType != null && obAuthRespose.AccessToken != null);
        }

    #endregion

    }
}
