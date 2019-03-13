using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.Buildings.Base;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingParticularRiskService : BaseServiceWithGenericImportation
	{
		public BuildingParticularRiskService(
		    IManagementContext context,
		    IEntityConverter<ApiClient.DataTransferObjects.BuildingParticularRisk, BuildingParticularRisk> riskConverter,
		    IEntityConverter<ApiClient.DataTransferObjects.BuildingParticularRiskPicture, BuildingParticularRiskPicture> riskPictureConverter) 
		    : base(context)
		{
		    Converters.Add(riskConverter);
		    Converters.Add(riskPictureConverter);
		}

		public List<ParticularRiskForReport> GetListForReport(Guid idBuilding)
		{
			var query =
				from risk in Context.BuildingParticularRisks.AsNoTracking()
				where risk.IdBuilding == idBuilding && risk.IsActive 
                      && (risk.IsWeakened || risk.HasOpening || !string.IsNullOrWhiteSpace(risk.Comments) || risk.Pictures.Any())
				select new ParticularRiskForReport
				{
                    Id = risk.Id,
					Comments = risk.Comments,
					Dimension = risk.Dimension,
					HasOpening = risk.HasOpening,
					IsWeakened = risk.IsWeakened,
					Sector = risk.Sector,
					Wall = risk.Wall,
					RiskType = risk is BuildingWallParticularRisk ? ParticularRiskType.Wall :
						risk is BuildingRoofParticularRisk ? ParticularRiskType.Roof :
						risk is BuildingFloorParticularRisk ? ParticularRiskType.Floor :
						ParticularRiskType.Foundation
				};

			return query.ToList();
		}

		public List<InspectionPictureForWeb> GetRiskPictures(Guid idRisk, string languageCode)
		{
			var query =
				from picRisk in Context.BuildingParticularRiskPictures.AsNoTracking()
				where picRisk.IdBuildingParticularRisk == idRisk && picRisk.IsActive
				let pic = picRisk.Picture
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

	    public List<ImportationResult> ImportRisks(List<ApiClient.DataTransferObjects.BuildingParticularRisk> importedEntities)
	    {
	        return Import<BuildingParticularRisk, ApiClient.DataTransferObjects.BuildingParticularRisk>(importedEntities);
	    }

	    public List<ImportationResult> ImportPictures(List<ApiClient.DataTransferObjects.BuildingParticularRiskPicture> importedEntities)
	    {
	        return Import<BuildingParticularRiskPicture, ApiClient.DataTransferObjects.BuildingParticularRiskPicture>(importedEntities);
	    }
	}
}