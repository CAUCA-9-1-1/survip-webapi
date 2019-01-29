using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Flurl.Http.Testing;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Exceptions;
using Survi.Prevention.ApiClient.Tests.Mocks;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class BaseRepositoryTests
    {
        private IConfiguration configuration;

        [SetUp]
        public void SetupTest()
        {
            configuration = new MockConfiguration
            {
                ApiBaseUrl = "http://test",
                AccessToken = "Token",
                RefreshToken = "RefreshToken",
                AuthorizationType = "Mock"
            };
        }

        [TestCase]
        public async Task RequestIsCorrectlyExecuted()
        {
            using (var httpTest = new HttpTest())
            {
                var country = new Country();
                var repo = new MockRepository(configuration);
                await repo.SendAsync<ImportationResult>(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenUrlIsNotFound()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), 404);
                var country = new Country();
                var repo = new MockRepository(configuration);
                Assert.ThrowsAsync<NotFoundApiException>(async() => await repo.SendAsync<ImportationResult>(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingBadParameters()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), 400);
                var country = new Country();
                var repo = new MockRepository(configuration);
                Assert.ThrowsAsync<BadParameterApiException>(async () => await repo.SendAsync<ImportationResult>(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingForbidden()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), 403);
                var country = new Country();
                var repo = new MockRepository(configuration);
                Assert.ThrowsAsync<ForbiddenApiException>(async () => await repo.SendAsync<ImportationResult>(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingInternalError()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), 500);
                var country = new Country();
                var repo = new MockRepository(configuration);
                Assert.ThrowsAsync<InternalErrorApiException>(async () => await repo.SendAsync<ImportationResult>(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenNotGettingAnAnswer()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.SimulateTimeout();
                var country = new Country();
                var repo = new MockRepository(configuration);
                Assert.ThrowsAsync<NoResponseApiException>(async () => await repo.SendAsync<ImportationResult>(country));
            }
        }
    }
}
