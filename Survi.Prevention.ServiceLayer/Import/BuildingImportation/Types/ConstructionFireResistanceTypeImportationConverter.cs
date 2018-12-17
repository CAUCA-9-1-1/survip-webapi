using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using ConstructionFireResistanceType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionFireResistanceType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class ConstructionFireResistanceTypeImportationConverter
        : BaseLocalizableEntityConverter<
            ConstructionFireResistanceType,
            Models.Buildings.ConstructionFireResistanceType,
            ConstructionFireResistanceTypeLocalization>
    {
        public ConstructionFireResistanceTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<ConstructionFireResistanceType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ConstructionFireResistanceType importedObject,
            Models.Buildings.ConstructionFireResistanceType entity)
        { }
    }
}