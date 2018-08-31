using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingParticularRiskGroupHandler : BaseReportGroupHandlerWithChild<ParticularRiskForReport>
	{
		private readonly BuildingParticularRiskService service;
		private readonly ReportBuildingParticularRiskPictureGroupHandler pictureHandler;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.ParticularRisk;

		public ReportBuildingParticularRiskGroupHandler(BuildingParticularRiskService service, 
			ReportBuildingParticularRiskPictureGroupHandler pictureHandler)
		{
			this.pictureHandler = pictureHandler;
			this.service = service;
		}

		protected override List<ParticularRiskForReport> GetData(Guid idParent, string languageCode)
		{
			return service.GetListForReport(idParent);
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			template = FillSubGroup(template, idParent, languageCode, ReportBuildingGroup.ParticularRiskPicture, pictureHandler);
			return template;
		}
	}
}