using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public static class RestResponseExtensions
    {
        public const string RefreshTokenExpired = "Refresh-Token-Expired";
        public const string TokenInvalid = "Token-Invalid";
        public const string TokenExpired = "Token-Expired";

        public static bool RefreshTokenIsExpired(this HttpCall response)
        {
            //response.
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized;
            //&& response.h Headers.ToList().Any(h => h.Name == RefreshTokenExpired);
        }

        public static bool RefreshTokenIsInvalid(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized;
            //&& response.Headers.ToList().Any(h => h.Name == TokenInvalid);
        }

        public static bool AccessTokenIsExpired(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized;
            //     && response.Headers.ToList().Any(h => h.Name == TokenExpired);
        }
    }
}