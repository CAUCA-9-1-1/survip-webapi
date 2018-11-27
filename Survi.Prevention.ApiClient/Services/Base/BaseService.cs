using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseTransferObject, new()
    {
        protected abstract string BaseUrl { get; set; }
        protected IConfiguration Configuration { get; set; }

        protected BaseService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected virtual Url GenerateRequest()
        {
            return Configuration.ApiBaseUrl
                .AppendPathSegment(BaseUrl);
        }

        public virtual async Task<ImportationResult> SendAsync(T entity)
        {
            return await SendObjectAsync(new List<T> {entity});
        }

        public virtual async Task<ImportationResult> SendAsync(List<T> entity)
        {
            return await SendObjectAsync(entity);
        }

        private async Task<ImportationResult> SendObjectAsync(object entity)
        {
            var request = GenerateRequest();
            try
            {
                return await ExecuteAsync(entity, request);
            }
            catch (FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded, exception.Call.HttpStatus);
                return null;
            }
        }

        protected virtual async Task<ImportationResult> ExecuteAsync(object entity, Url request)
        {
            return await request
                .PostJsonAsync(entity)
                .ReceiveJson<ImportationResult>();
        }

        protected virtual async Task<ImportationResult> ExecuteAsync(object entity, IFlurlRequest request)
        {
            return await request
                .PostJsonAsync(entity)
                .ReceiveJson<ImportationResult>();
        }
    }
}