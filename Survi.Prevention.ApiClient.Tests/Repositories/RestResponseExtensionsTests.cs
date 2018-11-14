using NUnit.Framework;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RestResponseExtensionsTests : BaseRestResponseTests
    {
        [TestCase]
        public void ExpiredRefreshTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.RefreshTokenExpired);
            Assert.IsTrue(response.RefreshTokenIsExpired());
        }

        [TestCase]
        public void InvalidAccessTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.RefreshTokenInvalid);
            Assert.IsTrue(response.RefreshTokenIsInvalid());
        }

        [TestCase]
        public void ExpiredAccessTokenIsCorrectlyDetected()
        {
            var response = GetResponse(System.Net.HttpStatusCode.Unauthorized, RestResponseExtensions.AccessTokenExpired);
            Assert.IsTrue(response.AccessTokenIsExpired());
        }
    }
}
