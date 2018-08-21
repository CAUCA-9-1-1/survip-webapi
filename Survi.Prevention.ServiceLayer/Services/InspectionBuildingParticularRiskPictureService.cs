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
					PictureData = data.Data,
                    data.SketchJson
				};

			var result = query.ToList();

			return result.Select(pic => new BuildingChildPictureForWeb
			{
				Id = pic.Id,
				IdPicture = pic.IdPicture,
				IdParent = pic.IdBuildingParticularRisk,
				PictureData = Convert.ToBase64String(pic.PictureData),
                SketchJson = pic.SketchJson
            }).ToList();
		}

		public virtual Guid AddOrUpdatePicture(BuildingChildPictureForWeb entity)
		{
            var particularRiskPicture = Context.BuildingParticularRiskPictures.Find(entity.Id) 
				?? GenerateNewPicture(entity);

			TransferDtoToModel(entity, particularRiskPicture);

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
			var entity = Context.BuildingParticularRiskPictures.Find(id);
			entity.IsActive = false;
			var picture = Context.Pictures.Find(entity.IdPicture);
			Context.Remove(picture);
			Context.SaveChanges();
			return true;
		}

        private BuildingParticularRiskPicture GenerateNewPicture(BuildingChildPictureForWeb entity)
        {
            var picture =  new BuildingParticularRiskPicture
            {
                Id = entity.Id,
                IdBuildingParticularRisk = entity.IdParent,
                IdPicture = entity.Id,
                Picture = new Picture { Id = entity.Id, Name = "" }
            };
	        Context.Add(picture);
			return picture;
		}

        private void TransferDtoToModel(BuildingChildPictureForWeb entity, BuildingParticularRiskPicture particularRiskPicture)
        {
            var encodedPicture = PictureService.DecodeBase64Picture(entity.PictureData);
            particularRiskPicture.Id = entity.Id;
            particularRiskPicture.IdBuildingParticularRisk = entity.IdParent;

            particularRiskPicture.Picture = Context.Pictures.Find(entity.Id);

            particularRiskPicture.Picture.Id = entity.Id;
            particularRiskPicture.Picture.Data = encodedPicture;
            particularRiskPicture.Picture.SketchJson = entity.SketchJson;
        }
    }
}