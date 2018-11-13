using NUnit.Framework;
using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Tests.Repositories
{
    [TestFixture]
    public class ConfigurationTests
    {
        [TestCase]
        public void ConfigurationSingletonIsCorrectlySet()
        {
            Configuration.Current.ApiBaseUrl = "http";
            Assert.AreEqual("http", Configuration.Current.ApiBaseUrl);
        }

        [TearDown]
        public void RemoveConfiguration()
        {
            Configuration.ResetConfiguration();
        }
    }
}
