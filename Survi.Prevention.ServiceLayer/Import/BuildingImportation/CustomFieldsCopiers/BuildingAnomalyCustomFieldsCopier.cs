using System;
using Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAnomalyCustomFieldsCopier
        : BaseCustomFieldsCopier<BuildingAnomaly, Models.Buildings.BuildingAnomaly>
    {
        protected override void CopyValues(BuildingAnomaly importedObject, Models.Buildings.BuildingAnomaly entity)
        {
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.Notes = importedObject.Notes;
            entity.Theme = importedObject.Theme;
        }
    }
}