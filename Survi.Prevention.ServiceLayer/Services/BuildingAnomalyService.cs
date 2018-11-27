using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingAnomalyService : BaseServiceWithGenericImportation
    {
	    private readonly List<object> converters = new List<object>();

        public BuildingAnomalyService(
            IManagementContext context,
            IEntityConverter<BuildingAnomaly, Models.Buildings.BuildingAnomaly> anomalyConverter,
            IEntityConverter<BuildingAnomalyPicture, Models.Buildings.BuildingAnomalyPicture> pictureConverter) 
            : base(context)
        {
            converters.Add(anomalyConverter);
            converters.Add(pictureConverter);
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

        public List<ImportationResult> ImportAnomalies(List<BuildingAnomaly> importedEntities)
        {
            return Import<Models.Buildings.BuildingAnomaly, BuildingAnomaly>(importedEntities);
        }

        public List<ImportationResult> ImportPictures(List<BuildingAnomalyPicture> importedEntities)
        {
            return Import<Models.Buildings.BuildingAnomalyPicture, BuildingAnomalyPicture>(importedEntities);
        }
    }
}