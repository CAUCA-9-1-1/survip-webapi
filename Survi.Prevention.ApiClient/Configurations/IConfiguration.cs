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
        int RequestTimeoutInSeconds { get; set; }
        int RequestBatchSize { get; set; }
    }
}
