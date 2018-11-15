using System.Net.Http;
using Flurl.Http;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    public abstract class BaseRestResponseTests
    {
        protected static HttpCall GetResponse(System.Net.HttpStatusCode code, string headerName)
        {
            var response = new HttpResponseMessage();
            response.Headers.Add(headerName, "True");
            response.StatusCode = code;
            return new HttpCall {Response = response};
        }
    }
}