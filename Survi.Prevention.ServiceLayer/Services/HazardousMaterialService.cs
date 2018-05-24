using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			if (searchTerm == null)
				searchTerm = "";

			searchTerm = searchTerm.ToLower();

			var query =
				from mat in Context.HazardousMaterials.AsNoTracking()
				where mat.IsActive
				from loc in mat.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				where loc.Name.ToLower().Contains(searchTerm) || mat.Number.ToLower().Contains(searchTerm)
				orderby loc.Name
				select new HazardousMaterialForList
				{
					Id = mat.Id,
					Number = mat.Number,
					Name = loc.Name
				};

			return query.Take(30).ToList();
		}

	    public List<HazardousMaterialForList> GetListRegex(string languageCode, string searchTerm)
	    {
			var newsearch = searchTerm.Trim().Normalize(NormalizationForm.FormD).Where(c => c < 128).ToArray();
		    var query =
			    from mat in Context.HazardousMaterials
			    where mat.IsActive
			    from loc in mat.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    where new String(loc.Name.Trim().Normalize(NormalizationForm.FormD).Where(c => c < 128).ToArray()) == searchTerm || mat.Number.Contains(searchTerm)
			    select new HazardousMaterialForList
			    {
				    Id = mat.Id,
				    Number = mat.Number,
				    Name = loc.Name
			    };

		    return query.ToList();
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
