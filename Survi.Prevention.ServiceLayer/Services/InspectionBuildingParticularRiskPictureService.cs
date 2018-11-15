﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingParticularRiskPictureService : BaseService
	{
		public InspectionBuildingParticularRiskPictureService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionPictureForWeb> GetParticularRiskPictures(Guid idBuildingParticularRisk)
		{
			var query =
				from picture in Context.InspectionBuildingParticularRiskPictures.AsNoTracking()
				let data = picture.Picture
				where picture.IdBuildingParticularRisk == idBuildingParticularRisk && picture.IsActive && data != null && data.IsActive
				select new
				{
					picture.Id,
					picture.IdBuildingParticularRisk,
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
				IdParent = pic.IdBuildingParticularRisk,
				DataUri = pic.PictureData,
                SketchJson = pic.SketchJson
            }).ToList();
		}

		public virtual Guid AddOrUpdatePicture(InspectionPictureForWeb entity)
		{
			var particularRiskPicture = Context.InspectionBuildingParticularRiskPictures.Find(entity.Id) 
			    ?? GenerateNewPicture(entity);

		    TransferDtoToModel(entity, particularRiskPicture);

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

		public virtual bool Remove(Guid id, Guid idWebUserLastModifiedBy)
		{
			var entity = Context.InspectionBuildingParticularRiskPictures.Find(id);
			entity.IsActive = false;

			var picture = Context.InspectionPictures.Find(entity.IdPicture);
			Context.Remove(picture);
			Context.SaveChanges();
			return true;
		}

		private InspectionBuildingParticularRiskPicture GenerateNewPicture(InspectionPictureForWeb entity)
		{
			var picture = new InspectionBuildingParticularRiskPicture
			{
				Id = entity.Id,
				IdBuildingParticularRisk = entity.IdParent,
				IdPicture = entity.Id,
				Picture = new InspectionPicture { Id = entity.Id, Name = "" }
			};
			Context.Add(picture);
			return picture;
		}

		private void TransferDtoToModel(InspectionPictureForWeb entity, InspectionBuildingParticularRiskPicture particularRiskPicture)
		{
			particularRiskPicture.Id = entity.Id;
			particularRiskPicture.IdBuildingParticularRisk = entity.IdParent;

			particularRiskPicture.Picture = Context.InspectionPictures.Find(entity.Id);

			particularRiskPicture.Picture.Id = entity.Id;
            particularRiskPicture.Picture.DataUri = entity.DataUri;
			particularRiskPicture.Picture.SketchJson = entity.SketchJson;
		}
	}
}