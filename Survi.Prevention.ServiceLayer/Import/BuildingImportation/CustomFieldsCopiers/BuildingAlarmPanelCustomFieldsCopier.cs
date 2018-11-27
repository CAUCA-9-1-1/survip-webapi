using System;
using Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAlarmPanelCustomFieldsCopier
        : BaseCustomFieldsCopier<BuildingAlarmPanel, Models.Buildings.BuildingAlarmPanel>
    {
        protected override void CopyValues(BuildingAlarmPanel importedObject, Models.Buildings.BuildingAlarmPanel entity)
        {
            entity.Floor = importedObject.Floor;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdAlarmPanelType = Guid.Parse(importedObject.IdAlarmPanelType);
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
        }
    }
}