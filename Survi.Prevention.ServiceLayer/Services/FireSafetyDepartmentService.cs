using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class FireSafetyDepartmentService : BaseCrudService<FireSafetyDepartment>
	{
		public FireSafetyDepartmentService(ManagementContext context) : base(context)
		{
		}

		public override FireSafetyDepartment Get(Guid id)
		{
			var result = Context.FireSafetyDepartments
				.Include(s => s.Localizations)
				.First(s => s.Id == id);

			return result;
		}

		public override List<FireSafetyDepartment> GetList()
		{
			var result = Context.FireSafetyDepartments
                .Include(s => s.Localizations)
				.ToList();

			return result;
		}
	}
}