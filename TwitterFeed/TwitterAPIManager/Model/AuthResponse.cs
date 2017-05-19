using System;
using System.Collections.Generic;

namespace TwitterAPIManager
{
    /// <summary>
    /// Authentication response model. Contains access token information.
    /// </summary>
    public class AuthResponse
    {
        
        public string TokenType { get; set; }

        public string AccessToken { get; set; }

       
    }

}
