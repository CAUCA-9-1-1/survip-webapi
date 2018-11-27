using imported = Survi.Prevention.ApiClient.DataTransferObjects.Base;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.Import
{
    public class BaseLocalizationValidator
    {
	    public virtual bool HaveLocalizationNames(ICollection<imported.Localization> localizations)
	    {
		    if(localizations == null)
			    return false;

		    foreach (var loc in localizations)
		    {
			    if (string.IsNullOrEmpty(loc.Name))
				    return false;
		    }

		    return true;
	    }

	    public virtual bool HaveRequiredLocalizationCount(ICollection<imported.Localization> localizations)
	    {
		    if(localizations == null || localizations.Count <= 1)
			    return false;
		    return true;
	    }

	    public virtual bool HaveRequiredLanguages(ICollection<imported.Localization> localizations)
	    {
		    if(localizations == null)
			    return false;

		    if (localizations.Any(loc => string.IsNullOrEmpty(loc.LanguageCode)))
			    return false;

		    List<string> languages = new List<string>{"fr","en"};		    
		    foreach (var code in languages)
		    {
			    if (localizations.All(loc => loc.LanguageCode != code))
				    return false;
		    }
		    return true;
	    }
    }
}
