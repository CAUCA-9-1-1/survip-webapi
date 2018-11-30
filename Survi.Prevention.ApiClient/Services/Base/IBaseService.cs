using System.Collections.Generic;
using System.Threading.Tasks;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.Services.Base
{
    public interface IBaseService<T> where T : BaseTransferObject, new()
    {
        Task<List<ImportationResult>> SendAsync(T entity);
        Task<List<ImportationResult>> SendAsync(List<T> entity);
    }
}