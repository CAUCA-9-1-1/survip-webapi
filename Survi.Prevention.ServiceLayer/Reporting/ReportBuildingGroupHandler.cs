using System;
using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingGroupHandler : BaseReportGroupHandlerWithChild<BuildingForReport>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Building;

		private ReportBuildingAlarmPanelGroupHandler alarmHandler;
		private ReportBuildingSprinklerGroupHandler sprinklerHandler;
		private ReportBuildingContactGroupHandler contactHandler;
		private ReportBuildingPersonRequiringAssistanceGroupHandler personHandler;
		private ReportBuildingFireHydrantGroupHandler hydrantHandler;
		private ReportBuildingCourseGroupHandler courseHandler;
		private ReportBuildingHazardousMaterialGroupHandler materialHandler;
		private ReportBuildingAnomalyGroupHandler anomalyHandler;
		private ReportBuildingParticularRiskGroupHandler riskHandler;
		private BuildingService service;

		public ReportBuildingGroupHandler(BuildingService service, ReportBuildingAlarmPanelGroupHandler alarmHandler, ReportBuildingSprinklerGroupHandler sprinklerHandler, 
			ReportBuildingContactGroupHandler contactHandler, ReportBuildingPersonRequiringAssistanceGroupHandler personHandler, ReportBuildingFireHydrantGroupHandler hydrantHandler,
			ReportBuildingCourseGroupHandler courseHandler, ReportBuildingHazardousMaterialGroupHandler materialHandler, ReportBuildingAnomalyGroupHandler anomalyHandler,
			ReportBuildingParticularRiskGroupHandler riskHandler) 
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
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode);
		}

		protected override string FillChildren(string template, Guid idBuilding, string languageCode)
		{
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