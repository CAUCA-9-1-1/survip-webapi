using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using ConstructionType = Survi.Prevention.ApiClient.DataTransferObjects.ConstructionType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class ConstructionTypeImportationConverter
        : BaseLocalizableEntityConverter<
            ConstructionType,
            Models.Buildings.ConstructionType,
            ConstructionTypeLocalization>
    {
        public ConstructionTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<ConstructionType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ConstructionType importedObject,
            Models.Buildings.ConstructionType entity)
        { }
    }
}