﻿using Flurl.Http;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public class InternalErrorApiException : ApiClientException
	{
		public InternalErrorApiException(string url) : base($"API returned a 500 (internal error) response for url '{url}'.")
		{
		}

	    public InternalErrorApiException(string url, FlurlHttpException innerException) : base($"API returned a {innerException.Call.HttpStatus} error code response for url '{url}'.", innerException)
	    {
	    }
    }
}