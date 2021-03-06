﻿using System;

namespace Survi.Prevention.ApiClient.Exceptions
{
	public abstract class ApiClientException : Exception
	{
		protected ApiClientException(string message, Exception innerException) : base(message, innerException)
		{
		}

	    protected ApiClientException(string message) : base(message)
	    {
	    }
    }
}