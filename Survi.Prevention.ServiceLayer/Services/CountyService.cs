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
	public class CountyService : BaseCrudService<County>
	{
		public CountyService(IManagementContext context) : base(context)
		{
		}

		public override County Get(Guid id)
		{
			var result = Context.Counties
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<County> GetList()
		{
			var result = Context.Counties
				.Where(c => c.IsActive)
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}

        public List<CountyLocalized> GetListLocalized(string languageCode)
        {
            var query =
                from county in Context.Counties.AsNoTracking()
                where county.IsActive
                from localization in county.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
                orderby localization.Name
                select new CountyLocalized
                {
                    Id = county.Id,
                    Name = localization.Name
                };

            return query.ToList();
        }

		public List<ImportationResult> ImportCounties(List<ApiClient.DataTransferObjects.County> importedCounties)
		{
			List<ImportationResult> resultList = new List<ImportationResult>();
			foreach (var county in importedCounties)
			{
				resultList.Add(ImportCounty(county));
			}

			return resultList;
		}

		public ImportationResult ImportCounty(ApiClient.DataTransferObjects.County importedCounty)
		{
			CountyModelConnector connector = new CountyModelConnector(Context);
			ImportationResult result = connector.ValidateCounty(importedCounty);

			if (result.HasBeenImported)
			{
				var newCounty = Context.Counties.Include(loc =>loc.Localizations).SingleOrDefault(c => c.IdExtern == importedCounty.Id);
				bool isExistRecord = newCounty != null && newCounty.Id != Guid.Empty;

				newCounty = connector.TransferDtoImportedToOriginal(importedCounty, newCounty ?? new County());

				if (!isExistRecord)
					Context.Counties.Add(newCounty);
				else
					Context.Counties.Update(newCounty);

				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}
    }
}