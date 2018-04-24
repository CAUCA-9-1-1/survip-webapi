using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingService : BaseCrudService<Building>
	{
		public BuildingService(ManagementContext context) : base(context)
		{
		}

		public override Building Get(Guid id)
		{
			var result = Context.Buildings
                .Include(b => b.Localizations)
				.First(b => b.Id == id);

			return result;
		}

		public override List<Building> GetList()
		{
			var result = Context.Buildings
                .Include(b => b.Localizations)
                .ToList();

			return result;
		}
	}
}