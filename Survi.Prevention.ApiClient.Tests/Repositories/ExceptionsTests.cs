using NUnit.Framework;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class ExceptionsTests
    {
        private static string Url = "http://www.test.com/";

        [TestCase]
        public static void BadParameterApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API returned a 400 (bad request) response for url 'http://www.test.com/'.", new BadParameterApiException(Url).Message);
        }

        [TestCase]
        public static void ExpiredRefreshTokenExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("The refresh token is expired.", new ExpiredRefreshTokenException().Message);
        }

        [TestCase]
        public static void ForbiddenApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API returned a 403 (forbidden) response for url 'http://www.test.com/'.", new ForbiddenApiException(Url).Message);
        }

        [TestCase]
        public static void InternalErrorApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API returned a 500 (internal error) response for url 'http://www.test.com/'.", new InternalErrorApiException(Url).Message);
        }

        [TestCase]
        public static void InvalidRefreshTokenApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("The refresh token is invalid.", new InvalidRefreshTokenException().Message);
        }

        [TestCase]
        public static void NoResponseApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API didn't return an answer in a timely manner.", new NoResponseApiException().Message);
        }

        [TestCase]
        public static void NotFoundApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API returned a 404 (not found) response for url 'http://www.test.com/'.", new NotFoundApiException(Url).Message);
        }

        [TestCase]
        public static void UnauthorizedApiExceptionMessageIsCorrectlyGenerated()
        {
            Assert.AreEqual("API returned a 401 (unauthorized) response for url 'http://www.test.com/'.", new UnauthorizedApiException(Url).Message);
        }
    }
}
