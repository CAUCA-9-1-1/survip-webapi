using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import.Country
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
		    ImportationResult importResult = new ImportationResult
		    {
			    HasBeenImported = validationResult.IsValid,
			    IdEntity = countryToImport.Id,
			    Messages =
				    new FluentValidationErrorFormatter().GetFluentValidationErrorList(validationResult.Errors
					    .ToList())
		    };
		    return importResult;
	    }

	    public Models.FireSafetyDepartments.Country TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.Country countryToImport, Models.FireSafetyDepartments.Country newCountry)
	    {
		    newCountry.IdExtern = countryToImport.Id;
		    newCountry.CodeAlpha2 = countryToImport.CodeAlpha2;
		    newCountry.CodeAlpha3 = countryToImport.CodeAlpha3;
		    newCountry.IsActive = countryToImport.IsActive;
		    newCountry.ImportedOn = DateTime.Now;
			newCountry.Localizations = TransferLocalizationsFromImported(countryToImport.Localizations.ToList(), newCountry);

		    return newCountry;
	    }

	    public List<CountryLocalization> TransferLocalizationsFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, Models.FireSafetyDepartments.Country newCountry)
	    {
		    List<CountryLocalization> newLocalizations = new List<CountryLocalization>();
		    importedLocalizations.ForEach(localization => newLocalizations.Add(ImportLocalization(localization,newCountry)));
		   
		    return newLocalizations;
	    }


	    public CountryLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Models.FireSafetyDepartments.Country newCountry)
	    {
		    CountryLocalization existingLocalization =
			    newCountry.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
		    if(existingLocalization != null)
			    return UpdateLocalization(importedLoc, existingLocalization);
		    return CreateLocalization(importedLoc, newCountry.Id);
	    }

	    public CountryLocalization UpdateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
		    CountryLocalization newLocalization)
	    {
		    newLocalization.Name = importedLoc.Name;
		    return newLocalization;
	    }

	    public CountryLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId)
	    {
		    return new CountryLocalization {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name};
	    }

	    public ValidationResult GetValidationResult(ApiClient.DataTransferObjects.Country countryToImport)
	    {
		    return validator.Validate(countryToImport);
	    }
    }
}
