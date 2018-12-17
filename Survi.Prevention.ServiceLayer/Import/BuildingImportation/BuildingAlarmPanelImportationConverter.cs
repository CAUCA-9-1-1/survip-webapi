using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;
using Survi.Prevention.ServiceLayer.Import.Base.Cache;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAlarmPanelImportationConverter
        : BaseEntityConverter<
            BuildingAlarmPanel,
            Models.Buildings.BuildingAlarmPanel>
    {

        public BuildingAlarmPanelImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingAlarmPanel> validator,
            ICustomFieldsCopier<BuildingAlarmPanel, Models.Buildings.BuildingAlarmPanel> copier, CacheSystem cache)
            : base(context, validator, copier, cache)
        {
        }

        protected override void GetRealForeignKeys(BuildingAlarmPanel importedObject)
        {
            importedObject.IdAlarmPanelType = GetRealId<Models.Buildings.AlarmPanelType>(importedObject.IdAlarmPanelType);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }
    }
}