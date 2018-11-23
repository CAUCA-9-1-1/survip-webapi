using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using RoofType = Survi.Prevention.ApiClient.DataTransferObjects.RoofType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class RoofTypeImportationConverter
        : BaseLocalizableEntityConverter<
            RoofType,
            Models.Buildings.RoofType,
            RoofTypeLocalization>
    {
        public RoofTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<RoofType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            RoofType importedObject,
            Models.Buildings.RoofType entity)
        { }
    }
}