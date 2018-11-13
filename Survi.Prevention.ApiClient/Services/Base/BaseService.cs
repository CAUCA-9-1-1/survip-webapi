using System.Threading.Tasks;
using RestSharp;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public abstract class BaseService<T> where T : BaseTransferObject, new()
    {
        protected abstract string BaseUrl { get; set; }

        protected virtual IRestClient GenerateClient()
        {
            var client = new RestClient(Configuration.Current.ApiBaseUrl);
            client.AddHandler("application/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/x-json", NewtonsoftJsonSerializer.Default);
            client.AddHandler("text/javascript", NewtonsoftJsonSerializer.Default);
            client.AddHandler("*+json", NewtonsoftJsonSerializer.Default);
            return client;
        }

        protected virtual IRestRequest GenerateRequest(Method method)
        {
            return new RestRequest(BaseUrl, method);
        }

        public virtual async Task<ImportationResult> SendAsync(T entity)
        {
            var client = GenerateClient();
            var request = GenerateRequest(Method.POST);
            request.AddJsonBody(entity);
            var response = await ExecuteAsync(client, request);
            return response.Data;
        }

        protected virtual async Task<IRestResponse<ImportationResult>> ExecuteAsync(IRestClient client, IRestRequest request)
        {
            var response = await client.ExecuteTaskAsync<ImportationResult>(request);
            ThrowExceptionWhenResponseHasErrorCode(response, client.BuildUri(request).ToString());
            return response;
        }

        protected void ThrowExceptionWhenResponseHasErrorCode(IRestResponse response, string url)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new NotFoundApiException(url);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new BadParameterApiException(url);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedApiException(url);
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new ForbiddenApiException(url);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                throw new InternalErrorApiException(url);
            if (response.StatusCode == 0 ||
                (response.ResponseStatus == ResponseStatus.Error
                 || response.ResponseStatus == ResponseStatus.None
                 || response.ResponseStatus == ResponseStatus.TimedOut))
                throw new NoResponseApiException();
        }
    }
}
