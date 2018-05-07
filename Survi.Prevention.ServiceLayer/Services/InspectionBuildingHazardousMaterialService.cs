using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingHazardousMaterialService : BaseCrudService<BuildingHazardousMaterial>
	{
		public InspectionBuildingHazardousMaterialService(ManagementContext context) : base(context)
		{
		}

		public override BuildingHazardousMaterial Get(Guid id)
		{
			var entity = Context.BuildingHazardousMaterials.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public override List<BuildingHazardousMaterial> GetList()
		{
			throw new NotImplementedException();
		}

		public List<BuildingHazardousMaterialForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from matBuilding in Context.BuildingHazardousMaterials.AsNoTracking()
				where matBuilding.IdBuilding == idBuilding && matBuilding.IsActive
				let mat = matBuilding.Material
				from loc in mat.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				let unit = matBuilding.Unit
				select new BuildingHazardousMaterialForList
				{
					Id = matBuilding.Id,
					HazardousMaterialName = loc.Name,
					QuantityDescription = matBuilding.Quantity + " " + unit.Abbreviation
				};

			return query.ToList();
		}
	}
}