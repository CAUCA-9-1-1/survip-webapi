using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class UnitOfMeasureImportationConverter 
        : BaseLocalizableEntityConverter<UnitOfMeasure, Models.UnitOfMeasure, Models.UnitOfMeasureLocalization>
    {
        public UnitOfMeasureImportationConverter(IManagementContext context, AbstractValidator<UnitOfMeasure> validator, CacheSystem cache) 
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(UnitOfMeasure importedObject, Models.UnitOfMeasure entity)
        {
            entity.Abbreviation = importedObject.Abbreviation;
            entity.MeasureType = (Models.MeasureType) importedObject.MeasureType;
        }
    }
}
