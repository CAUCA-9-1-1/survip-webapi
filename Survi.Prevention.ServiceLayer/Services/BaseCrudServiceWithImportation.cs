using System.Collections.Generic;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public abstract class BaseCrudServiceWithImportation<TEntity, TImportedEntity> : BaseCrudService<TEntity>
        where TEntity : BaseImportedModel, new()
        where TImportedEntity : BaseTransferObject
    {
        protected IEntityConverter<TImportedEntity, TEntity> Converter;

        protected BaseCrudServiceWithImportation(
            IManagementContext context,
            IEntityConverter<TImportedEntity, TEntity> converter) 
            : base(context)
        {
            Converter = converter;
        }

        public List<ImportationResult> Import(List<TImportedEntity> entities)
        {
            var resultList = new List<ImportationResult>();
            foreach (var entity in entities)
                resultList.Add(Import(entity));

            return resultList;
        }

        protected ImportationResult Import(TImportedEntity importedEntity)
        {
            var result = GetImportationResult(importedEntity);

            if (result.IsValid)
            {
                Context.SaveChanges();
                result.HasBeenImported = true;
            }
            return result;
        }

        protected virtual ImportationResult GetImportationResult(TImportedEntity importedEntity)
        {
            var conversionResult = Converter.Convert(importedEntity);
            return new ImportationResult
            {
                IdEntity = importedEntity.Id,
                Messages = conversionResult.ValidationErrors
            };
        }
    }
}