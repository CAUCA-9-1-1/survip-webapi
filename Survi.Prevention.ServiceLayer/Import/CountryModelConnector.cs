using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import
{
    public class CountryModelConnector
    {
	    private readonly CountryValidator validator;

	    public CountryModelConnector()
	    {
			validator = new CountryValidator();
	    }

	    public ImportationResult ValidateCountry(ApiClient.DataTransferObjects.Country countryToImport)
	    {
		    var validationResult = GetValidationResult(countryToImport);		    
		    ImportationResult importResult = new ImportationResult();
		    importResult.HasBeenImported = validationResult.IsValid;
		    importResult.IdEntity = countryToImport.Id;
		    importResult.Messages =
			    new FormatFluentValidationErrorsToStringList().GetFluentValidationErrorList(validationResult.Errors.ToList());
		    return importResult;
	    }

	    public Country TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.Country countryToImport)
	    {
		    Country newCountry = new Country {IdExtern = countryToImport.Id, CodeAlpha2 = countryToImport.CodeAlpha2, 
			    CodeAlpha3 = countryToImport.CodeAlpha3, IsActive = countryToImport.IsActive, ImportedOn = DateTime.Now};
				newCountry.Localizations = TransferLocalizationFromImported(countryToImport.Localizations.ToList(), newCountry.Id);

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

	    protected ValidationResult GetValidationResult(ApiClient.DataTransferObjects.Country countryToImport)
	    {
		    return validator.Validate(countryToImport);
	    }
    }
}
