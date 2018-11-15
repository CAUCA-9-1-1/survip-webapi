using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Exceptions;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class RefreshTokenHandlerTests
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

        [Test]
        public async Task UrlIsCorrectlyGenerated()
        {
            Configuration.Current.LoginInfo = new LoginInfo {AccessToken = "accesstoken", RefreshToken = "refreshtoken", AuthorizationType = "bearer"};

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult());
                var tokenHandler = new RefreshTokenHandler();
                await tokenHandler.RefreshToken();

                httpTest.ShouldHaveCalled("http://test/authentification/refresh");
            }
        }

        [Test]
        public async Task NewAccessTokenIsCorrectlyCopiedInTheCurrentConfiguration()
        {
            var newToken = "newtoken";

            Configuration.Current.LoginInfo = new LoginInfo { AccessToken = "accesstoken", RefreshToken = "refreshtoken", AuthorizationType = "bearer" };

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult { AccessToken = newToken});
                var tokenHandler = new RefreshTokenHandler();
                await tokenHandler.RefreshToken();

                Assert.AreEqual(newToken, Configuration.Current.LoginInfo.AccessToken);
            }
        }

        [Test]
        public void ExceptionIsCorrectlyThrownWhenRefreshTokenIsExpired()
        {
            Configuration.Current.LoginInfo = new LoginInfo { AccessToken = "accesstoken", RefreshToken = "refreshtoken", AuthorizationType = "bearer" };

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult(), 401, new { Refresh_Token_Expired = "True" });
                var tokenHandler = new RefreshTokenHandler();
                Assert.ThrowsAsync<ExpiredRefreshTokenException>(async() => await tokenHandler.RefreshToken());
            }
        }

        [Test]
        public void ExceptionIsCorrectlyThrownWhenRefreshTokenIsInvalid()
        {
            Configuration.Current.LoginInfo = new LoginInfo { AccessToken = "accesstoken", RefreshToken = "refreshtoken", AuthorizationType = "bearer" };

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult(), 401, new { Token_Invalid = "True" });
                var tokenHandler = new RefreshTokenHandler();
                Assert.ThrowsAsync<InvalidRefreshTokenException>(async () => await tokenHandler.RefreshToken());
            }
        }

        [Test]
        public async Task NullIsCorrectlyReturnedForAnyOtherReason()
        {
            Configuration.Current.LoginInfo = new LoginInfo { AccessToken = "accesstoken", RefreshToken = "refreshtoken", AuthorizationType = "bearer" };

            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new TokenRefreshResult(), 404);
                var tokenHandler = new RefreshTokenHandler();
                await tokenHandler.RefreshToken();

                Assert.IsNull(Configuration.Current.LoginInfo.AccessToken);
            }
        }
    }
}
