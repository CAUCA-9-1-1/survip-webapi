using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.ServiceLayer.Import.Country
{
	public class StateModelConnector
	{
		private readonly StateValidator validator;
		private readonly IManagementContext stateContext;

		public StateModelConnector(IManagementContext context)
		{
			stateContext = context;
			validator = new StateValidator(context);
		}

		public ImportationResult ValidateState(ApiClient.DataTransferObjects.State stateToImport)
		{
			var validationResult = GetValidationResult(stateToImport);
			ImportationResult importResult = new ImportationResult
			{
				HasBeenImported = validationResult.IsValid,
				IdEntity = stateToImport.Id,
				Messages = new FormatFluentValidationErrorsToStringList()
							.GetFluentValidationErrorList(validationResult.Errors.ToList())
			};
			return importResult;
		}

		public State TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.State importedState)
		{
			State newState = new State
			{
				IdExtern = importedState.Id, 
				AnsiCode = importedState.AnsiCode, 
				ImportedOn = DateTime.Now,
				IsActive = importedState.IsActive,
				IdCountry = GetIdCountryFromExternal(importedState.IdCountry)
			};
			newState.Localizations = TransferLocalizationFromImported(importedState.Localizations.ToList(), newState.Id);

			return newState;
		}

		public Guid GetIdCountryFromExternal(string idCountryExternal)
		{
			var country = stateContext.Countries.SingleOrDefault(c => c.IdExtern == idCountryExternal);
			if (country != null)
				return country.Id;
			return Guid.Empty;
		}

		public List<StateLocalization> TransferLocalizationFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, Guid newStateId)
		{
			List<StateLocalization> newLocalizations = new List<StateLocalization>();
			importedLocalizations.ForEach(localization =>
				newLocalizations.Add(ImportLocalization(localization, newStateId)));
	
			return newLocalizations;
		}

		public StateLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLocalization,Guid newStateId)
		{
			return new StateLocalization
				{IdParent = newStateId, LanguageCode = importedLocalization.LanguageCode, Name = importedLocalization.Name};
		}

		private ValidationResult GetValidationResult(ApiClient.DataTransferObjects.State stateToImport)
		{
			return validator.Validate(stateToImport);
		}
	}
}
