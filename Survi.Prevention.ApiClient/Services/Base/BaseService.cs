using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseTransferObject, new()
    {
        protected abstract string BaseUrl { get; set; }
        protected IConfiguration Configuration { get; set; }
        protected string RequestBaseUrl { get; set; } = "";

        protected BaseService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected virtual Url GenerateRequest()
        {
            if (string.IsNullOrEmpty(RequestBaseUrl))
                RequestBaseUrl = BaseUrl;

            return Configuration.ApiBaseUrl                
                .AppendPathSegment(RequestBaseUrl);
        }

        public virtual async Task<List<TResult>> SendAsync<TResult>(T entity)
        {
            return await SendObjectAsync<TResult>(new List<T> {entity});
        }

        public virtual async Task<List<TResult>> SendAsync<TResult>(List<T> entities, IProgress<int> progressReporter = null)
        {
            var results = new List<TResult>();
            var sentEntities = 0;
            foreach (var partialLists in GetSplittedLists(entities, Configuration.RequestBatchSize))
            {
                results.AddRange(await SendObjectAsync<TResult>(partialLists));
                sentEntities += partialLists.Count;
                progressReporter?.Report(sentEntities * 100 / entities.Count);
            }

            return results;
        }

        private async Task<List<TResult>> SendObjectAsync<TResult>(object entity)
        {
            var request = GenerateRequest();
            try
            {
                return await ExecutePostAsync<TResult>(entity, request);
            }
            catch (FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded, exception.Call.HttpStatus, exception);
                //throw;
                return null;
            }
        }

        protected virtual async Task<List<TResult>> ExecutePostAsync<TResult>(object entity, Url request)
        {
            return await request
                .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                .PostJsonAsync(entity)
                .ReceiveJson<List<TResult>>();
        }

        protected virtual async Task<List<TResult>> ExecutePostAsync<TResult>(object entity, IFlurlRequest request)
        {
            return await request
                .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                .PostJsonAsync(entity)
                .ReceiveJson<List<TResult>>();
        }

        private static IEnumerable<List<T>> GetSplittedLists(List<T> list, int listSizeWanted = 30)
        {
            if (listSizeWanted == 0)
                yield return list;
            else
            {
                for (int i = 0; i < list.Count; i += listSizeWanted)
                    yield return list.GetRange(i, Math.Min(listSizeWanted, list.Count - i));
            }
        }

        public virtual async Task<List<T>> GetAsync(List<string> ids)
        {
            return await GetObjectAsync(ids);
        }

        public async Task<List<T>> GetAsync(List<string> ids, IProgress<int> progressReporter)
        {
            return await GetObjectAsync(ids);
        }

        private async Task<List<T>> GetObjectAsync(object entity)
        {
            RequestBaseUrl = BaseUrl.Replace("Import", "Export");

            var request = GenerateRequest(); 
            try
            {
                List<T> result = await ExecutePostAsync<T>(entity, request);
                RequestBaseUrl = BaseUrl;
                return result;
            }
            catch (FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded,exception.Call.HttpStatus, exception);
                //throw;
                return null;
            }
        }

        public async Task<bool> SetItemsAsTransfered(List<string> ids)
        {
            RequestBaseUrl = BaseUrl.Replace("Import", "TransferedToCad");
            var request = GenerateRequest();
        
            try
            {
                var result =  await request
                .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                .PostJsonAsync(ids)
                .ReceiveJson<bool>();

                RequestBaseUrl = BaseUrl;

                return result;
            }
            catch (FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded, exception.Call.HttpStatus, exception);
                //throw;
                return false;
            }
        }

        public async Task<bool> SetTransferCorrespondenceIds(List<TransferIdCorrespondence> correspondenceIds)
        {
            RequestBaseUrl = BaseUrl.Replace("Import", "TransferedToCad/CorrespondenceIds");
            var request = GenerateRequest();
            
            try
            {
                var result = await request
                    .WithTimeout(TimeSpan.FromSeconds(Configuration.RequestTimeoutInSeconds))
                    .PostJsonAsync(correspondenceIds)
                    .ReceiveJson<bool>();

                RequestBaseUrl = BaseUrl;

                return result;
            }
            catch (FlurlHttpException exception)
            {
                new RestResponseValidator()
                    .ThrowExceptionForStatusCode(request.ToUri().ToString(), exception.Call.Succeeded, exception.Call.HttpStatus, exception);
                //throw;
                return false;
            }
        }
    }
}