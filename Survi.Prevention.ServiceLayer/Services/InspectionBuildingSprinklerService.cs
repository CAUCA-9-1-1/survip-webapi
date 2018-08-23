using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingSprinklerService: BaseCrudService<BuildingSprinkler>
	{
		public InspectionBuildingSprinklerService(ManagementContext context) : base(context)
		{
		}

		public override BuildingSprinkler Get(Guid id)
		{
			var entity = Context.BuildingSprinklers.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}

		public List<BuildingFireProtectionForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from sprinkler in Context.BuildingSprinklers.AsNoTracking()
				where sprinkler.IdBuilding == idBuilding && sprinkler.IsActive
				let type = sprinkler.SprinklerType
				from loc in type.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				select new 
				{
					sprinkler.Id,
					loc.Name,
					sprinkler.Floor,
					sprinkler.Sector,
					sprinkler.Wall
				};

			var result =
				from sprinkler in query.ToList()
				select new BuildingFireProtectionForList
				{
					Id = sprinkler.Id,
					TypeDescription = sprinkler.Name,
					LocationDescription = new LocalizedResourceGenerator().GetFireProtectionLocationDescription(sprinkler.Floor, sprinkler.Sector, sprinkler.Wall,languageCode)
				};

			return result.ToList();
		}
	}
}