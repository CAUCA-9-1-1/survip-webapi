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
				Picture = new InspectionPicture { Id = entity.Id, Name = "" }
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
	}
}