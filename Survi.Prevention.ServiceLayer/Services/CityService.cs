using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CityService : BaseCrudService<City>
	{
		public CityService(ManagementContext context) : base(context)
		{
		}

		public override City Get(Guid id)
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<City> GetList()
		{
			var result = Context.Cities
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}

        public List<CityLocalized> GetListLocalized(string languageCode)
        {
            var query =
                from city in Context.Cities.AsNoTracking()
                where city.IsActive
                from localization in city.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
                orderby localization.Name
                select new CityLocalized {
                    Id = city.Id,
                    Name = localization.Name
                };

            return query.ToList();
        }
    }
}