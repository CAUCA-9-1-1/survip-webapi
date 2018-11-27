using System;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation.CustomFieldsCopiers
{
    public class BuildingDetailCustomFieldsCopier 
        : BaseCustomFieldsCopierWithPicture<BuildingDetail, Models.Buildings.BuildingDetail>
    {
        protected override BasePicture GetEntityPicture(Models.Buildings.BuildingDetail entity)
        {
            return entity.PlanPicture;
        }

        protected override void CreatePictureWhenNeeded(BuildingDetail importedObject, Models.Buildings.BuildingDetail entity)
        {
            if (entity.PlanPicture == null && importedObject.PictureData != null)
            {
                entity.PlanPicture = new Models.Picture();
            }
        }

        protected override void CopyValues(BuildingDetail importedObject, Models.Buildings.BuildingDetail entity)
        {
            entity.IdBuilding = Guid.Parse(importedObject.IdBuilding);
            entity.IdBuildingSidingType = ParseId(importedObject.IdBuildingSidingType);
            entity.IdBuildingType = ParseId(importedObject.IdBuildingType);
            entity.IdConstructionFireResistanceType = ParseId(importedObject.IdConstructionFireResistanceType);
            entity.IdConstructionType = ParseId(importedObject.IdConstructionType);
            entity.IdRoofMaterialType = ParseId(importedObject.IdRoofMaterialType);
            entity.IdRoofType = ParseId(importedObject.IdRoofType);
            entity.IdUnitOfMeasureEstimatedWaterFlow = ParseId(importedObject.IdUnitOfMeasureEstimatedWaterFlow);
            entity.IdUnitOfMeasureHeight = ParseId(importedObject.IdUnitOfMeasureHeight);
            entity.AdditionalInformation = importedObject.AdditionalInformation;
            entity.ApprovedOn = importedObject.ApprovedOn;
            entity.EstimatedWaterFlow = importedObject.EstimatedWaterFlow;
            entity.Height = importedObject.Height;
            entity.ApprovedOn = importedObject.ApprovedOn;
            entity.RevisedOn = importedObject.RevisedOn;
        }
    }
}