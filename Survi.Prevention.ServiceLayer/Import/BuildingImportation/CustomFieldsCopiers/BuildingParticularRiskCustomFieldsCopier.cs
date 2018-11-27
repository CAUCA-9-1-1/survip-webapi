using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingParticularRiskCustomFieldsCopier
        : BaseCustomFieldsCopier<BuildingParticularRisk, Models.Buildings.Base.BuildingParticularRisk>
    {
        protected override void CopyValues(BuildingParticularRisk importedObject, Models.Buildings.Base.BuildingParticularRisk entity)
        {
            entity.Comments = importedObject.Comments;
            entity.Dimension = importedObject.Dimension;
            entity.HasOpening = importedObject.HasOpening;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IsWeakened = importedObject.IsWeakened;
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
        }
    }
}