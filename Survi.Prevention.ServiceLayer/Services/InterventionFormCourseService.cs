using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InterventionFormCourseService : BaseService
	{
		public InterventionFormCourseService(ManagementContext context) : base(context)
		{
		}

		public List<InterventionFormCourseForList> GetCourses(Guid interventionFormId)
		{
			var query =
				from course in Context.InterventionFormCourses.AsNoTracking()
				where course.IsActive && course.IdInterventionForm == interventionFormId && course.Firestation.IsActive
				let firestation = course.Firestation
				select new InterventionFormCourseForList
				{
					Id = course.Id,
					Description = firestation.Name
				};

			return query.ToList();
		}
	}
}