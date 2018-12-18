using System;
using System.Diagnostics;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using Survi.Prevention.ServiceLayer.ValidationUtilities;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public abstract class BaseEntityConverter<TIn, TOut> 
        : IEntityConverter<TIn, TOut>
        where TIn : BaseTransferObject
        where TOut : BaseImportedModel
    {
        protected IManagementContext Context { get; set; }
        protected AbstractValidator<TIn> Validator { get; set; }
        protected ICustomFieldsCopier<TIn, TOut> CustomFieldsCopier;
        protected readonly CacheSystem Cache;

        protected BaseEntityConverter(
            IManagementContext context,            
            AbstractValidator<TIn> validator,
            ICustomFieldsCopier<TIn,TOut> copier,
            CacheSystem cache
            )
        {
            Context = context;
            Validator = validator;
            CustomFieldsCopier = copier;
            Cache = cache;
        }

        public virtual ConversionResult<TOut> Convert(TIn importedObject)
        {
            GetRealForeignKeys(importedObject);
            var validationResult = Validate(importedObject);
            TOut convertedEntity = default(TOut);
            if (validationResult.IsValid)
                convertedEntity = ReadDataTransferObject(importedObject);

            return GetConversionResult(convertedEntity, validationResult);
        }

        protected virtual void GetRealForeignKeys(TIn importedObject)
        {
        }

        protected virtual TOut ReadDataTransferObject(TIn importedObject)
        {
            var entity = GetEntityFromDatabase(importedObject.Id)
                         ?? CreateNew();
            CopyImportedFieldsToEntity(importedObject, entity);
            return entity;
        }

        protected virtual ValidationResult Validate(
            TIn convertedEntity)
        {
            return Validator.Validate(convertedEntity);
        }

        protected virtual TOut GetEntityFromDatabase(string externalId)
        {
            return Context.Set<TOut>()
	            .IgnoreQueryFilters()
                .FirstOrDefault(entity => entity.IdExtern == externalId);
        }       

        protected virtual TOut CreateNew()
        {            
            if (typeof(TOut).GetConstructor(Type.EmptyTypes) != null)
            {
                var watch = Stopwatch.StartNew();
                var entity = (TOut) Activator.CreateInstance(typeof(TOut));
                Context.Add(entity);
                watch.Stop();
                Metrics.CreateNew =  Metrics.CreateNew.Add(watch.Elapsed);
                return entity;
            }
            return null;
        }

        protected virtual void CopyImportedFieldsToEntity(TIn importedObject, TOut entity)
        {
            entity.IdExtern = importedObject.Id;
            entity.ImportedOn = DateTime.Now;
            entity.IsActive = importedObject.IsActive;
	        entity.HasBeenModified = false;
            CopyCustomFieldsToEntity(importedObject, entity);
        }

        protected virtual void CopyCustomFieldsToEntity(TIn importedObject, TOut entity)
        {
            CustomFieldsCopier?.DuplicateFieldsValues(importedObject, entity);
        }

        private ConversionResult<TOut> GetConversionResult(
            TOut convertedEntity, 
            ValidationResult validationResult)
        {
            return new ConversionResult<TOut>
            {
                Result = convertedEntity,
                ValidationErrors = new FluentValidationErrorFormatter()
                    .GetFluentValidationErrorList(validationResult.Errors
                        .ToList())
            };
        }

        protected virtual string GetRealId<T>(string externId)
            where T : BaseImportedModel
        {
            if (string.IsNullOrWhiteSpace(externId))
                return null;

            var foundId = Cache.GetForeignKey(typeof(T), externId);
            if (foundId != null)
                return foundId.ToString();
                        
            var id = GetRealIdFromDatabase<T>(externId);

            if (id != Guid.Empty)
                Cache.SetForeignKeys(typeof(T), externId, id);

            return id.ToString();
        }

        private Guid GetRealIdFromDatabase<T>(string externId) where T : BaseImportedModel
        {
            var query = Context.Set<T>()
                .Where(m => m.IdExtern == externId)
                .Select(m => m.Id);

            var id = query.FirstOrDefault();
            return id;
        }

        protected Guid? ParseId(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid idParsed) && idParsed != Guid.Empty)
                return idParsed;
            return null;
        }
    }
}