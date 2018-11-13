using System.Net;
using Survi.Prevention.ApiClient.Exceptions;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public class RestResponseValidator
    {
        public void ThrowExceptionForStatusCode(string url, bool answerReceived, HttpStatusCode? code)
        {
            if (code == HttpStatusCode.NotFound)
                throw new NotFoundApiException(url);
            if (code == HttpStatusCode.BadRequest)
                throw new BadParameterApiException(url);
            if (code == HttpStatusCode.Unauthorized)
                throw new UnauthorizedApiException(url);
            if (code == HttpStatusCode.Forbidden)
                throw new ForbiddenApiException(url);
            if (code == HttpStatusCode.InternalServerError)
                throw new InternalErrorApiException(url);
            if (!answerReceived)
                throw new NoResponseApiException();
        }
    }
}