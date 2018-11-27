using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Import.Base.Interfaces;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantTypeService : BaseCrudServiceWithImportation<FireHydrantType, ApiClient.DataTransferObjects.FireHydrantType>
    {
        public FireHydrantTypeService(
            IManagementContext context, 
            IEntityConverter<ApiClient.DataTransferObjects.FireHydrantType, FireHydrantType> converter) 
            : base(context, converter)
        {
        }

        public override FireHydrantType Get(Guid id)
        {
            var result = Context.FireHydrantTypes
                        .Include(s => s.Localizations)
                        .First(s => s.Id == id);

            return result;
        }

        public override List<FireHydrantType> GetList()
        {
            var result = Context.FireHydrantTypes
						.Where(ft => ft.IsActive)
                        .Include(s => s.Localizations)
                        .ToList();

            return result;
        }

	    public List<FireHydrantTypeLocalized> GetListLocalized(string languageCode)
	    {
		    var query = from hydrantType in Context.FireHydrantTypes.AsNoTracking()
			    where hydrantType.IsActive
			    from localization in hydrantType.Localizations.DefaultIfEmpty()
			    where localization.IsActive && localization.LanguageCode == languageCode
			    orderby localization.Name
			    select new FireHydrantTypeLocalized()
			    {
				    Id = hydrantType.Id,
				    Name = localization.Name
			    };
		    return query.ToList();
	    }
    }
}
