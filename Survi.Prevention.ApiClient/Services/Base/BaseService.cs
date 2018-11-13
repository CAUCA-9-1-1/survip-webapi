using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseService<T> 
        where T : BaseTransferObject, new()
    {
        protected abstract string BaseUrl { get; set; }

        protected virtual Url GenerateRequest()
        {
            return Configuration.Current.ApiBaseUrl
                .AppendPathSegment(BaseUrl);
        }

        public virtual async Task<ImportationResult> SendAsync(T entity)
        {
            var request = GenerateRequest();
            try
            {
                return await ExecuteAsync(entity, request);
            }
            catch(FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded, exception.Call.HttpStatus);
                return null;
            }
        }

        protected virtual async Task<ImportationResult> ExecuteAsync(T entity, Url request)
        {
            return await request
                .PostJsonAsync(entity)
                .ReceiveJson<ImportationResult>();
        }

        protected virtual async Task<ImportationResult> ExecuteAsync(T entity, IFlurlRequest request)
        {
            return await request
                .PostJsonAsync(entity)
                .ReceiveJson<ImportationResult>();
        }
    }
}
