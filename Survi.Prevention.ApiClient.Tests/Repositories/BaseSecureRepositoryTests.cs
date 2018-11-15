using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Tests.Mocks;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class BaseSecureRepositoryTests
    {
        [SetUp]
        public void SetupTest()
        {
            Configuration.Current.ApiBaseUrl = "http://test/";
            Configuration.Current.LoginInfo = new LoginInfo { AccessToken = "Token", RefreshToken = "RefreshToken", AuthorizationType = "Mock" };
        }

        [TearDown]
        public void ResetTest()
        {
            Configuration.ResetConfiguration();
        }

        [TestCase]
        public void AuthorizationHeaderIsCorrectlyGenerated()
        {
            Assert.AreEqual("Mock Token", new MockSecureRepository().GetAuthorizationHeaderValue());
        }

        [TestCase]
        public async Task RequestIsCorrectlyExecuted()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new Mocks.MockSecureRepository();
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestCase]
        public async Task RequestRefreshTokenThenRetryWhenItsExpired()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest
                    .RespondWithJson(new ImportationResult(), 401, new { Token_Expired = "True" })
                    .RespondWithJson(new TokenRefreshResult {AccessToken = "NewToken"})
                    .RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new Mocks.MockSecureRepository();
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)                    
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/authentification/refresh")
                    .WithVerb(HttpMethod.Post)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)                    
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.OK)
                    .Times(1);
            }
        }
    }
}