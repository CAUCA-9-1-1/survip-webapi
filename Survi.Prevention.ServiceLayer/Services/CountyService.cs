using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CountyService : BaseCrudService<County>
	{
		public CountyService(ManagementContext context) : base(context)
		{
		}

		public override County Get(Guid id)
		{
			var result = Context.Counties
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<County> GetList()
		{
			var result = Context.Counties
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}		
	}
}