using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingCourseGroupHandler : BaseReportGroupHandlerWithChild<BuildingCourseForList>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.Course;

		public ReportBuildingCourseGroupHandler(ManagementContext context) : base(context)
		{
		}
		
		protected override List<BuildingCourseForList> GetData(Guid idParent, string languageCode)
		{
			var query =
				from course in Context.BuildingCourses.AsNoTracking()
				where course.IdBuilding == idParent && course.IsActive
				select new BuildingCourseForList
				{
					Id = course.Id,
					Description = course.Firestation.Name
				};

			return query.ToList();
		}

		protected override string FillChildren(string template, Guid idParent, string languageCode)
		{
			if (ReportingTemplateVariableListExtractor.HasGroup(ReportBuildingGroup.CourseLane, template))
			{
				var group = ReportingTemplateVariableListExtractor.GetGroupContent(ReportBuildingGroup.CourseLane, template);
				var filledGroup = new ReportBuildingCourseLaneGroupHandler(Context).FillGroup(group, idParent, languageCode);
				template = template.Replace(group, filledGroup);
			}
			return template;
		}
	}
}