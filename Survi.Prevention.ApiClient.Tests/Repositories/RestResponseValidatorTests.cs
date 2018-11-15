using System.Net;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Exceptions;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RestResponseValidatorTests : BaseRestResponseTests
    {
       [Test]
        public void CorrectlyThrowsNotFoundException()
        {
            Assert.Throws<NotFoundApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.NotFound));
        }

        [Test]
        public void CorrectlyThrowsBadParameterException()
        {
            Assert.Throws<BadParameterApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.BadRequest));
        }

        [Test]
        public void CorrectlyThrowsUnauthorizedException()
        {
            Assert.Throws<UnauthorizedApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.Unauthorized));
        }

        [Test]
        public void CorrectlyThrowsForbiddenException()
        {
            Assert.Throws<ForbiddenApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.Forbidden));
        }

        [Test]
        public void CorrectlyThrowsInternalErrorException()
        {
            Assert.Throws<InternalErrorApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.InternalServerError));
        }

        [Test]
        public void CorrectlyThrowsNoResponseForZeroStatusCode()
        {
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", false, 0));
        }        

        [Test]
        public void CorrectlyThrowsNoResponseForResponseStatusTimedOut()
        {
            Assert.Throws<NoResponseApiException>(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", false, HttpStatusCode.RequestTimeout));
        }

        [Test]
        public void DoesNoThrowExceptionWhenNoErrors()
        {
            Assert.DoesNotThrow(() => new RestResponseValidator().ThrowExceptionForStatusCode("test", true, HttpStatusCode.OK));
        }
    }
}
