using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
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