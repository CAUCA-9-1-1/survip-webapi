namespace Survi.Prevention.ApiClient.Exceptions
{
	public class InternalErrorApiException : ApiClientException
	{
		public InternalErrorApiException(string url) : base($"API returned a 500 (internal error) response for url '{url}'.")
		{
		}
	}
}