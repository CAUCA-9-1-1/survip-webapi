using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.Base.Interfaces
{
    public interface ICustomFieldsCopier<TIn, TOut>
        where TIn : BaseTransferObject
        where TOut : BaseModel
    {
        void DuplicateFieldsValues(TIn importedObject, TOut entity);
    }
}