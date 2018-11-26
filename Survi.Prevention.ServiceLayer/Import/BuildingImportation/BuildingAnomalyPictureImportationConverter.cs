using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingAnomalyPictureImportationConverter
        : BaseEntityConverter<
            BuildingAnomalyPicture,
            Models.Buildings.BuildingAnomalyPicture>
    {
        public BuildingAnomalyPictureImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingAnomalyPicture> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingAnomalyPicture importedObject)
        {
            importedObject.IdBuildingAnomaly = GetRealId<Models.Buildings.BuildingAnomaly>(importedObject.IdBuildingAnomaly);
        }

        protected override Models.Buildings.BuildingAnomalyPicture CreateNew()
        {
            var entity = base.CreateNew();
            entity.Picture = new Models.Picture();
            return entity;
        }

        protected override Models.Buildings.BuildingAnomalyPicture GetEntityFromDatabase(string externalId)
        {
            var entity = Context.Set<Models.Buildings.BuildingAnomalyPicture>()
                .Include(pic => pic.Picture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);

            if (entity != null && entity.Picture == null)
                entity.Picture = new Models.Picture();

            return entity;
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingAnomalyPicture importedObject,
            Models.Buildings.BuildingAnomalyPicture entity)
        {
            entity.IdBuildingAnomaly = Guid.Parse(importedObject.IdBuildingAnomaly);
            entity.Picture.Data = importedObject.PictureData;
            entity.Picture.Name = importedObject.PictureName;
            entity.Picture.MimeType = importedObject.MimeType;
            entity.Picture.SketchJson = importedObject.SketchJson;
        }
    }
}