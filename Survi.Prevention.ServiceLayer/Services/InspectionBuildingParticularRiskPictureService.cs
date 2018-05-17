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
	public class InspectionBuildingParticularRiskPictureService : BaseService
	{
		public InspectionBuildingParticularRiskPictureService(ManagementContext context) : base(context)
		{
		}

		public List<BuildingChildPictureForWeb> GetAnomalyPictures(Guid idBuildingParticularRisk)
		{
			var query =
				from picture in Context.BuildingParticularRiskPictures.AsNoTracking()
				let data = picture.Picture
				where picture.IdBuildingParticularRisk == idBuildingParticularRisk && picture.IsActive && data != null && data.IsActive
				select new
				{
					picture.Id,
					picture.IdBuildingParticularRisk,
					picture.IdPicture,
					PictureData = data.Data
				};

			var result = query.ToList();

			return result.Select(pic => new BuildingChildPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.IdPicture,
				IdParent = pic.IdBuildingParticularRisk,
				PictureData = Convert.ToBase64String(pic.PictureData)
			}).ToList();
		}

		public virtual Guid AddPicture(BuildingChildPictureForWeb entity)
		{
			var currentRecord = new BuildingParticularRiskPicture
			{
				Id = entity.Id,
				IdBuildingParticularRisk = entity.IdParent,
				Picture = new Picture { Id = entity.Id, Data = PictureService.DecodeBase64Picture(entity.PictureData) }
			};
			Context.Add(currentRecord);
			Context.SaveChanges();
			return entity.Id;
		}

		public virtual bool Remove(Guid id)
		{
			var entity = Context.BuildingParticularRiskPictures.Find(id);
			entity.IsActive = false;
			var picture = Context.Pictures.Find(entity.IdPicture);
			Context.Remove(picture);
			Context.SaveChanges();
			return true;
		}
	}
}