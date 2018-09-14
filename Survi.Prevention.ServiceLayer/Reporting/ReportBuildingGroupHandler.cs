using System;
using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingGroupHandler : BaseReportGroupHandlerWithChild<BuildingForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Building;

		private readonly ReportBuildingAlarmPanelGroupHandler alarmHandler;
		private readonly ReportBuildingSprinklerGroupHandler sprinklerHandler;
		private readonly ReportBuildingContactGroupHandler contactHandler;
		private readonly ReportBuildingPersonRequiringAssistanceGroupHandler personHandler;
		private readonly ReportBuildingHazardousMaterialGroupHandler materialHandler;
		private readonly ReportBuildingAnomalyGroupHandler anomalyHandler;
		private readonly ReportBuildingParticularRiskGroupHandler riskHandler;
		private readonly ReportBuildingDetailGroupHandler detailHandler;
		private readonly BuildingService service;

		public ReportBuildingGroupHandler(BuildingService service, ReportBuildingAlarmPanelGroupHandler alarmHandler, ReportBuildingSprinklerGroupHandler sprinklerHandler, 
			ReportBuildingContactGroupHandler contactHandler, ReportBuildingPersonRequiringAssistanceGroupHandler personHandler,
			ReportBuildingHazardousMaterialGroupHandler materialHandler, ReportBuildingAnomalyGroupHandler anomalyHandler,
			ReportBuildingParticularRiskGroupHandler riskHandler, ReportBuildingDetailGroupHandler detailHandler) 
		{
			this.service = service;
			this.alarmHandler = alarmHandler;
			this.sprinklerHandler = sprinklerHandler;
			this.contactHandler = contactHandler;
			this.personHandler = personHandler;
			this.materialHandler = materialHandler;
			this.anomalyHandler = anomalyHandler;
			this.riskHandler = riskHandler;
			this.detailHandler = detailHandler;
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode, false);
		}

		protected override string FillChildren(string template, Guid idBuilding, string languageCode)
		{
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingDetail, detailHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingAlarmPanel, alarmHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingSprinkler, sprinklerHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingContact, contactHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingPersonRequiringAssistance, personHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingHazardousMaterial, materialHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingAnomaly, anomalyHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.BuildingParticularRisk, riskHandler);
						
			return template;
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.Building.ToString(), placeholders);
		}
	}
}