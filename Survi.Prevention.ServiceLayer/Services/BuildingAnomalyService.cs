using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingAnomalyService : BaseService
	{
		public BuildingAnomalyService(IManagementContext context) : base(context)
		{
		}

		public List<BuildingAnomalyForList> GetAnomalyForReport(Guid idBuilding, string languageCode)
		{
			var query =
				from anomaly in Context.BuildingAnomalies.AsNoTracking()
				where anomaly.IdBuilding == idBuilding && anomaly.IsActive
				select new BuildingAnomalyForList
				{
					Id = anomaly.Id,
					Theme = anomaly.Theme,
					Notes = anomaly.Notes
				};

			return query.ToList();
		}

		public List<InspectionPictureForWeb> GetAnomalyPictures(Guid idAnomaly, string languageCode)
		{
			var query =
				from picAnomaly in Context.BuildingAnomalyPictures.AsNoTracking()
				where picAnomaly.IdBuildingAnomaly == idAnomaly && picAnomaly.IsActive
				let pic = picAnomaly.Picture
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

			return query.ToList();
		}
	}
}