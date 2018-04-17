using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CountryService : BaseCrudService<Country>
	{
		public CountryService(ManagementContext context) : base(context)
		{
		}

		public override Country Get(Guid id)
		{
			var result = Context.Countries
				.Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<Country> GetList()
		{
			var result = Context.Countries
				.Include(c => c.Localizations)
				.ToList();

			return result;
		}		
	}
}