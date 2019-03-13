using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingDetailService : BaseCrudService<InspectionBuildingDetail>
	{
		public InspectionBuildingDetailService(IManagementContext context) : base(context)
		{
		}

		public InspectionBuildingDetail GetByIdBuilding(Guid idBuilding)
		{
			var detail = Context.InspectionBuildingDetails.AsNoTracking()
				             .SingleOrDefault(d => d.IdBuilding == idBuilding) ?? GenerateNewDetail(idBuilding);

			return detail;
		}

		private InspectionBuildingDetail GenerateNewDetail(Guid idBuilding)
		{
			var detail = new InspectionBuildingDetail { IdBuilding = idBuilding };
			Context.Add(detail);
			Context.SaveChanges();
			return detail;
		}

		public override InspectionBuildingDetail Get(Guid id)
		{
			return Context.InspectionBuildingDetails.AsNoTracking()
				.SingleOrDefault(detail => detail.Id == id);
		}

		public override List<InspectionBuildingDetail> GetList()
		{
			return Enumerable.Empty<InspectionBuildingDetail>().ToList();
		}

	    public InspectionPictureForWeb GetPictureByIdBuilding(Guid idBuilding)
	    {
	        var query =
	            from detail in Context.InspectionBuildingDetails.AsNoTracking()
	            where detail.IdBuilding == idBuilding && detail.IsActive
	            select detail.PlanPicture;

	        var picture = query.FirstOrDefault();

	        return picture == null ? null : new InspectionPictureForWeb
	        {
	            Id = picture.Id,
	            IdPicture = picture.Id,
	            IdParent = idBuilding,
	            DataUri = string.Format(
	                "data:{0};base64,{1}",
	                string.IsNullOrEmpty(picture.MimeType) ? "image/jpeg" : picture.MimeType,
	                Convert.ToBase64String(picture.Data)),
	            SketchJson = picture.SketchJson
	        };
        }

	    public bool SavePictureByIdBuilding(Guid idBuilding, InspectionPictureForWeb picture)
	    {
	        var detail = GetBuildingDetail(idBuilding);

	        if (detail != null)
	        {
	            EditDetailPicture(picture, detail);
	            return true;
	        }
            return false;
	    }

	    private void EditDetailPicture(InspectionPictureForWeb picture, InspectionBuildingDetail detail)
	    {
	        if (string.IsNullOrEmpty(picture.DataUri) && detail.PlanPicture != null)
	        {
	            Context.Remove(detail.PlanPicture);
	        }
	        else
	        {
	            AddPictureToDetail(picture, detail);
	        }

	        Context.SaveChanges();
	    }

	    private static void AddPictureToDetail(InspectionPictureForWeb picture, InspectionBuildingDetail detail)
	    {
	        if (detail.PlanPicture == null)
	            detail.PlanPicture = new InspectionPicture();

	        detail.PlanPicture.DataUri = picture.DataUri;
	    }

	    private InspectionBuildingDetail GetBuildingDetail(Guid idBuilding)
	    {
	        return Context.InspectionBuildingDetails
	            .Include(d => d.PlanPicture)
	            .First(d => d.IdBuilding == idBuilding);
	    }

	    public override Guid AddOrUpdate(InspectionBuildingDetail entity)
	    {
	        var isExistRecord = Context.Set<InspectionBuildingDetail>().Any(c => c.Id == entity.Id);

	        if (isExistRecord)
	        {
	            Context.Set<InspectionBuildingDetail>().Update(entity);
                // patch: this is a way to NOT try to update IdPicturePlan because this field will be managed elsewhere.
	            Context.Entry(entity).Property(nameof(entity.IdPicturePlan)).IsModified = false;
	        }
	        else
	            Context.Set<InspectionBuildingDetail>().Add(entity);

	        Context.SaveChanges();
	        return entity.Id;
        }
	}
}