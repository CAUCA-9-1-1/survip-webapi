using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using RoofMaterialType = Survi.Prevention.ApiClient.DataTransferObjects.RoofMaterialType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class RoofMaterialTypeImportationConverter
        : BaseLocalizableEntityConverter<
            RoofMaterialType,
            Models.Buildings.RoofMaterialType,
            RoofMaterialTypeLocalization>
    {
        public RoofMaterialTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<RoofMaterialType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            RoofMaterialType importedObject,
            Models.Buildings.RoofMaterialType entity)
        { }
    }
}