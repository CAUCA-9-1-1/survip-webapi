using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import
{
    public class CountryModelConnector
    {
	    public bool ValidateLocalizations(ApiClient.DataTransferObjects.Country importedCountry)
	    {
		    if (importedCountry.Localizations.Count == 0 && ValidateLanguage(importedCountry.Localizations.ToList()))
				return false;
		    return true;
	    }

	    private bool ValidateLanguage(List<ApiClient.DataTransferObjects.Base.Localization> localizations)
	    {
		    foreach (var loc in localizations)
		    {
			    if (string.IsNullOrEmpty(loc.LanguageCode) || string.IsNullOrEmpty(loc.Name))
				    return false;
		    }

		    return true;
	    }

	    public Country TransferImportedModelToOriginal(ApiClient.DataTransferObjects.Country importedCountry)
	    {
		    Country newCountry = new Country {IdExtern = importedCountry.Id, CodeAlpha2 = importedCountry.CodeAlpha2, 
			    CodeAlpha3 = importedCountry.CodeAlpha3, IsActive = importedCountry.IsActive, ImportedOn = DateTime.Now};
		    newCountry.Localizations = TransferLocalizationFromImported(importedCountry.Localizations.ToList(), newCountry.Id);

		    return newCountry;
	    }

	    public List<CountryLocalization> TransferLocalizationFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalization, Guid newCountryId)
	    {
		    List<CountryLocalization> newLocalizations = new List<CountryLocalization>();
		    foreach (var localization in importedLocalization)
		    {
			    newLocalizations.Add(ImportLocalization(localization, newCountryId));
		    }
		    return newLocalizations;
	    }

	    public CountryLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
		    Guid newCountryId)
	    {
		    return new CountryLocalization
			    {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name};
	    }
    }
}
