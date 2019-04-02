using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;
using Survi.Prevention.ApiClient.Tests.Mocks;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RefreshTokenHandlerTests
    {
        private IConfiguration configuration;

        [SetUp]
        public void SetupTest()
        {
            configuration = new MockConfiguration
            {
                ApiBaseUrl = "http://test",
                AccessToken = "accesstoken",
                RefreshToken = "refreshtoken",
                AuthorizationType = "bearer"
            };
        }

        [Test]
        public async Task UrlIsCorrectlyGenerated()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult());
                var tokenHandler = new RefreshTokenHandler(configuration);
                await tokenHandler.RefreshToken();

                httpTest.ShouldHaveCalled("http://test/Authentification/refresh");
            }
        }

        [Test]
        public async Task NewAccessTokenIsCorrectlyCopiedInTheCurrentConfiguration()
        {
            var newToken = "newtoken";

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult { AccessToken = newToken});
                var tokenHandler = new RefreshTokenHandler(configuration);
                await tokenHandler.RefreshToken();

                Assert.AreEqual(newToken, configuration.AccessToken);
            }
        }   

        [Test]
        public async Task NullIsCorrectlyReturnedForAnyOtherReason()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult(), 404);
                var tokenHandler = new RefreshTokenHandler(configuration);
                await tokenHandler.RefreshToken();

                Assert.IsNull(configuration.AccessToken);
            }
        }
    }
}
