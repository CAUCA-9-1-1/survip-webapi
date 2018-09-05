using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingParticularRiskService : BaseService
	{
		public BuildingParticularRiskService(ManagementContext context) : base(context)
		{
		}

		public List<ParticularRiskForReport> GetListForReport(Guid idBuilding)
		{BuildingParticularRisk
			var query =
				from risk in Context.BuildingParticularRisks.AsNoTracking()
				where risk.IdBuilding == idBuilding && risk.IsActive
				select new ParticularRiskForReport
				{
					Comments = risk.Comments,
					Dimension = risk.Dimension,
					HasOpening = risk.HasOpening,
					IsWeakened = risk.IsWeakened,
					Sector = risk.Sector,
					Wall = risk.Wall,
					TypeName = risk is BuildingWallParticularRisk ? "Risk_Wall" :
						risk is BuildingRoofParticularRisk ? "Toit" :
						risk is BuildingFloorParticularRisk ? "Plancher" :
						"Fondation"
				};

			return query.ToList();
		}

		public List<BuildingChildPictureForWeb> GetRiskPictures(Guid idRisk, string languageCode)
		{
			var query =
				from picRisk in Context.BuildingParticularRiskPictures.AsNoTracking()
				where picRisk.IdBuildingParticularRisk == idRisk && picRisk.IsActive
				let pic = picRisk.Picture
				select new BuildingChildPictureForWeb
				{
					Id = pic.Id,
					IdPicture = pic.Id,
					PictureData = string.Format(
						"data:{0};base64,{1}",
						pic.MimeType == "" || pic.MimeType == null ? "image/jpeg" : pic.MimeType,
						Convert.ToBase64String(pic.Data)),
					SketchJson = pic.SketchJson
				};

			return query.ToList();
		}
	}
}