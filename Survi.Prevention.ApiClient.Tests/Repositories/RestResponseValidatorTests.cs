using System.Net;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Exceptions;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RestResponseValidatorTests : BaseRestResponseTests
    {
       /* [Test]
        public void CorrectlyThrowsNotFoundException()
        {
            var response = GetResponse(HttpStatusCode.NotFound, "test");
            Assert.Throws<NotFoundApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsBadParameterException()
        {
            var response = GetResponse(HttpStatusCode.BadRequest, "test");
            Assert.Throws<BadParameterApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsUnauthorizedException()
        {
            var response = GetResponse(HttpStatusCode.Unauthorized, "test");
            Assert.Throws<UnauthorizedApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsForbiddenException()
        {
            var response = GetResponse(HttpStatusCode.Forbidden, "test");
            Assert.Throws<ForbiddenApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsInternalErrorException()
        {
            var response = GetResponse(HttpStatusCode.InternalServerError, "test");
            Assert.Throws<InternalErrorApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsNoResponseForZeroStatusCode()
        {
            var response = GetResponse(0, "test");
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsNoResponseForResponseStatusError()
        {
            var response = GetResponse(HttpStatusCode.OK, "test", RestSharp.ResponseStatus.Error);
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }
        
        [Test]
        public void CorrectlyThrowsNoResponseForResponseStatusNone()
        {
            var response = GetResponse(HttpStatusCode.OK, "test", RestSharp.ResponseStatus.None);
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }

        [Test]
        public void CorrectlyThrowsNoResponseForResponseStatusTimedOut()
        {
            var response = GetResponse(HttpStatusCode.OK, "test", RestSharp.ResponseStatus.TimedOut);
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionWhenResponseHasErrorCode(response, "test"));
        }*/
    }
}
