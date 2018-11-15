using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public abstract class ApiClientException : Exception
	{
		protected ApiClientException(string message) : base(message)
		{
		}
	}
}