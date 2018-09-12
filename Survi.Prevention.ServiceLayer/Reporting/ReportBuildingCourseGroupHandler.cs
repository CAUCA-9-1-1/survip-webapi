using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingCourseGroupHandler : BaseReportGroupHandlerWithChild<BuildingCourseForList>
	{
		private readonly BuildingCourseService service;
		private readonly ReportBuildingCourseLaneGroupHandler laneHandler;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.MainBuildingCourse;

		public ReportBuildingCourseGroupHandler(BuildingCourseService service, ReportBuildingCourseLaneGroupHandler laneHandler)
		{
			this.service = service;
			this.laneHandler = laneHandler;
		}
		
		protected override List<BuildingCourseForList> GetData(Guid idParent, string languageCode)
		{
			return service.GetCourseList(idParent, languageCode);
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			template = FillSubGroup(template, idParent, languageCode, ReportBuildingGroup.MainBuildingCourseLane, laneHandler);
			return template;
		}

		public static (string Group, List<string> Placeholders) GetPlaceholders()
		{
			var placeholders = GetPlaceholderList();
			return (ReportBuildingGroup.MainBuildingCourse.ToString(), placeholders);
		}
	}
}