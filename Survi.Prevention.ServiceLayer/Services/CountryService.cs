using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

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
    }
}