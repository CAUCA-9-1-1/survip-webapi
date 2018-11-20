using FluentValidation;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
    public class CountryImportationConverter 
        : BaseLocalizableEntityConverter<
            ApiClient.DataTransferObjects.Country, 
            Models.FireSafetyDepartments.Country, 
            CountryLocalization>
    {
        public CountryImportationConverter(
            IManagementContext context, 
            AbstractValidator<ApiClient.DataTransferObjects.Country> validator) 
            : base(context, validator)
        {
        }

        protected override void CopyCustomFieldsToEntity(
            ApiClient.DataTransferObjects.Country importedObject, 
            Models.FireSafetyDepartments.Country entity)
        {
            entity.CodeAlpha2 = importedObject.CodeAlpha2;
            entity.CodeAlpha3 = importedObject.CodeAlpha3;
        }

        /*private readonly CountryValidator validator;

	    public CountryImportationConverter()
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
			    return UpdateLocalization(importedLoc, existingLocalization, newCountry.IsActive);
		    return CreateLocalization(importedLoc, newCountry.Id, newCountry.IsActive);
	    }

	    public CountryLocalization UpdateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
		    CountryLocalization existingLocalization, bool isActive)
	    {
		    existingLocalization.Name = importedLoc.Name;
		    existingLocalization.IsActive = isActive;
		    return existingLocalization;
	    }

	    public CountryLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
	    {
		    return new CountryLocalization {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name, IsActive = isActive};
	    }

	    public ValidationResult GetValidationResult(ApiClient.DataTransferObjects.Country countryToImport)
	    {
		    return validator.Validate(countryToImport);
	    }*/

    }
}
