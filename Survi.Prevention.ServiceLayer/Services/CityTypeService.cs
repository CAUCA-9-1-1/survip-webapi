using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CityTypeService : BaseCrudService<CityType>
	{
		public CityTypeService(ManagementContext context) : base(context)
		{
		}

		public override CityType Get(Guid id)
		{
			var result = Context.CityTypes
                .Include(c => c.Localizations)
				.First(c => c.Id == id);

			return result;
		}

		public override List<CityType> GetList()
		{
			var result = Context.CityTypes
				.Where(ct => ct.IsActive)
                .Include(c => c.Localizations)
				.ToList();

			return result;
		}

        public List<CityTypeLocalized> GetListLocalized(string languageCode)
        {
            var query =
                from cityType in Context.CityTypes.AsNoTracking()
                where cityType.IsActive
                from localization in cityType.Localizations.DefaultIfEmpty()
                where localization.IsActive && localization.LanguageCode == languageCode
                orderby localization.Name
                select new CityTypeLocalized
                {
                    Id = cityType.Id,
                    Name = localization.Name
                };

            return query.ToList();
        }
    }
}