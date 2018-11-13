using RestSharp;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public class RestResponseValidator
    {
        public void ThrowExceptionWhenResponseHasErrorCode(IRestResponse response, string url)
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