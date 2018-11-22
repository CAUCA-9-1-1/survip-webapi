using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using ConstructionFireResistanceType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionFireResistanceType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class ConstructionFireResistanceTypeImportationConverter
        : BaseLocalizableEntityConverter<
            ConstructionFireResistanceType,
            Models.Buildings.ConstructionFireResistanceType,
            ConstructionFireResistanceTypeLocalization>
    {
        public ConstructionFireResistanceTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<ConstructionFireResistanceType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ConstructionFireResistanceType importedObject,
            Models.Buildings.ConstructionFireResistanceType entity)
        { }
    }
}