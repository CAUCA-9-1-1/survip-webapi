using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
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

        protected BaseEntityConverter(
            IManagementContext context,            
            AbstractValidator<TIn> validator,
            ICustomFieldsCopier<TIn,TOut> copier)
        {
            Context = context;
            Validator = validator;
            CustomFieldsCopier = copier;
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
                .FirstOrDefault(entity => entity.IdExtern == externalId);
        }       

        protected virtual TOut CreateNew()
        {
            if (typeof(TOut).GetConstructor(Type.EmptyTypes) != null)
            {
                var entity = (TOut) Activator.CreateInstance(typeof(TOut));
                Context.Add(entity);
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

        protected string GetRealId<T>(string externId)
            where T : BaseImportedModel
        {
            if (string.IsNullOrWhiteSpace(externId))
                return null;
            var id = Context.Set<T>()
                .Where(m => m.IdExtern == externId)
                .Select(m => m.Id)
                .FirstOrDefault();
            return id.ToString();
        }

        protected Guid? ParseId(string id)
        {
            if (!string.IsNullOrWhiteSpace(id) && Guid.TryParse(id, out Guid idParsed) && idParsed != Guid.Empty)
                return idParsed;
            return null;
        }
    }
}