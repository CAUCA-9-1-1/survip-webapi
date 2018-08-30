using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Localization.Base;

namespace Survi.Prevention.ServiceLayer.Reporting
{
	public class ReportBuildingCourseLaneGroupHandler : BaseReportGroupHandler<BuildingCourseLaneForList>
	{
		protected override ReportBuildingGroup Group => ReportBuildingGroup.CourseLane;

		public ReportBuildingCourseLaneGroupHandler(ManagementContext context) : base(context)
		{
		}
		
		protected override List<BuildingCourseLaneForList> GetData(Guid idParent, string languageCode)
		{
			var query =
				from courseLane in Context.BuildingCourseLanes.AsNoTracking()
				where courseLane.IdBuildingCourse == idParent && courseLane.IsActive
				let lane = courseLane.Lane
				from loc in lane.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				select new { courseLane.Id, loc.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter,
					publicDescription = publicCode.Description, courseLane.Direction, courseLane.Sequence };

			var result = query.ToList()
				.Select(lane => new BuildingCourseLaneForList
				{
					Id = lane.Id,
					Sequence = lane.Sequence,
					Description = GenerateLaneName(lane.Direction, lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter, languageCode)
				})
				.ToList();

			return result;
		}

		private static string GenerateLaneName(CourseLaneDirection direction, string name, string genericDescription, string publicDescription, bool addWhiteSpaceAfter, string languageCode)
		{
			var laneName = new LocalizedLaneNameGenerator().GenerateLaneName(name, genericDescription, publicDescription, addWhiteSpaceAfter);
			if (direction != CourseLaneDirection.StraightAhead)
				laneName += $" ({direction.GetDisplayName(languageCode)})";
			return laneName;
		}
	}
}