using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingParticularRiskPictureCustomFieldCopier
        : BaseCustomFieldsCopierWithPicture<BuildingParticularRiskPicture, Models.Buildings.BuildingParticularRiskPicture>
    {
        protected override void CopyValues(BuildingParticularRiskPicture importedObject, Models.Buildings.BuildingParticularRiskPicture entity)
        {
            entity.IdBuildingParticularRisk = Guid.Parse(importedObject.IdBuildingParticularRisk);
        }

        protected override BasePicture GetEntityPicture(Models.Buildings.BuildingParticularRiskPicture entity)
        {
            return entity.Picture;
        }

        protected override void CreatePictureWhenNeeded(BuildingParticularRiskPicture importedObject, Models.Buildings.BuildingParticularRiskPicture entity)
        {
            if (entity.Picture == null && importedObject.PictureData != null)
                entity.Picture = new Models.Picture();
        }
    }
}