using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Tests.Mocks
{
    public class MockConfiguration : IConfiguration
    {
        public string ApiBaseUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthorizationType { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
