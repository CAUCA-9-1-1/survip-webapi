using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Localization.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingCourseService : BaseService
	{
		public InspectionBuildingCourseService(ManagementContext context) : base(context)
		{
		}

		public List<InspectionBuildingCourse> GetCompleteCourses(Guid inspectionId)
		{
			var query =
				from building in Context.InspectionBuildings.AsNoTracking()
				where building.IsActive && building.ChildType == BuildingChildType.None && building.IdInspection == inspectionId
				from course in building.Courses
				select course;

			var result = query
				.Include(c => c.Lanes)
				.ToList();

			return result;
		}
		
		public Guid SaveCompleteCourses(InspectionBuildingCourse course)
		{						
			UpdateCourse(course);		
			UpdateCourseLanes(course);
			Context.SaveChanges();
			
			return course.Id;
		}

		private void UpdateCourse(InspectionBuildingCourse course)
		{
			var isExistRecord = Context.InspectionBuildingCourses.Any(c => c.Id == course.Id);

			if (isExistRecord)
				Context.InspectionBuildingCourses.Update(course);
			else
				Context.InspectionBuildingCourses.Add(course);
		}

		private void UpdateCourseLanes(InspectionBuildingCourse course)
		{
			var courseLanes = new List<InspectionBuildingCourseLane>();
			var dbCourseLanes = new List<InspectionBuildingCourseLane>();

			if (course.Lanes != null)
				courseLanes = course.Lanes.Where(l => l.IdBuildingCourse == course.Id).ToList();

			if (Context.InspectionBuildingCourseLanes.AsNoTracking().Any(l => l.IdBuildingCourse == course.Id))
				dbCourseLanes = Context.InspectionBuildingCourseLanes.Where(l => l.IdBuildingCourse == course.Id).ToList();

			RemoveDeletedLanes(dbCourseLanes, courseLanes);
			AddNewLanes(courseLanes);
		}

		private void AddNewLanes(List<InspectionBuildingCourseLane> courseLanes)
		{
			courseLanes.ForEach(child =>
			{
				var isChildExistRecord = Context.InspectionBuildingCourseLanes.Any(c => c.Id == child.Id);
				if (!isChildExistRecord)
				{
					Context.InspectionBuildingCourseLanes.Add(child);
				}
			});
		}

		private static void RemoveDeletedLanes(List<InspectionBuildingCourseLane> dbCourseLanes, List<InspectionBuildingCourseLane> courseLanes)
		{
			dbCourseLanes.ForEach(child =>
			{
				if (courseLanes.All(c => c.Id != child.Id))
				{
					child.IsActive = false;
				}
			});
		}

		public List<BuildingCourseForList> GetCourses(Guid inspectionid)
		{
			var query =
				from inspection in Context.Inspections.AsNoTracking()
				where inspection.Id == inspectionid
				from building in inspection.Buildings
				where building.ChildType == BuildingChildType.None
				from course in building.Courses
				where course.IsActive && course.Firestation.IsActive
				let firestation = course.Firestation
				select new BuildingCourseForList
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

		private ICollection<BuildingCourseLaneForList> GetCourseLanesList(Guid idCourse, string languageCode)
		{
			var query =
				from courseLane in Context.InspectionBuildingCourseLanes.AsNoTracking()
				where courseLane.IdBuildingCourse == idCourse && courseLane.IsActive
				let lane = courseLane.Lane
				from loc in lane.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				let genericCode = lane.LaneGenericCode
				let publicCode = lane.PublicCode
				select new { courseLane.Id, loc.Name, genericDescription = genericCode.Description, genericCode.AddWhiteSpaceAfter, publicDescription = publicCode.Description, courseLane.Direction, courseLane.Sequence };

			var result = query.ToList()
				.Select(lane => new BuildingCourseLaneForList {
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

		private InspectionBuildingCourse GetCourse(Guid idCourse)
		{
			return Context.InspectionBuildingCourses
				.AsNoTracking()
				.SingleOrDefault(course => course.Id == idCourse);
		}
		
		public object GetCourseLane(Guid idCourseLane)
		{
			return Context.InspectionBuildingCourseLanes
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
			var entity = Context.Set<InspectionBuildingCourseLane>().Find(idCourseLane);
			if (entity != null)
			{
				entity.Sequence = sequence;
				Context.SaveChanges();
			}
			return true;
		}
	}
}