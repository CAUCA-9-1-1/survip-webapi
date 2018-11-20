using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingDetailService : BaseCrudService<BuildingDetail>
	{
		public BuildingDetailService(IManagementContext context) : base(context)
		{
		}


		public Guid? GetIdByIdBuilding(Guid idBuilding)
		{
			var detailId = Context.BuildingDetails.AsNoTracking()
				.SingleOrDefault(d => d.IdBuilding == idBuilding)?.Id;

			return detailId;
		}


		public override BuildingDetail Get(Guid id)
		{
			return Context.BuildingDetails.AsNoTracking()
				.SingleOrDefault(detail => detail.Id == id);
		}

		public override List<BuildingDetail> GetList()
		{
			return Enumerable.Empty<BuildingDetail>().ToList();
		}

		public BuildingDetailForReport GetDetailForReport(Guid buildingId, string languageCode)
		{
			return Context.BuildingDetailsForReport
				.SingleOrDefault(detail => detail.IdBuilding == buildingId && detail.LanguageCode == languageCode);
		}


		public InspectionPictureForWeb GetSitePlan(Guid detailId)
		{
			var query =
				from detail in Context.BuildingDetails.AsNoTracking()				
				let pic = detail.PlanPicture
				where detail.Id == detailId && detail.IdPicturePlan != null
				select new InspectionPictureForWeb
				{
					Id = pic.Id,
					IdPicture = pic.Id,
					DataUri = string.Format(
						"data:{0};base64,{1}",
						pic.MimeType == "" || pic.MimeType == null ? "image/jpeg" : pic.MimeType,
						Convert.ToBase64String(pic.Data)),
					SketchJson = pic.SketchJson
				};

			return query.SingleOrDefault();
		}
	}
}