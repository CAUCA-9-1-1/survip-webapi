using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.BuildingImportation
{
    public class BuildingParticularRiskPictureImportationConverter
        : BaseEntityConverter<
            BuildingParticularRiskPicture,
            Models.Buildings.BuildingParticularRiskPicture>
    {
        public BuildingParticularRiskPictureImportationConverter(
            IManagementContext context,
            AbstractValidator<BuildingParticularRiskPicture> validator)
            : base(context, validator)
        {
        }

        protected override void GetRealForeignKeys(BuildingParticularRiskPicture importedObject)
        {
            importedObject.IdBuildingParticularRisk = GetRealId<Models.Buildings.BuildingParticularRiskPicture>(importedObject.IdBuildingParticularRisk);
        }

        protected override Models.Buildings.BuildingParticularRiskPicture CreateNew()
        {
            var entity = base.CreateNew();
            entity.Picture = new Models.Picture();
            return entity;
        }

        protected override Models.Buildings.BuildingParticularRiskPicture GetEntityFromDatabase(string externalId)
        {
            var entity = Context.Set<Models.Buildings.BuildingParticularRiskPicture>()
                .Include(pic => pic.Picture)
                .FirstOrDefault(pic => pic.IdExtern == externalId);

            if (entity != null && entity.Picture == null)
                entity.Picture = new Models.Picture();

            return entity;
        }

        protected override void CopyCustomFieldsToEntity(
            BuildingParticularRiskPicture importedObject,
            Models.Buildings.BuildingParticularRiskPicture entity)
        {
            entity.IdBuildingParticularRisk = Guid.Parse(importedObject.IdBuildingParticularRisk);
            entity.Picture.Data = importedObject.PictureData;
            entity.Picture.Name = importedObject.PictureName;
            entity.Picture.MimeType = importedObject.MimeType;
            entity.Picture.SketchJson = importedObject.SketchJson;
        }
    }
}