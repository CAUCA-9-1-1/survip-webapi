using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using SprinklerType = Survi.Prevention.ApiClient.DataTransferObjects.SprinklerType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class SprinklerTypeImportationConverter
        : BaseLocalizableEntityConverter<
            SprinklerType,
            Models.Buildings.SprinklerType,
            SprinklerTypeLocalization>
    {
        public SprinklerTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<SprinklerType> validator)
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            SprinklerType importedObject,
            Models.Buildings.SprinklerType entity)
        { }
    }
}