using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class ConstructionService : BaseService
    {
	    public ConstructionService(ManagementContext context) : base(context)
	    {
	    }
	    
	    public List<GenericModelForDisplay> GetBuildingSidingTypes(string languageCode)
	    {
		    var query =
			    from type in Context.SidingTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}

	    public List<GenericModelForDisplay> GetBuildingTypes(string languageCode)
	    {
		    var query =
			    from type in Context.BuildingTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}

	    public List<GenericModelForDisplay> GetConstructionFireResistanceTypes(string languageCode)
	    {
		    var query =
			    from type in Context.ConstructionFireResistanceTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}

	    public List<GenericModelForDisplay> GetConstructionTypes(string languageCode)
	    {
		    var query =
			    from type in Context.ConstructionTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}

	    public List<GenericModelForDisplay> GetRoofMaterialTypes( string languageCode)
	    {
		    var query =
			    from type in Context.RoofMaterialTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}

	    public List<GenericModelForDisplay> GetRoofTypes(string languageCode)
	    {
		    var query =
			    from type in Context.RoofTypes.AsNoTracking()
			    where type.IsActive
			    from loc in type.Localizations
			    where loc.IsActive && loc.LanguageCode == languageCode
			    select new GenericModelForDisplay { Id = type.Id, Name = loc.Name };

		    return query.ToList();
		}
	}
}
