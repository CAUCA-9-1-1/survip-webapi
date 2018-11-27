using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingAnomalyPictureCustomFieldCopier 
        : BaseCustomFieldsCopierWithPicture<BuildingAnomalyPicture, Models.Buildings.BuildingAnomalyPicture>
    {
        protected override void CopyValues(BuildingAnomalyPicture importedObject, Models.Buildings.BuildingAnomalyPicture entity)
        {
            entity.IdBuildingAnomaly = Guid.Parse(importedObject.IdBuildingAnomaly);
        }

        protected override BasePicture GetEntityPicture(Models.Buildings.BuildingAnomalyPicture entity)
        {
            return entity.Picture;
        }

        protected override void CreatePictureWhenNeeded(BuildingAnomalyPicture importedObject, Models.Buildings.BuildingAnomalyPicture entity)
        {
            if (entity.Picture == null && importedObject.PictureData != null)
                entity.Picture = new Models.Picture();
        }
    }
}