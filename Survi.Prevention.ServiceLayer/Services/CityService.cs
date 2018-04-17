using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CityService : BaseCrudService<City>
	{
		public CityService(ManagementContext context) : base(context)
		{
		}

		public override City Get(Guid id)
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<City> GetList()
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}		
	}
}