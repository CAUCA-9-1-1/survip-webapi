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
		private readonly ReportBuildingFireHydrantGroupHandler hydrantHandler;
		private readonly ReportBuildingCourseGroupHandler courseHandler;
		private readonly ReportBuildingHazardousMaterialGroupHandler materialHandler;
		private readonly ReportBuildingAnomalyGroupHandler anomalyHandler;
		private readonly ReportBuildingParticularRiskGroupHandler riskHandler;
		private readonly ReportBuildingDetailGroupHandler detailHandler;
		private readonly BuildingService service;

		public ReportBuildingGroupHandler(BuildingService service, ReportBuildingAlarmPanelGroupHandler alarmHandler, ReportBuildingSprinklerGroupHandler sprinklerHandler, 
			ReportBuildingContactGroupHandler contactHandler, ReportBuildingPersonRequiringAssistanceGroupHandler personHandler, ReportBuildingFireHydrantGroupHandler hydrantHandler,
			ReportBuildingCourseGroupHandler courseHandler, ReportBuildingHazardousMaterialGroupHandler materialHandler, ReportBuildingAnomalyGroupHandler anomalyHandler,
			ReportBuildingParticularRiskGroupHandler riskHandler, ReportBuildingDetailGroupHandler detailHandler) 
		{
			this.service = service;
			this.alarmHandler = alarmHandler;
			this.sprinklerHandler = sprinklerHandler;
			this.contactHandler = contactHandler;
			this.personHandler = personHandler;
			this.hydrantHandler = hydrantHandler;
			this.courseHandler = courseHandler;
			this.materialHandler = materialHandler;
			this.anomalyHandler = anomalyHandler;
			this.riskHandler = riskHandler;
			this.detailHandler = detailHandler;
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode);
		}

		protected override string FillChildren(string template, Guid idBuilding, string languageCode)
		{
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.Detail, detailHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.AlarmPanel, alarmHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.Sprinkler, sprinklerHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.Contact, contactHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.PersonRequiringAssistance, personHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.FireHydrant, hydrantHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.Course, courseHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.HazardousMaterial, materialHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.Anomaly, anomalyHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.ParticularRisk, riskHandler);
						
			return template;
		}		
	}
}