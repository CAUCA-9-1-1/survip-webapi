using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class InspectionBuildingSprinklerService: BaseCrudService<InspectionBuildingSprinkler>
	{
		public InspectionBuildingSprinklerService(ManagementContext context) : base(context)
		{
		}

		public override InspectionBuildingSprinkler Get(Guid id)
		{
			var entity = Context.InspectionBuildingSprinklers.AsNoTracking()
				.SingleOrDefault(mat => mat.Id == id);
			return entity;
		}
		
		public List<BuildingSprinkler> GetList(Guid idBuilding)
		{
			return Context.BuildingSprinklers
				.Where(s => s.IsActive && s.IdBuilding == idBuilding)
				.ToList();
		}

		public List<BuildingFireProtectionForList> GetListLocalized(string languageCode, Guid idBuilding)
		{
			var query =
				from sprinkler in Context.InspectionBuildingSprinklers.AsNoTracking()
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