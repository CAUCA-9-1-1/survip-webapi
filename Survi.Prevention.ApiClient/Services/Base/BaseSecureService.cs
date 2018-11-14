using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseSecureService<T> : BaseService<T> where T : BaseTransferObject, new()
    {
        protected IFlurlRequest GenerateSecureRequest()
        {
            var request = GenerateRequest();
            return request.WithHeader("Authorization", GetAuthorizationHeaderValue());
        }

        protected string GetAuthorizationHeaderValue()
        {
            return $"{Configuration.Current.LoginInfo.AuthorizationType} {Configuration.Current.LoginInfo.AccessToken}";
        }

        protected override async Task<ImportationResult> ExecuteAsync(object entity, Url request)
        {            
            try
            {
                return await ExecuteRequest(entity);
            }
            catch(FlurlHttpException exception)
            { 
                if (exception.Call.AccessTokenIsExpired())
                {
                    return await RefreshTokenThenRetry(entity);
                }
                return null;
            }            
        }

        private async Task<ImportationResult> RefreshTokenThenRetry(object entity)
        {
            await new RefreshTokenHandler()
                .RefreshToken();
            Console.WriteLine("Reauthenticated...");
            return await ExecuteRequest(entity);
        }

        private async Task<ImportationResult> ExecuteRequest(object entity)
        {
            return await ExecuteAsync(entity, GenerateSecureRequest());
        }
    }
}