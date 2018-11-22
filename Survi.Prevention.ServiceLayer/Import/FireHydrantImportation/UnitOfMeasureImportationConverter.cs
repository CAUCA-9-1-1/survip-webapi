using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.FireHydrantImportation
{
    public class UnitOfMeasureImportationConverter 
        : BaseLocalizableEntityConverter<UnitOfMeasure, Models.UnitOfMeasure, Models.UnitOfMeasureLocalization>
    {
        public UnitOfMeasureImportationConverter(IManagementContext context, AbstractValidator<UnitOfMeasure> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(UnitOfMeasure importedObject, Models.UnitOfMeasure entity)
        {
            entity.Abbreviation = importedObject.Abbreviation;
            entity.MeasureType = (Models.MeasureType) importedObject.MeasureType;
        }
    }
}
