using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services;
using Survi.Prevention.ApiClient.Tests.Mocks;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class CountryServiceValidationTests
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
        public async Task ServiceCallTheRightUri()
        {
            using (var httpTest = new HttpTest())
            {
                var country = new Country();
                var repo = new CountryService(configuration);
                await repo.SendAsync(country);

                httpTest.ShouldHaveCalled("http://test/Country/Import")
                    .WithRequestJson(country)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }
    }
}