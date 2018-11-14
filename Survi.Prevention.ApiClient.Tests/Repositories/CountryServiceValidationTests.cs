using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class CountryServiceValidationTests
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
        public async Task ServiceCallTheRightUri()
        {
            using (var httpTest = new HttpTest())
            {
                var country = new Country();
                var repo = new CountryService();
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/Country/Import")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }
    }
}