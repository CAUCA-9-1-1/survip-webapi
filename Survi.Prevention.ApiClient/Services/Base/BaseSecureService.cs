using System;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseSecureService<T> : BaseService<T> where T : BaseTransferObject, new()
    {
        protected override IRestRequest GenerateRequest(Method method)
        {
            var request = base.GenerateRequest(method);
            request.AddParameter("Authorization", GetAuthorizationHeaderValue(), ParameterType.HttpHeader);
            return request;
        }

        protected string GetAuthorizationHeaderValue()
        {
            return $"{Configuration.Current.LoginInfo.AuthorizationType} {Configuration.Current.LoginInfo.AccessToken}";
        }

        protected override async Task<IRestResponse<ImportationResult>> ExecuteAsync(IRestClient client, IRestRequest request)
        {
            var response = await client.ExecuteTaskAsync<ImportationResult>(request);

            if (response.AccessTokenIsInvalid())
            {
                Configuration.Current.LoginInfo.AccessToken = await RefreshAccessToken(client);
                Console.WriteLine("Reauthenticated...");
                request.Parameters.ToList().First(p => p.Name == "Authorization").Value = GetAuthorizationHeaderValue();
                response = await client.ExecuteTaskAsync<ImportationResult>(request);
            }

            ThrowExceptionWhenResponseHasErrorCode(response, client.BuildUri(request).ToString());

            return response;
        }

        private async Task<string> RefreshAccessToken(IRestClient client)
        {
            var request = new RestRequest("authentification/refresh", Method.POST);
            request.AddJsonBody(new TokenRefreshResult {AccessToken = Configuration.Current.LoginInfo.AccessToken, RefreshToken = Configuration.Current.LoginInfo.RefreshToken});
            var response = await client.ExecutePostTaskAsync<TokenRefreshResult>(request);

            if (response.RefreshTokenIsExpired())
                throw new ExpiredRefreshTokenException();
            if (response.RefreshTokenIsInvalid())
                throw new InvalidRefreshTokenException();

            return response.Data.AccessToken;
        }

        public async Task<bool> GetNewAccessToken()
        {
            var client = new RestClient(Configuration.Current.ApiBaseUrl);
            var request = new RestRequest("authentification", Method.POST);

            var response = await client.ExecutePostTaskAsync<TokenRefreshResult>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Configuration.Current.LoginInfo.AccessToken = response.Data.AccessToken;
                return true;
            }

            if (response.RefreshTokenIsExpired())
                throw new ExpiredRefreshTokenException();
            if (response.RefreshTokenIsInvalid())
                throw new InvalidRefreshTokenException();

            return false;
        }
    }
}