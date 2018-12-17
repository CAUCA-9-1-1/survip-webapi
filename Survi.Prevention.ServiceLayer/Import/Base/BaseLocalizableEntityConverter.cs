using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;

namespace Survi.Prevention.ServiceLayer.Import.Base
{
    public abstract class BaseLocalizableEntityConverter<TIn, TOut, TLocalization>
        : BaseEntityConverter<TIn, TOut>
        where TIn : BaseLocalizableTransferObject
        where TLocalization: BaseLocalization, new()
        where TOut : BaseLocalizableImportedModel<TLocalization>, new()
    {
        protected BaseLocalizableEntityConverter(
            IManagementContext context, 
            AbstractValidator<TIn> validator, CacheSystem cache)
            : base(context, validator, null, cache)
        { }

        protected override void CopyImportedFieldsToEntity(TIn importedObject, TOut entity)
        {
            base.CopyImportedFieldsToEntity(importedObject, entity);
	        CopyLocalizationFields(importedObject, entity);
        }

        protected virtual void CopyLocalizationFields(TIn importedObject, TOut entity)
        {
            var localizationConverter = new EntityLocalizationConverter<TOut, TLocalization>();
            entity.Localizations = localizationConverter.Convert(importedObject.Localizations, entity);
        }
     
        protected override TOut GetEntityFromDatabase(string externalId)
        {
            return Context.Set<TOut>()
                .IgnoreQueryFilters()
                .Include(entity => entity.Localizations)
                .FirstOrDefault(entity => entity.IdExtern == externalId);
        }
    }
}