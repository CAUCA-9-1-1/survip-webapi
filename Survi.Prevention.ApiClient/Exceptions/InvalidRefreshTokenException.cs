using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public class InvalidRefreshTokenException : Exception
	{
		public InvalidRefreshTokenException() : base("The refresh token is invalid.")
		{
		}
	}
}