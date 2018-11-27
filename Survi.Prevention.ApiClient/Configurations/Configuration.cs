namespace Survi.Prevention.ApiClient.Configurations
{
    public interface IConfiguration
    {
        string ApiBaseUrl { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string AuthorizationType { get; set; }
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
    }

    /*public class Configuration
    {
        private static Configuration currentConfiguration;
        public static Configuration Current => currentConfiguration ?? (currentConfiguration = new Configuration());

        public string ApiBaseUrl { get; set; }
        public LoginInfo LoginInfo { get; set; }

        public static void ResetConfiguration()
        {
            currentConfiguration = null;
        }
    }*/
}
