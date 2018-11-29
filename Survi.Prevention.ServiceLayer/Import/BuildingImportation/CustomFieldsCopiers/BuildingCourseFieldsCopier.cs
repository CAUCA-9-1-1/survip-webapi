using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingCourseFieldsCopier
        : BaseCustomFieldsCopier<BuildingCourse, Models.Buildings.BuildingCourse>
    {
        protected override void CopyValues(BuildingCourse importedObject, Models.Buildings.BuildingCourse entity)
        {
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdFirestation = Guid.Parse(importedObject.IdFirestation);
            new BuildingCourseLaneCollectionFieldsCopier()
                .CopyValues(importedObject.Lanes, entity.Lanes);
        }
    }
}