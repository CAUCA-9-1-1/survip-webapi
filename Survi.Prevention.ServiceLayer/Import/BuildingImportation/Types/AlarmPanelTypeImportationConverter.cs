using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using AlarmPanelType = Survi.Prevention.ApiClient.DataTransferObjects.AlarmPanelType;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.Types
{
    public class AlarmPanelTypeImportationConverter
        : BaseLocalizableEntityConverter<
            AlarmPanelType,
            Models.Buildings.AlarmPanelType,
            AlarmPanelTypeLocalization>
    {
        public AlarmPanelTypeImportationConverter(
            IManagementContext context,
            AbstractValidator<AlarmPanelType> validator, CacheSystem cache)
            : base(context, validator, cache)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            AlarmPanelType importedObject,
            Models.Buildings.AlarmPanelType entity)
        { }
    }
}