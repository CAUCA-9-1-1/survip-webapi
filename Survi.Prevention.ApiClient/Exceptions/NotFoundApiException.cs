namespace Survi.Prevention.ApiClient.Exceptions
{
	public class NotFoundApiException : ApiClientException
	{
		public NotFoundApiException(string url) : base($"API returned a 404 (not found) response for url '{url}'.")
		{
		}
	}
}