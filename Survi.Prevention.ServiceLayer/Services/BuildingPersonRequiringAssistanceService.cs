using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingPersonRequiringAssistanceService : BaseCrudService<BuildingPersonRequiringAssistance>
	{
		public BuildingPersonRequiringAssistanceService(ManagementContext context) : base(context)
		{
		}

		public override BuildingPersonRequiringAssistance Get(Guid id)
		{
			var entity = Context.BuildingPersonsRequiringAssistance.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public override List<BuildingPersonRequiringAssistance> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingPersonRequiringAssistance> GetListOfBuilding(Guid idBuilding)
		{
            var result = Context.BuildingPersonsRequiringAssistance
                .Where(p => p.IdBuilding == idBuilding)
                .ToList();

			return result;
		}
	}
}