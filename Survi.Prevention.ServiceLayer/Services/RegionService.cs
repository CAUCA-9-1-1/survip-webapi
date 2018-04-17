using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class RegionService : BaseCrudService<Region>
	{
		public RegionService(ManagementContext context) : base(context)
		{
		}

		public override Region Get(Guid id)
		{
			var result = Context.Regions
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<Region> GetList()
		{
			var result = Context.Regions
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}		
	}
}