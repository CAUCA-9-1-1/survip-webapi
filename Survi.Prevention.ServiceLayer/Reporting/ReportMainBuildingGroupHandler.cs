using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportMainBuildingGroupHandler : BaseReportGroupHandlerWithChild<BuildingForReport>
	{
		private readonly ReportBuildingFireHydrantGroupHandler hydrantHandler;
		private readonly ReportBuildingCourseGroupHandler courseHandler;
		private readonly BuildingService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.MainBuilding;

		public ReportMainBuildingGroupHandler()
		{ }

		public ReportMainBuildingGroupHandler(BuildingService service, ReportBuildingFireHydrantGroupHandler hydrantHandler, 
			ReportBuildingCourseGroupHandler courseHandler)
		{
			this.service = service;
			this.hydrantHandler = hydrantHandler;
			this.courseHandler = courseHandler;
		}

		protected override List<BuildingForReport> GetData(Guid mainBuildingId, string languageCode)
		{
			return service.GetBuildingsForReport(mainBuildingId, languageCode, false);
		}

		protected override string FillChildren(string template, Guid idBuilding, string languageCode)
		{
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.MainBuildingFireHydrant, hydrantHandler);
			template = FillSubGroup(template, idBuilding, languageCode, ReportBuildingGroup.MainBuildingCourse, courseHandler);

			return template;
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.MainBuilding.ToString(), placeholders);
		}
	}
}