using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public class RefreshTokenHandler
    {
        protected IConfiguration Configuration { get; set; }

        public RefreshTokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private Url GenerateRefreshRequest()
        {
            return Configuration.ApiBaseUrl
                .AppendPathSegment("Authentification")
                .AppendPathSegment("refresh");
        }

        private Url GenerateLoginRequest()
        {
            return Configuration.ApiBaseUrl
                .AppendPathSegment("Authentification")
                .AppendPathSegment("logon");
        }

        public async Task RefreshToken()
        {
            var token = await GetNewAccessToken();
            Configuration.AccessToken = token;
        }

        public async Task Login()
        {
            var login = await GetInitialAccessToken();
            Configuration.AccessToken = login.TokenForAccess;
            Configuration.RefreshToken = login.RefreshToken;
        }

        private async Task<LoginResult> GetInitialAccessToken()
        {
            var request = GenerateLoginRequest();

            try
            {
                var response = await request
                    .PostJsonAsync(new {Configuration.UserName, Configuration.Password})
                    .ReceiveJson<LoginResult>();
                return response;
            }
            catch (FlurlHttpException exception)
            {
                if (exception.Call.IsUnauthorized())
                    throw new InvalidCredentialException(Configuration.UserName);

                if (exception.Call.NoResponse())
                    throw new NoResponseApiException();
            }
            return null;
        }

        private async Task<string> GetNewAccessToken()
        {
            var request = GenerateRefreshRequest();

            try
            {
                var response = await request
                    .PostJsonAsync(GetRefreshTokenBody())
                    .ReceiveJson<TokenRefreshResult>();
                return response.AccessToken;
            }
            catch (FlurlHttpException exception)
            {
                if (exception.Call.RefreshTokenIsExpired() || exception.Call.RefreshTokenIsInvalid())
                    await Login();
            }

            return null;
        }

        private TokenRefreshResult GetRefreshTokenBody()
        {
            return new TokenRefreshResult
            {
                AccessToken = Configuration.AccessToken,
                RefreshToken = Configuration.RefreshToken
            };
        }
    }
}