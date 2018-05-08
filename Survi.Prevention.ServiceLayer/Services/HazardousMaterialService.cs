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
			var query =
				from mat in Context.HazardousMaterials.AsNoTracking()
				where mat.IsActive
				from loc in mat.Localizations
				where loc.IsActive && loc.LanguageCode == languageCode
				where loc.Name.Contains(searchTerm) || mat.GuideNumber.Contains(searchTerm)
				select new HazardousMaterialForList
				{
					Id = mat.Id,
					GuideNumber = mat.GuideNumber,
					Name = loc.Name
				};

			return query.ToList();
		}

	    public string GetName(string languageCode, Guid idHazardousMaterial)
	    {
		    var query =
			    from mat in Context.HazardousMaterials.AsNoTracking()
			    where mat.IsActive && mat.Id == idHazardousMaterial
			    from loc in mat.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select loc.Name;

		    return query.SingleOrDefault() ?? "";
	    }
    }
}
