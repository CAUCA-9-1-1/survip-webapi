using System.Linq;
using RestSharp;
using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public static class RestResponseExtensions
    {
        public const string RefreshTokenExpired = "Refresh-Token-Expired";
        public const string TokenInvalid = "Token-Invalid";
        public const string TokenExpired = "Token-Expired";

        public static bool RefreshTokenIsExpired(this IRestResponse<TokenRefreshResult> response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                   && response.Headers.ToList().Any(h => h.Name == RefreshTokenExpired);
        }

        public static bool RefreshTokenIsInvalid(this IRestResponse<TokenRefreshResult> response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                   && response.Headers.ToList().Any(h => h.Name == TokenInvalid);
        }

        public static bool AccessTokenIsInvalid<T>(this IRestResponse<T> response)
        {
            return response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                   && response.Headers.ToList().Any(h => h.Name == TokenExpired);
        }
    }
}