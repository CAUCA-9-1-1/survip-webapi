using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

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
	}
}