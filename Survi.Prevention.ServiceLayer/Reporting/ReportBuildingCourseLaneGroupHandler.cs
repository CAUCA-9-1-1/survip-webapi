using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingCourseLaneGroupHandler : BaseReportGroupHandler<BuildingCourseLaneForList>
	{
		private readonly BuildingCourseService service;

		protected override ReportBuildingGroup Group => ReportBuildingGroup.CourseLane;

		public ReportBuildingCourseLaneGroupHandler(BuildingCourseService service)
		{
			this.service = service;
		}
		
		protected override List<BuildingCourseLaneForList> GetData(Guid idParent, string languageCode)
		{
			return service.GetCourseLanes(idParent, languageCode);
		}
	}
}