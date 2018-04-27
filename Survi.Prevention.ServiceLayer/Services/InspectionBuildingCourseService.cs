using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Localization.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingCourseService : BaseService
	{
		public InspectionBuildingCourseService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionBuildingCourseForList> GetCourses(Guid inspectionid)
		{
			var query =
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionid
				from course in inspection.MainBuilding.Courses
				where course.IsActive && course.Firestation.IsActive
				let firestation = course.Firestation
				select new InspectionBuildingCourseForList
				{
					Id = course.Id,
					Description = firestation.Name
				};

			return query.ToList();
		}

		public InspectionBuildingCourseWithLanes GetCourse(Guid idCourse, string languageCode)
		{
			return new InspectionBuildingCourseWithLanes
			{
				Course = GetCourse(idCourse),
				Lanes = GetCourseLanesList(idCourse, languageCode)
			};
		}

		private ICollection<InspectionBuildingCourseLaneForList> GetCourseLanesList(Guid idCourse, string languageCode)
		{
			var query =
				from courseLane in Context.BuildingCourseLanes.AsNoTracking()
				where courseLane.IdBuildingCourse == idCourse && courseLane.IsActive
				let lane = courseLane.Lane
				from loc in lane.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				select new { courseLane.Id, loc.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description, courseLane.Direction, courseLane.Sequence };

			var result = query.ToList()
				.Select(lane => new InspectionBuildingCourseLaneForList {
					Id = lane.Id,
					Sequence = lane.Sequence,
					Description = GenerateLaneName(lane.Direction, lane.Name, lane.genericDescription, lane.publicDescription, lane.AddWhiteSpaceAfter, languageCode) })
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

		private InspectionBuildingCourseForWeb GetCourse(Guid idCourse)
		{
			return Context.BuildingCourses.AsNoTracking()
				.Where(course => course.Id == idCourse)
				.Select(course => new InspectionBuildingCourseForWeb {Id = course.Id, IdFirestation = course.IdFirestation, IdInspectionBuilding = course.IdBuilding})
				.SingleOrDefault();
		}

		public object GetCourseLane(Guid idCourseLane)
		{
			return Context.BuildingCourseLanes
				.AsNoTracking()
				.SingleOrDefault(lane => lane.Id == idCourseLane);
		}

		public bool AddOrUpdate<T>(T entity) where T: BaseModel
		{
			var isExistRecord = Context.Set<T>().Any(c => c.Id == entity.Id);

			if (isExistRecord)
				Context.Set<T>().Update(entity);
			else
				Context.Set<T>().Add(entity);

			Context.SaveChanges();
			return true;
		}

		public bool Delete<T>(Guid id) where T: BaseModel
		{
			var entity = Context.Set<T>().Find(id);
			if (entity != null)
			{
				entity.IsActive = false;
				Context.SaveChanges();
			}
			return true;
		}

		public bool UpdateCourseLaneSequence(Guid idCourseLane, int sequence)
		{
			var entity = Context.Set<BuildingCourseLane>().Find(idCourseLane);
			if (entity != null)
			{
				entity.Sequence = sequence;
				Context.SaveChanges();
			}
			return true;
		}
	}
}