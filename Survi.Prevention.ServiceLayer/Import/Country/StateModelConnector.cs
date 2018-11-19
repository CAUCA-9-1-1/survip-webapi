using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
	public class StateModelConnector
	{
		private readonly StateValidator validator;
		private readonly IManagementContext stateContext;
		private Guid idExistingCountry = Guid.Empty;

		public StateModelConnector(IManagementContext context)
		{
			stateContext = context;
			validator = new StateValidator(context);
		}

		public ImportationResult ValidateState(ApiClient.DataTransferObjects.State stateToImport)
		{
			ImportationResult importResult = ValidateExternalCountry(stateToImport.IdCountry);
			if (importResult.HasBeenImported)
			{
				var validationResult = GetValidationResult(stateToImport);
				importResult = new ImportationResult
				{
					HasBeenImported = validationResult.IsValid,
					IdEntity = stateToImport.Id,
					Messages = new FluentValidationErrorFormatter()
						.GetFluentValidationErrorList(validationResult.Errors.ToList())
				};
			}

			return importResult;
		}

		public State TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.State importedState, State existingState)
		{
			existingState.IdExtern = importedState.Id;
			existingState.AnsiCode = importedState.AnsiCode;
			existingState.ImportedOn = DateTime.Now;
			existingState.IsActive = importedState.IsActive;
			existingState.IdCountry = idExistingCountry;
			existingState.Localizations = TransferLocalizationsFromImported(importedState.Localizations.ToList(), existingState);

			return existingState;
		}

		public Guid GetIdCountryFromExternal(string idCountryExternal)
		{
			var country = stateContext.Countries?.SingleOrDefault(c => c.IdExtern == idCountryExternal);
			if (country != null)
				idExistingCountry = country.Id;

			return idExistingCountry;
		}

		public ImportationResult ValidateExternalCountry(string idCountryExternal)
		{
			if (GetIdCountryFromExternal(idCountryExternal) == Guid.Empty)
				return new ImportationResult{EntityName = "State", HasBeenImported = false, Messages = new List<string>{"StateCountryNotExists"},IdEntity = idCountryExternal};
			return new ImportationResult{HasBeenImported = true};
		}

		public List<StateLocalization> TransferLocalizationsFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, State existingState)
		{
			List<StateLocalization> newLocalizations = new List<StateLocalization>();
			importedLocalizations.ForEach(localization => newLocalizations.Add(ImportLocalization(localization,existingState)));
		   
			return newLocalizations;
		}


		public StateLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, State existingState)
		{
			StateLocalization existingLocalization =
				existingState.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
			if(existingLocalization != null)
				return UpdateLocalization(importedLoc, existingLocalization);
			return CreateLocalization(importedLoc, existingState.Id);
		}

		public StateLocalization UpdateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
			StateLocalization newLocalization)
		{
			newLocalization.Name = importedLoc.Name;
			return newLocalization;
		}

		public StateLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId)
		{
			return new StateLocalization {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name};
		}

		public ValidationResult GetValidationResult(ApiClient.DataTransferObjects.State stateToImport)
		{
			return validator.Validate(stateToImport);
		}
	}
}
