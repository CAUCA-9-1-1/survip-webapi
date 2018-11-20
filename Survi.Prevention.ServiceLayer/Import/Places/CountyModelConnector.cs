using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using County = Survi.Prevention.Models.FireSafetyDepartments.County;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
    public class CountyModelConnector
    {
	    private readonly CountyValidator validator;
		private readonly IManagementContext countyContext;
		private Guid idExistingState = Guid.Empty;
	    private Guid idExistingRegion = Guid.Empty;

		public CountyModelConnector(IManagementContext context)
		{
			countyContext = context;
			validator = new CountyValidator();
		}

		public ImportationResult ValidateCounty(ApiClient.DataTransferObjects.County countyToImport)
		{
			ImportationResult importResult = ValidateForeignKey(countyToImport);
			if (importResult.HasBeenImported)
			{
				var validationResult = GetValidationResult(countyToImport);
				importResult = new ImportationResult
				{
					HasBeenImported = validationResult.IsValid,
					IdEntity = countyToImport.Id,
					Messages = new FluentValidationErrorFormatter()
						.GetFluentValidationErrorList(validationResult.Errors.ToList())
				};
			}

			return importResult;
		}

		public County TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.County importedCounty, County existingCounty)
		{
			existingCounty.IdExtern = importedCounty.Id;
			existingCounty.ImportedOn = DateTime.Now;
			existingCounty.IsActive = importedCounty.IsActive;
			existingCounty.IdState = idExistingState;
			existingCounty.IdRegion = idExistingRegion;
			existingCounty.Localizations = TransferLocalizationsFromImported(importedCounty.Localizations.ToList(), existingCounty);

			return existingCounty;
		}

		public ImportationResult ValidateForeignKey(ApiClient.DataTransferObjects.County importedCounty)
		{
			ImportationResult retValue =  GetIdStateFromExternal(importedCounty.IdState);
			
			if(retValue.HasBeenImported)
				retValue = GetIdRegionFromExternal(importedCounty.IdRegion);

			return retValue;
		}

		public ImportationResult GetIdStateFromExternal(string idStateExternal)
		{
			var country = countyContext.States?.SingleOrDefault(c => c.IdExtern == idStateExternal);
			if (country != null)
			{
				idExistingState = country.Id;
				return new ImportationResult {HasBeenImported = true};
			}

			return new ImportationResult{EntityName = "County", Messages = new List<string>{"County_UnknownState"},IdEntity = idStateExternal};
		}

	    public ImportationResult GetIdRegionFromExternal(string idRegionExternal)
	    {
		    var country = countyContext.Regions?.SingleOrDefault(c => c.IdExtern == idRegionExternal);
		    if (country != null)
		    {
			    idExistingRegion = country.Id;
			    return new ImportationResult{HasBeenImported = true};
		    }

		    return new ImportationResult{EntityName = "County", Messages = new List<string>{"County_UnknownRegion"},IdEntity = idRegionExternal};
	    }

		public List<CountyLocalization> TransferLocalizationsFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, County existingCounty)
		{
			List<CountyLocalization> newLocalizations = new List<CountyLocalization>();
			importedLocalizations.ForEach(localization => newLocalizations.Add(ImportLocalization(localization,existingCounty)));
		   
			return newLocalizations;
		}


		public CountyLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, County existingCounty)
		{
			CountyLocalization existingLocalization =
				existingCounty.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
			if(existingLocalization != null)
				return UpdateLocalization(importedLoc, existingLocalization, existingCounty.IsActive);
			return CreateLocalization(importedLoc, existingCounty.Id, existingCounty.IsActive);
		}

		public CountyLocalization UpdateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
			CountyLocalization newLocalization, bool isActive)
		{
			newLocalization.Name = importedLoc.Name;
			newLocalization.IsActive = isActive;
			return newLocalization;
		}

		public CountyLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
		{
			return new CountyLocalization {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name, IsActive = isActive};
		}

		public ValidationResult GetValidationResult(ApiClient.DataTransferObjects.County stateToImport)
		{
			return validator.Validate(stateToImport);
		}
    }
}
