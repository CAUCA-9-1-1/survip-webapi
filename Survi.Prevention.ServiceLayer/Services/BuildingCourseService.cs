using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;
using Survi.Prevention.ServiceLayer.Localization.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingCourseService : BaseCrudServiceWithImportation<BuildingCourse, ApiClient.DataTransferObjects.BuildingCourse> 
	{
	    public BuildingCourseService(
	        IManagementContext context, 
	        IEntityConverter<ApiClient.DataTransferObjects.BuildingCourse, BuildingCourse> converter) 
	        : base(context, converter)
	    {
	    }

        public List<BuildingCourseForList> GetCourseList(Guid idBuilding, string languageCode)
		{
			var query =
				from course in Context.BuildingCourses.AsNoTracking()
				where course.IdBuilding == idBuilding && course.IsActive
				select new BuildingCourseForList
				{
					Id = course.Id,
					Description = course.Firestation.Name
				};

			return query.ToList();
		}

		public List<BuildingCourseLaneForList> GetCourseLanes(Guid idCourse, string languageCode)
		{
			var query =
				from courseLane in Context.BuildingCourseLanes.AsNoTracking()
				where courseLane.IdBuildingCourse == idCourse && courseLane.IsActive
				let lane = courseLane.Lane
				from loc in lane.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				select new
				{
					courseLane.Id,
					loc.Name,
					genericDescription = genericCode.Description,
					genericCode.AddWhiteSpaceAfter,
					publicDescription = publicCode.Description,
					courseLane.Direction,
					courseLane.Sequence
				};

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