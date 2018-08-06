using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingHazardousMaterialService : BaseCrudService<BuildingHazardousMaterial>
	{
		public BuildingHazardousMaterialService(ManagementContext context) : base(context)
		{
		}

		public override BuildingHazardousMaterial Get(Guid id)
		{
			return Context.BuildingHazardousMaterials.AsNoTracking()
                .FirstOrDefault(material => material.Id == id);
		}

        public List<BuildingHazardousMaterial> GetBuildingHazardousMaterialList(Guid idBuilding)
		{
            var result = Context.BuildingHazardousMaterials
                .Where(c => c.IdBuilding == idBuilding)
                .ToList();

			return result;
		}
    }
}