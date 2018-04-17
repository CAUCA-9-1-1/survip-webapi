using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CityTypeService : BaseCrudService<CityType>
	{
		public CityTypeService(ManagementContext context) : base(context)
		{
		}

		public override CityType Get(Guid id)
		{
			var result = Context.CityTypes
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<CityType> GetList()
		{
			var result = Context.CityTypes
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}		
	}
}