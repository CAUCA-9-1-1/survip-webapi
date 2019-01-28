using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class InspectionBuildingAnomalyPictureService : BaseService
    {
        public InspectionBuildingAnomalyPictureService(IManagementContext context) : base(context)
        {
        }

        public List<InspectionPictureForWeb> GetAnomalyPictures(Guid idBuildingAnomaly)
        {
            var query =
                from picture in Context.InspectionBuildingAnomalyPictures.AsNoTracking()
                let data = picture.Picture
                where picture.IdBuildingAnomaly == idBuildingAnomaly && picture.IsActive && data != null &&
                      data.IsActive
                select new
                {
                    picture.Id,
                    picture.IdBuildingAnomaly,
                    picture.IdPicture,
                    PictureData = string.Format(
                        "data:{0};base64,{1}",
                        data.MimeType == "" || data.MimeType == null ? "image/jpeg" : data.MimeType,
                        Convert.ToBase64String(data.Data)),
                    data.SketchJson
                };

            var result = query.ToList();

            return result.Select(pic => new InspectionPictureForWeb
            {
                Id = pic.Id,
                IdPicture = pic.IdPicture,
                IdParent = pic.IdBuildingAnomaly,
                DataUri = pic.PictureData,
                SketchJson = pic.SketchJson
            }).ToList();
        }

        public virtual Guid AddOrUpdatePicture(InspectionPictureForWeb entity)
        {
            var anomalyPicture = Context.InspectionBuildingAnomalyPictures
                                     .Include(pic => pic.Picture)
                                     .FirstOrDefault(pic => pic.Id == entity.Id)
                                 ?? GenerateNewPicture(entity);

            TransferDtoToModel(entity, anomalyPicture);

            Context.SaveChanges();
            return entity.Id;
        }

        public bool AddUpdatePictures(InspectionPictureForWeb[] entity)
        {
            bool retValue = false;
            foreach (var pic in entity)
            {
                if (AddOrUpdatePicture(pic) != Guid.Empty)
                    retValue = true;
            }

            return retValue;
        }

        public virtual bool Remove(Guid id)
        {
            var entity = Context.InspectionBuildingAnomalyPictures.Find(id);
            if (entity != null)
            {
                entity.IsActive = false;

                var picture = Context.InspectionPictures.Find(entity.IdPicture);
                if (picture != null)
                    Context.Remove(picture);

                Context.SaveChanges();
            }

            return true;
        }

        private InspectionBuildingAnomalyPicture GenerateNewPicture(InspectionPictureForWeb entity)
        {
            var picture = new InspectionBuildingAnomalyPicture
            {
                Id = entity.Id,
                IdBuildingAnomaly = entity.IdParent,
                IdPicture = entity.Id,
                Picture = new InspectionPicture {Id = entity.Id, Name = ""}
            };
            Context.Add(picture);
            return picture;
        }

        private void TransferDtoToModel(InspectionPictureForWeb entity, InspectionBuildingAnomalyPicture anomalyPicture)
        {
            anomalyPicture.Id = entity.Id;
            anomalyPicture.IdBuildingAnomaly = entity.IdParent;

            anomalyPicture.Picture = Context.InspectionPictures.Find(entity.Id);

            anomalyPicture.Picture.Id = entity.Id;
            anomalyPicture.Picture.DataUri = entity.DataUri;
            anomalyPicture.Picture.SketchJson = entity.SketchJson;
        }

        public List<EntityPictures> GetBuildingAnomalyPictures(Guid idBuilding)
        {
            var query =
                from anomaly in Context.InspectionBuildingAnomalies.AsNoTracking()
                where anomaly.IdBuilding == idBuilding && anomaly.IsActive
                from pictureAnomaly in anomaly.Pictures
                where pictureAnomaly.IsActive
                group pictureAnomaly by anomaly.Id
                into grp
                select new
                {
                    Id = grp.Key,
                    Pictures = grp.Select(p => new InspectionPictureForWeb
                    {
                        Id = p.Id,
                        IdParent = p.IdBuildingAnomaly,
                        IdPicture = p.Picture.Id,
                        DataUri = string.Format(
                            "data:{0};base64,{1}",
                            p.Picture.MimeType == "" || p.Picture.MimeType == null ? "image/jpeg" : p.Picture.MimeType,
                            Convert.ToBase64String(p.Picture.Data)),
                        SketchJson = p.Picture.SketchJson
                    })
                };

            var anomalies = query.ToList();

            return anomalies
                .Select(anomaly => new EntityPictures
                {
                    Id = anomaly.Id,
                    Pictures =  anomaly.Pictures.ToList()
                }).ToList();
        }
    }
}