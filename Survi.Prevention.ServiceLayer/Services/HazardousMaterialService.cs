using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class HazardousMaterialService : BaseService
    {
	    public HazardousMaterialService(ManagementContext context) : base(context)
	    {
	    }

	    public List<HazardousMaterialForList> GetList(string languageCode, string searchTerm)
	    {
		    searchTerm = (searchTerm??"").RemoveDiacritics();

		    var query =
			    from mat in Context.HazardousMaterials
			    where mat.IsActive
			    from loc in mat.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    where loc.Name.RemoveDiacritics().Contains(searchTerm) || mat.Number.RemoveDiacritics().Contains(searchTerm)
			    orderby loc.Name
			    select new HazardousMaterialForList
			    {
				    Id = mat.Id,
				    Number = mat.Number,
				    Name = loc.Name
			    };

		    return query.Take(30).ToList();
	    }

	    

	    public HazardousMaterialForList Get(string languageCode, Guid idHazardousMaterial)
	    {
		    var query =
			    from mat in Context.HazardousMaterials.AsNoTracking()
			    where mat.IsActive && mat.Id == idHazardousMaterial
			    from loc in mat.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
				select new HazardousMaterialForList
			    {
				    Id = mat.Id,
				    Number = mat.Number,
				    Name = loc.Name
			    };

			return query.SingleOrDefault();
	    }
    }
}
