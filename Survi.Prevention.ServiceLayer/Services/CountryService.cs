using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CountryService : BaseCrudService<Country>
	{
		public CountryService(ManagementContext context) : base(context)
		{
		}

		public override Country Get(Guid id)
		{
			var result = Context.Countries
				.Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<Country> GetList()
		{
			var result = Context.Countries
				.Where(c => c.IsActive)
				.Include(c => c.Localizations)
				.ToList();

			return result;
		}

		public List<CountryLocalized> GetListLocalized(string languageCode)
		{
			var query =
				from country in Context.Countries.AsNoTracking()
				where country.IsActive
				from localization in country.Localizations.DefaultIfEmpty()
				where localization.IsActive && localization.LanguageCode == languageCode
				orderby localization.Name
				select new CountryLocalized
				{
					Id = country.Id,
					Name = localization.Name
				};

			return query.ToList();
		}

		public List<ImportationResult> ImportCountries(List<ApiClient.DataTransferObjects.Country> importedCountries)
		{
			List<ImportationResult> resultList = new List<ImportationResult>();
			foreach (var country in importedCountries)
			{
				resultList.Add(ImportCountry(country));
			}

			return resultList;
		}

		public ImportationResult ImportCountry(ApiClient.DataTransferObjects.Country importedCountry)
		{
			var result = new ImportationResult{HasBeenImported = false};
			var isExistRecord = Context.Set<Country>().Any(c => c.IdExtern == importedCountry.Id);
			if (new CountryModelConnector().ValidateLocalizations(importedCountry))
			{
				Country newCountry = new CountryModelConnector().TransferImportedModelToOriginal(importedCountry);

				if (!isExistRecord)
					Context.Countries.Add(newCountry);
				else
					Context.Countries.Update(newCountry);

				Context.SaveChanges();
				result.HasBeenImported = true;
			}
			return result;
		}
	}
}