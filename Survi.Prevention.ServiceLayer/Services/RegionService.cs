using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Places;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class RegionService : BaseCrudService<Region>
	{
		public RegionService(IManagementContext context) : base(context)
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
				.Where(r => r.IsActive)
                .Include(r => r.Localizations)
				.ToList();

			return result;
		}

        public List<RegionLocalized> GetListLocalized(string languageCode)
        {
            var query =
                from region in Context.Regions.AsNoTracking()
                where region.IsActive
                from localization in region.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
                orderby localization.Name
                select new RegionLocalized
                {
                    Id = region.Id,
                    Name = localization.Name
                };

            return query.ToList();
        }

		public List<ImportationResult> ImportRegions(List<ApiClient.DataTransferObjects.Region> importedRegions)
		{
			List<ImportationResult> resultList = new List<ImportationResult>();
			foreach (var region in importedRegions)
			{
				resultList.Add(ImportRegion(region));
			}

			return resultList;
		}

		public ImportationResult ImportRegion(ApiClient.DataTransferObjects.Region importedRegion)
		{
			RegionModelConnector connector = new RegionModelConnector(Context);
			ImportationResult result = connector.ValidateRegion(importedRegion);

			if (result.HasBeenImported)
			{
				var newRegion = Context.Regions.Include(loc =>loc.Localizations).SingleOrDefault(c => c.IdExtern == importedRegion.Id);
				bool isExistRecord = newRegion != null && newRegion.Id != Guid.Empty;

				newRegion = connector.TransferDtoImportedToOriginal(importedRegion, newRegion?? new Region());

				if (!isExistRecord)
					Context.Regions.Add(newRegion);
				else
					Context.Regions.Update(newRegion);

				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}
    }
}