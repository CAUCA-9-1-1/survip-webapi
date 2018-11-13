using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public class RefreshTokenHandler
    {
        private Url GenerateRequest()
        {
            return Configuration.Current.ApiBaseUrl
                .AppendPathSegment("authentification")
                .AppendPathSegment("refresh");
        }

        public async Task RefreshToken()
        {
            var token = await GetNewAccessToken();
            Configuration.Current.LoginInfo.AccessToken = token;
        }

        private async Task<string> GetNewAccessToken()
        {
            var request = GenerateRequest();

            try
            {
                var response = await request
                    .PostJsonAsync(GetRefreshTokenBody())
                    .ReceiveJson<TokenRefreshResult>();
                return response.AccessToken;
            }
            catch(FlurlHttpException exception)
            {
                if (exception.Call.RefreshTokenIsExpired())
                    throw new ExpiredRefreshTokenException();
                if (exception.Call.RefreshTokenIsInvalid())
                    throw new InvalidRefreshTokenException();
            }
            return null;
        }

        private static TokenRefreshResult GetRefreshTokenBody()
        {
            return new TokenRefreshResult
            {
                AccessToken = Configuration.Current.LoginInfo.AccessToken,
                RefreshToken = Configuration.Current.LoginInfo.RefreshToken
            };
        }
    }
}