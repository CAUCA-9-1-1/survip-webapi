using System.Linq;
using Flurl.Http;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public static class RestResponseExtensions
    {
        public const string RefreshTokenExpired = "Refresh-Token-Expired";
        public const string RefreshTokenInvalid = "Token-Invalid";
        public const string AccessTokenExpired = "Token-Expired";

        public static bool IsUnauthorized(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized;
        }

        public static bool RefreshTokenIsExpired(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized
                && response.Response.Headers.ToList().Any(h => h.Key == RefreshTokenExpired);
        }

        public static bool RefreshTokenIsInvalid(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized
                && response.Response.Headers.ToList().Any(h => h.Key == RefreshTokenInvalid);
        }

        public static bool AccessTokenIsExpired(this HttpCall response)
        {
            return response.HttpStatus == System.Net.HttpStatusCode.Unauthorized
                && response.Response.Headers.ToList().Any(h => h.Key == AccessTokenExpired);
        }

        public static bool NoResponse(this HttpCall response)
        {
            return response.Response == null;
        }
    }
}