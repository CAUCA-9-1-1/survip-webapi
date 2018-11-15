using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public class ExpiredRefreshTokenException : Exception
	{
		public ExpiredRefreshTokenException() : base("The refresh token is expired.")
		{
		}
	}
}