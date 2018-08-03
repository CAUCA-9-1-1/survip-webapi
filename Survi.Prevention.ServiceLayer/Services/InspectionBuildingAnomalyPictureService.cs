﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

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
                from picture in Context.BuildingAnomalyPictures.AsNoTracking()
                let data = picture.Picture
                where picture.IdBuildingAnomaly == idBuildingAnomaly && picture.IsActive && data != null && data.IsActive
                select new
                {
                    picture.Id,
                    picture.IdBuildingAnomaly,
                    picture.IdPicture,
                    PictureData = data.Data,
                    data.SketchJson
				};

			var result = query.ToList();

			return result.Select(pic => new BuildingChildPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.IdPicture,
				IdParent = pic.IdBuildingAnomaly,
				PictureData = Convert.ToBase64String(pic.PictureData),
                SketchJson = pic.SketchJson
			}).ToList();
		}

		public virtual Guid AddPicture(BuildingChildPictureForWeb entity)
		{
            BuildingAnomalyPicture anomalyPicture = null;
            Picture picture = null;
            if (entity.Id != null)
            {
                anomalyPicture = Context.BuildingAnomalyPictures.Find(entity.Id);
                picture = Context.Pictures.Find(entity.Id);
            }

            if (anomalyPicture == null)
            {
                anomalyPicture = new BuildingAnomalyPicture {Picture = new Picture { Name = "" } };
                Context.Add(anomalyPicture);
            }

            var encodedPicture = PictureService.DecodeBase64Picture(entity.PictureData);
            anomalyPicture.Id = entity.Id;
            anomalyPicture.IdBuildingAnomaly = entity.IdParent;

            picture.Id = entity.Id;
            picture.Data = encodedPicture;
            picture.SketchJson = entity.SketchJson;

            Context.SaveChanges();
            return entity.Id;
        }

		public virtual bool Remove(Guid id)
		{
			var entity = Context.BuildingAnomalyPictures.Find(id);
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
	}
}