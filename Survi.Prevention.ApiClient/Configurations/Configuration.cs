namespace Survi.Prevention.ApiClient.Configurations
{
    public class Configuration
    {
        private static Configuration currentConfiguration;
        public static Configuration Current => currentConfiguration ?? (currentConfiguration = new Configuration());

        public string ApiBaseUrl { get; set; }
        public LoginInfo LoginInfo { get; set; }

        public static void ResetConfiguration()
        {
            currentConfiguration = null;
        }
    }
}
