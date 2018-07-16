using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class RegionService : BaseCrudService<Region>
	{
		public RegionService(ManagementContext context) : base(context)
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
    }
}