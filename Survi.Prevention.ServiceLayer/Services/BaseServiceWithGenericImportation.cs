using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
    public abstract class BaseServiceWithGenericImportation : BaseService
    {
        protected readonly List<object> Converters = new List<object>();

        protected BaseServiceWithGenericImportation(IManagementContext context) : base(context)
        {
        }

        public List<ImportationResult> Import<TEntity, TImportedEntity>(List<TImportedEntity> entities)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            var resultList = new List<ImportationResult>();
            foreach (var entity in entities)
                resultList.Add(Import<TEntity, TImportedEntity>(entity));

            return resultList;
        }

        protected ImportationResult Import<TEntity, TImportedEntity>(TImportedEntity importedEntity)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            var result = GetImportationResult<TEntity, TImportedEntity>(importedEntity);

            if (result.IsValid)
            {
                Context.SaveChanges();
                result.HasBeenImported = true;
            }
            return result;
        }

        protected ImportationResult GetImportationResult<TEntity, TImportedEntity>(TImportedEntity importedEntity)
            where TEntity : BaseImportedModel
            where TImportedEntity : BaseTransferObject
        {
            var converter = Converters.OfType<IEntityConverter<TImportedEntity, TEntity>>().First();
            var conversionResult = converter.Convert(importedEntity);
            return new ImportationResult
            {
                IdEntity = importedEntity.Id,
                Messages = conversionResult.ValidationErrors
            };
        }
    }
}
