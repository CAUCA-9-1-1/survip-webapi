using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public class NoResponseApiException : ApiClientException
	{
		public NoResponseApiException(Exception innerException = null) : base("API didn't return an answer in a timely manner.", innerException)
		{
		}
	}
}