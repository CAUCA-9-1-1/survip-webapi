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
                .Include(r => r.Localizations)
				.First(r => r.Id == id);

			return result;
		}

		public override List<Region> GetList()
		{
			var result = Context.Regions
                .Include(r => r.Localizations)
				.ToList();

			return result;
		}		
	}
}