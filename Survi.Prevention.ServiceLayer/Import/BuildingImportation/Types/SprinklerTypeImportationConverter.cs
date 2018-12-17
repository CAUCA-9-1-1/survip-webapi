using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
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
            AbstractValidator<SprinklerType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            SprinklerType importedObject,
            Models.Buildings.SprinklerType entity)
        { }
    }
}