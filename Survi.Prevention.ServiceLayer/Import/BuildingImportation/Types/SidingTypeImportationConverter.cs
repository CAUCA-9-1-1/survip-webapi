using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using SidingType = Survi.Prevention.ApiClient.DataTransferObjects.SidingType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class SidingTypeImportationConverter
        : BaseLocalizableEntityConverter<
            SidingType,
            Models.Buildings.SidingType,
            SidingTypeLocalization>
    {
        public SidingTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<SidingType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            SidingType importedObject,
            Models.Buildings.SidingType entity)
        { }
    }
}