using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using ConstructionType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class ConstructionTypeImportationConverter
        : BaseLocalizableEntityConverter<
            ConstructionType,
            Models.Buildings.ConstructionType,
            ConstructionTypeLocalization>
    {
        public ConstructionTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<ConstructionType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ConstructionType importedObject,
            Models.Buildings.ConstructionType entity)
        { }
    }
}