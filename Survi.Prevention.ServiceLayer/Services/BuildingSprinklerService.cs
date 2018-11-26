using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects.Reporting;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class BuildingSprinklerService : BaseCrudServiceWithImportation<BuildingSprinkler, ApiClient.DataTransferObjects.BuildingSprinkler>
	{
		public BuildingSprinklerService(IManagementContext context, IEntityConverter<ApiClient.DataTransferObjects.BuildingSprinkler, BuildingSprinkler> validator) 
		    : base(context, validator)
		{
		}

		public List<FireProtectionForReport> GetSprinklersForReport(Guid idBuilding, string languageCode)
		{
			var query =
				from sprinkler in Context.BuildingSprinklers.AsNoTracking()
				where sprinkler.IsActive && sprinkler.IdBuilding == idBuilding
				from localization in sprinkler.SprinklerType.Localizations.Where(loc => loc.IsActive && loc.LanguageCode == languageCode).DefaultIfEmpty()
				select new FireProtectionForReport
				{
					Floor = sprinkler.Floor,
					PipeLocation = sprinkler.PipeLocation,
					Wall = sprinkler.Wall,
					Sector = sprinkler.Sector,
					CollectorLocation = sprinkler.CollectorLocation,
					TypeName = localization.Name
				};

			return query.ToList();
		}
	}
}