using System;
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

		public List<BuildingAnomalyPictureForWeb> GetAnomalyPictures(Guid idBuildingAnomaly)
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
					PictureData = data.Data
				};

			var result = query.ToList();

			return result.Select(pic => new BuildingAnomalyPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.IdPicture,
				IdBuildingAnomaly = pic.IdBuildingAnomaly,
				PictureData = Convert.ToBase64String(pic.PictureData)
			}).ToList();
		}

		public virtual Guid AddPicture(BuildingAnomalyPictureForWeb entity)
		{
			var currentRecord = new BuildingAnomalyPicture
			{
				Id = entity.Id,
				IdBuildingAnomaly = entity.IdBuildingAnomaly,
				Picture = new Picture { Id = entity.Id, Data = PictureService.DecodeBase64Picture(entity.PictureData) }
			};
			Context.Add(currentRecord);
			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.BuildingAnomalyPictures.Find(id);
			entity.IsActive = false;
			var picture = Context.Pictures.Find(entity.IdPicture);
			Context.Remove(picture);
			Context.SaveChanges();
			return true;
		}
	}
}