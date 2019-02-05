using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;


namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseSecureService<T> 
        : BaseService<T> 
        where T : BaseTransferObject, new()
    {
        protected BaseSecureService(IConfiguration configuration) 
            : base(configuration)
        {
        }

        protected IFlurlRequest GenerateSecureRequest()
        {
            var request = GenerateRequest();
            return request.WithHeader("Authorization", GetAuthorizationHeaderValue());
        }

        protected string GetAuthorizationHeaderValue()
        {
            return $"{Configuration.AuthorizationType} {Configuration.AccessToken}";
        }

        protected override async Task<List<TResult>> ExecutePostAsync<TResult>(object entity, Url request)
        {
            await LoginWhenLoggedOut();
            try
            {
                return await ExecuteRequest<TResult>(entity);
            }
            catch(FlurlHttpException exception)
            { 
                if (exception.Call.AccessTokenIsExpired())
                {
                    return await RefreshTokenThenRetry<TResult>(entity);
                }
                return null;
            }            
        }

        protected async Task LoginWhenLoggedOut()
        {
            if (string.IsNullOrWhiteSpace(Configuration.AccessToken))
                await new RefreshTokenHandler(Configuration)
                    .Login();
        }

        private async Task<List<TResult>> RefreshTokenThenRetry<TResult>(object entity)
        {
            await new RefreshTokenHandler(Configuration)
                .RefreshToken();
            return await ExecuteRequest<TResult>(entity);
        }

        private async Task<List<TResult>> ExecuteRequest<TResult>(object entity)
        {
            return await ExecutePostAsync<TResult>(entity, GenerateSecureRequest());
        }
    }
}