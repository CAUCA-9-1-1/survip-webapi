using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingDetailImportationConverter
        : BaseEntityConverter<
            BuildingDetail,
            Models.Buildings.BuildingDetail>
    {
        public BuildingDetailImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingDetail> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingDetail importedObject)
        {
            importedObject.IdBuildingSidingType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdBuildingType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdConstructionFireResistanceType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdConstructionType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdRoofMaterialType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdRoofType = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdUnitOfMeasureEstimatedWaterFlow = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
            importedObject.IdUnitOfMeasureHeight = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);

            importedObject.IdBuilding = GetRealId<Models.Buildings.Building>(importedObject.IdBuilding);
        }

        protected override Models.Buildings.BuildingDetail GetEntityFromDatabase(string externalId)
        {
            return Context.Set<Models.Buildings.BuildingDetail>()
                .Include(pic => pic.PlanPicture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingDetail importedObject,
            Models.Buildings.BuildingDetail entity)
        {
            CreatePictureWhenNeeded(importedObject, entity);

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

            CopyPictureFields(importedObject, entity);
        }

        private static void CopyPictureFields(BuildingDetail importedObject, Models.Buildings.BuildingDetail entity)
        {
            if (entity.PlanPicture != null && importedObject.PictureData != null)
            {
                entity.PlanPicture.Data = importedObject.PictureData;
                entity.PlanPicture.Name = importedObject.PictureName;
                entity.PlanPicture.SketchJson = importedObject.SketchJson;
            }
        }

        private static void CreatePictureWhenNeeded(BuildingDetail importedObject, Models.Buildings.BuildingDetail entity)
        {
            if (entity.PlanPicture == null && importedObject.PictureData != null)
            {
                entity.PlanPicture = new Models.Picture();
            }
        }
    }
}