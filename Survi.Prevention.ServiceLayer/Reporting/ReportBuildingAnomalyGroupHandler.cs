using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingAnomalyGroupHandler : BaseReportGroupHandlerWithChild<BuildingAnomalyForList>
	{
		private readonly BuildingAnomalyService service;
		private readonly ReportBuildingAnomalyPictureGroupHandler pictureHandler;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.Anomaly;

		public ReportBuildingAnomalyGroupHandler(BuildingAnomalyService service, ReportBuildingAnomalyPictureGroupHandler pictureHandler)
		{
			this.service = service;
			this.pictureHandler = pictureHandler;
		}

		protected override List<BuildingAnomalyForList> GetData(Guid idBuilding, string languageCode)
		{
			return service.GetAnomalyForReport(idBuilding, languageCode);
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			template = FillSubGroup(template, idParent, languageCode, ReportBuildingGroup.AnomalyPicture, pictureHandler);
			return template;
		}
	}
}