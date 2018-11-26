using System;
using FluentValidation;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAlarmPanelImportationConverter
        : BaseEntityConverter<
            BuildingAlarmPanel,
            Models.Buildings.BuildingAlarmPanel>
    {
        public BuildingAlarmPanelImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingAlarmPanel> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingAlarmPanel importedObject)
        {
            importedObject.IdAlarmPanelType = GetRealId<Models.Buildings.AlarmPanelType>(importedObject.IdAlarmPanelType);
            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingAlarmPanel importedObject,
            Models.Buildings.BuildingAlarmPanel entity)
        {
            entity.Floor = importedObject.Floor;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdAlarmPanelType = Guid.Parse(importedObject.IdAlarmPanelType);
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
        }
    }
}