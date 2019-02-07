using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public interface IBaseService<T> where T : BaseTransferObject, new()
    {
        Task<List<TResult>> SendAsync<TResult>(T entity);
        Task<List<TResult>> SendAsync<TResult>(List<T> entity, IProgress<int> progressReporter);

        Task<List<T>> GetAsync(List<string> ids = null);
        Task<List<T>> GetAsync(List<string> ids, IProgress<int> progressReporter);

        Task<Boolean> SetItemsAsTransfered(List<string> ids);
    }
}