using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingSprinklerCustomFieldsCopier
        : BaseCustomFieldsCopier<BuildingSprinkler, Models.Buildings.BuildingSprinkler>
    {
        protected override void CopyValues(BuildingSprinkler importedObject, Models.Buildings.BuildingSprinkler entity)
        {
            entity.Floor = importedObject.Floor;
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdSprinklerType = Guid.Parse(importedObject.IdSprinklerType);
            entity.PipeLocation = importedObject.PipeLocation;
            entity.Sector = importedObject.Sector;
            entity.Wall = importedObject.Wall;
            entity.CollectorLocation = importedObject.CollectorLocation;
        }
    }
}