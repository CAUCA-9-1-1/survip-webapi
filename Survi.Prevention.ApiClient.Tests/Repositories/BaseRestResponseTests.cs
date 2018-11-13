using System.Collections.Generic;
using Moq;
using RestSharp;
using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    public abstract class BaseRestResponseTests
    {
        protected static IRestResponse<TokenRefreshResult> GetResponse(System.Net.HttpStatusCode code, string headerName, ResponseStatus? status = null)
        {
            var mockResponse = new Mock<IRestResponse<TokenRefreshResult>>();
            mockResponse.Setup(res => res.StatusCode)
                .Returns(code);
            mockResponse.Setup(res => res.Headers)
                .Returns(new List<Parameter> { new Parameter { Name = headerName } });
            if (status != null)
            {
                mockResponse.Setup(res => res.ResponseStatus)
                    .Returns(status.Value);
            }
            return mockResponse.Object;
        }
    }
}