using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
	public class CountyService : BaseCrudServiceWithImportation<County, ApiClient.DataTransferObjects.County>
	{
		public CountyService(
			IManagementContext context, 
			IEntityConverter<ApiClient.DataTransferObjects.County, County> converter) 
			: base(context, converter)
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
    }
}