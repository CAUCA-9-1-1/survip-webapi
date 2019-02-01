using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public class BadParameterApiException : ApiClientException
	{
		public BadParameterApiException(string url, Exception innerException = null) : base($"API returned a 400 (bad request) response for url '{url}'.", innerException)
		{
		}
	}
}