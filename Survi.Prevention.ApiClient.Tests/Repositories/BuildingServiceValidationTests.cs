using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Building;
using Survi.Prevention.ApiClient.Services.Places;
using Survi.Prevention.ApiClient.Tests.Mocks;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    public class BuildingServiceValidationTests
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
        public async Task ServiceCallTheRightUriForImport()
        {
            using (var httpTest = new HttpTest())
            {
                var building = new Building();
                var repo = new BuildingService(configuration);
                await repo.SendAsync<ImportationResult>(building);

                httpTest.ShouldHaveCalled("http://test/Building/Import")
                    .WithRequestJson(building)
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestCase]
        public async Task ServiceCallTheRightUriForExport()
        {
            using (var httpTest = new HttpTest())
            {
                var repo = new BuildingService(configuration);
                await repo.GetAsync(new List<string>{"",""});

                httpTest.ShouldHaveCalled("http://test/Building/Export")
                    .WithRequestJson(new List<string> { "", "" })
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }
    }
}
