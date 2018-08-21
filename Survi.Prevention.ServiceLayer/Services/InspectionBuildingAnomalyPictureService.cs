﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingAnomalyPictureService : BaseService
	{
		public InspectionBuildingAnomalyPictureService(ManagementContext context) : base(context)
		{
		}

		public List<BuildingChildPictureForWeb> GetAnomalyPictures(Guid idBuildingAnomaly)
		{
            var query =
                from picture in Context.InspectionBuildingAnomalyPictures.AsNoTracking()
                let data = picture.Picture
                where picture.IdBuildingAnomaly == idBuildingAnomaly && picture.IsActive && data != null && data.IsActive
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

			return result.Select(pic => new BuildingChildPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.IdPicture,
				IdParent = pic.IdBuildingAnomaly,
				PictureData = pic.PictureData,
                SketchJson = pic.SketchJson
			}).ToList();
		}

		public virtual Guid AddOrUpdatePicture(BuildingChildPictureForWeb entity)
		{
            var anomalyPicture = Context.InspectionBuildingAnomalyPictures.Find(entity.Id) 
				?? GenerateNewPicture(entity);

			TransferDtoToModel(entity, anomalyPicture);

            Context.SaveChanges();
            return entity.Id;
        }

		public bool AddUpdatePictures(BuildingChildPictureForWeb[] entity)
		{
			bool retValue = false;
			foreach (var pic in entity)
			{
				if (this.AddOrUpdatePicture(pic) != Guid.Empty)
					retValue = true;
			}
			return retValue;
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.InspectionBuildingAnomalyPictures.Find(id);
			if (entity != null)
			{
				var picture = Context.Pictures.Find(entity.IdPicture);
				if(picture != null)
				Context.Remove(picture);

				Context.Remove(entity);
				Context.SaveChanges();
			}
			return true;
		}

        private InspectionBuildingAnomalyPicture GenerateNewPicture(BuildingChildPictureForWeb entity)
        {
            var picture = new InspectionBuildingAnomalyPicture
			{
                Id = entity.Id,
                IdBuildingAnomaly = entity.IdParent,
                IdPicture = entity.Id,
                Picture = new Picture { Id = entity.Id, Name = "" }
            };
	        Context.Add(picture);
			return picture;
		}

        private void TransferDtoToModel(BuildingChildPictureForWeb entity, InspectionBuildingAnomalyPicture anomalyPicture)
        {
            anomalyPicture.Id = entity.Id;
            anomalyPicture.IdBuildingAnomaly = entity.IdParent;

            anomalyPicture.Picture = Context.Pictures.Find(entity.Id);

            anomalyPicture.Picture.Id = entity.Id;
            anomalyPicture.Picture.DataUri = entity.PictureData;
            anomalyPicture.Picture.SketchJson = entity.SketchJson;
        }
    }
}