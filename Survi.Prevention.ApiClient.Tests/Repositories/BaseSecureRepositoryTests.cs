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
        public void AuthorizationHeaderIsCorrectlyGenerated()
        {
            Assert.AreEqual("Mock Token", new MockSecureRepository(configuration).GetAuthorizationHeaderValue());
        }

        [TestCase]
        public async Task RequestIsCorrectlyExecuted()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new MockSecureRepository(configuration);
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestCase]
        public async Task RequestLoginBeforeExecutingWhenNotLoggedIn()
        {
            configuration.AccessToken = null;
            configuration.RefreshToken = null;

            using (var httpTest = new HttpTest())
            {
                httpTest
                    .RespondWithJson(new LoginResult { AuthorizationType = "Bearer", RefreshToken = "NewRefreshToken", TokenForAccess = "NewAccessToken" })
                    .RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new MockSecureRepository(configuration);
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/Authentification/logon")
                    .WithVerb(HttpMethod.Post)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.OK)
                    .Times(1);
            }
        }

        [TestCase]
        public async Task LoginCorrectlySetAccessAndRefreshToken()
        {
            configuration.AccessToken = null;
            configuration.RefreshToken = null;

            using (var httpTest = new HttpTest())
            {
                httpTest
                    .RespondWithJson(new LoginResult { AuthorizationType = "Bearer", RefreshToken = "NewRefreshToken", TokenForAccess = "NewAccessToken" })
                    .RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new MockSecureRepository(configuration);
                await repo.SendAsync(country);

                Assert.AreEqual("NewRefreshToken", configuration.RefreshToken);
                Assert.AreEqual("NewAccessToken", configuration.AccessToken);
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
                var repo = new MockSecureRepository(configuration);
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)                    
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/Authentification/refresh")
                    .WithVerb(HttpMethod.Post)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)                    
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.OK)
                    .Times(1);
            }
        }

        [TestCase]
        public async Task RequestLogBackInWhenRefreshTokenAndAccessTokenAreExpired()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest
                    .RespondWithJson(new ImportationResult(), 401, new { Token_Expired = "True" })
                    .RespondWithJson(new TokenRefreshResult(), 401, new { Refresh_Token_Expired = true })
                    .RespondWithJson(new TokenRefreshResult { AccessToken = "NewToken" })
                    .RespondWithJson(new ImportationResult());

                var country = new Country();
                var repo = new MockSecureRepository(configuration);
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/mock")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/Authentification/refresh")
                    .WithVerb(HttpMethod.Post)
                    .With(call => call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    .Times(1);

                httpTest.ShouldHaveCalled("http://test/Authentification/logon")
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