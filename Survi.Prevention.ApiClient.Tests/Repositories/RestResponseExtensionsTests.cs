using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RestSharp;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RestResponseExtensionsTests
    {
        private static IRestResponse<TokenRefreshResult> GetResponse(System.Net.HttpStatusCode code, string headerName)
        {
            var mockResponse = new Mock<IRestResponse<TokenRefreshResult>>();
            mockResponse.Setup(res => res.StatusCode)
                .Returns(code);
            mockResponse.Setup(res => res.Headers)
                .Returns(new List<Parameter> { new Parameter { Name = headerName } });
            return mockResponse.Object;
        }

        [TestCase]
        public void ExpiredRefreshTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.RefreshTokenExpired);
            Assert.IsTrue(response.RefreshTokenIsExpired());
        }

        [TestCase]
        public void InvalidRefreshTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.TokenInvalid);
            Assert.IsTrue(response.RefreshTokenIsInvalid());
        }

        [TestCase]
        public void InvalidAccessTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.RefreshTokenExpired);
            Assert.IsTrue(response.RefreshTokenIsExpired());
        }
    }
}
