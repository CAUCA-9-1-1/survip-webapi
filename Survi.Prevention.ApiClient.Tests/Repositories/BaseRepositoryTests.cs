using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Flurl.Http.Testing;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class BaseRepositoryTests
    {
        [SetUp]
        public void SetupTest()
        {
            Configuration.Current.ApiBaseUrl = "http://test/";
        }

        [TearDown]
        public void ResetTest()
        {
            Configuration.ResetConfiguration();
        }

        [TestCase]
        public async Task RequestIsCorrectlyExecuted()
        {
            using (var httpTest = new HttpTest())
            {
                var country = new Country();
                var repo = new Mocks.MockRepository();
                await repo.SendAsync(country);

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
                httpTest.RespondWithJson(new ImportationResult(), status: 404);//, headers: new { Refresh_Token_Expired = "True" });
                var country = new Country();
                var repo = new Mocks.MockRepository();
                Assert.ThrowsAsync<NotFoundApiException>(async() => await repo.SendAsync(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingBadParameters()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), status: 400);//, headers: new { Refresh_Token_Expired = "True" });
                var country = new Country();
                var repo = new Mocks.MockRepository();
                Assert.ThrowsAsync<BadParameterApiException>(async () => await repo.SendAsync(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingForbidden()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), status: 403);//, headers: new { Refresh_Token_Expired = "True" });
                var country = new Country();
                var repo = new Mocks.MockRepository();
                Assert.ThrowsAsync<ForbiddenApiException>(async () => await repo.SendAsync(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenGettingInternalError()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult(), status: 500);//, headers: new { Refresh_Token_Expired = "True" });
                var country = new Country();
                var repo = new Mocks.MockRepository();
                Assert.ThrowsAsync<InternalErrorApiException>(async () => await repo.SendAsync(country));
            }
        }

        [TestCase]
        public void RequestIsThrowingErrorWhenNotGettingAnAnswer()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.SimulateTimeout();
                var country = new Country();
                var repo = new Mocks.MockRepository();
                Assert.ThrowsAsync<NoResponseApiException>(async () => await repo.SendAsync(country));
            }
        }
    }

    [TestFixture]
    public class BaseSecureRepositoryTests
    {
        [SetUp]
        public void SetupTest()
        {
            Configuration.Current.ApiBaseUrl = "http://test/";
        }

        [TearDown]
        public void ResetTest()
        {
            Configuration.ResetConfiguration();
        }

        [TestCase]
        public async Task RequestIsCorrectlyExecuted()
        {
            using (var httpTest = new HttpTest())
            {                
                httpTest.RespondWithJson(new ImportationResult(), status: 200);
                var country = new Country();
                var repo = new Mocks.MockRepository();
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        

    }
}
