using System;
namespace TwitterAPIManager
{
    /// <summary>
    ///  Provides the access token information using twitter oAuth APIs.
    /// </summary>
	public interface IAuthenticate
	{
		AuthResponse AuthenticateConsumer(IAuthenticateSettings authenticateSettings);
	}
}
