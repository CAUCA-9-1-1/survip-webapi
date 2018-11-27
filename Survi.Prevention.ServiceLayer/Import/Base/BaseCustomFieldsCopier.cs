using System;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public abstract class BaseCustomFieldsCopier<TIn, TOut> : ICustomFieldsCopier<TIn, TOut>
        where TIn : BaseTransferObject
        where TOut : BaseModel
    {
        protected Guid? ParseId(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid idParsed) && idParsed != Guid.Empty)
                return idParsed;
            return null;
        }

        public virtual void DuplicateFieldsValues(TIn importedObject, TOut entity)
        {
            CopyValues(importedObject, entity);
        }

        protected abstract void CopyValues(TIn importedObject, TOut entity);
    }
}