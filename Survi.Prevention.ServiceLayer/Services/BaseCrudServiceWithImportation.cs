using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.DataTransfertObjects;
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
            Context.AccessTokens.Where(t => t.Id == Guid.Empty);

            Stopwatch watch = Stopwatch.StartNew();

            var resultList = new List<ImportationResult>();
            foreach (var entity in entities)
                resultList.Add(Import(entity));

            if (resultList.Any(result => result.IsValid))
            {
                Context.SaveChanges();
                foreach (var result in resultList.Where(t => t.IsValid))
                    result.HasBeenImported = true;
            }

            watch.Stop();
            var timespan = watch.Elapsed;
            Console.WriteLine("Elapsed : " + String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10));

            return resultList;
        }

        protected ImportationResult Import(TImportedEntity importedEntity)
        {
            var result = GetImportationResult(importedEntity);
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