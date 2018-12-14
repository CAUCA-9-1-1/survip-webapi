using System;
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

        public virtual async Task<List<ImportationResult>> SendAsync(T entity)
        {
            return await SendObjectAsync(new List<T> {entity});
        }

        public virtual async Task<List<ImportationResult>> SendAsync(List<T> entities, IProgress<int> progressReporter = null)
        {
            var results = new List<ImportationResult>();
            var sentEntities = 0;
            foreach (var partialLists in GetSplittedLists(entities, Configuration.RequestBatchSize))
            {
                results.AddRange(await SendObjectAsync(partialLists));
                sentEntities += partialLists.Count;
                progressReporter?.Report(sentEntities * 100 / entities.Count);
            }

            return results;
        }

        private async Task<List<ImportationResult>> SendObjectAsync(object entity)
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
                //throw;
                return null;
            }
        }

        protected virtual async Task<List<ImportationResult>> ExecuteAsync(object entity, Url request)
        {
            return await request
                .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                .PostJsonAsync(entity)
                .ReceiveJson<List<ImportationResult>>();
        }

        protected virtual async Task<List<ImportationResult>> ExecuteAsync(object entity, IFlurlRequest request)
        {
            return await request
                .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                .PostJsonAsync(entity)
                .ReceiveJson<List<ImportationResult>>();
        }

        private static IEnumerable<List<T>> GetSplittedLists(List<T> list, int nSize = 30)
        {
            for (int i = 0; i < list.Count; i += nSize)
                yield return list.GetRange(i, Math.Min(nSize, list.Count - i));
        }
    }
}