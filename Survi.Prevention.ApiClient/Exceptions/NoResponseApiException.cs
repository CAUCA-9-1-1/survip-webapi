namespace Survi.Prevention.ApiClient.Exceptions
{
	public class NoResponseApiException : ApiClientException
	{
		public NoResponseApiException() : base("API didn't return an answer in a timely manner.")
		{
		}
	}
}