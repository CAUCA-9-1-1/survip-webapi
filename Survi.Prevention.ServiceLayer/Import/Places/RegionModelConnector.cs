using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Import.Places
{
	public class RegionModelConnector
	{
		private readonly RegionValidator validator;
		private readonly IManagementContext regionContext;
		private Guid idExistingState = Guid.Empty;

		public RegionModelConnector(IManagementContext context)
		{
			regionContext = context;
			validator = new RegionValidator();
		}

		public ImportationResult ValidateRegion(ApiClient.DataTransferObjects.Region regionToImport)
		{
			ImportationResult importResult = ValidateExternalState(regionToImport.IdState);
			if (importResult.HasBeenImported)
			{
				var validationResult = GetValidationResult(regionToImport);
				importResult = new ImportationResult
				{
					HasBeenImported = validationResult.IsValid,
					IdEntity = regionToImport.Id,
					Messages = new FluentValidationErrorFormatter()
						.GetFluentValidationErrorList(validationResult.Errors.ToList())
				};
			}

			return importResult;
		}

		public Region TransferDtoImportedToOriginal(ApiClient.DataTransferObjects.Region importedRegion, Region existingRegion)
		{
			existingRegion.IdExtern = importedRegion.Id;
			existingRegion.Code = importedRegion.Code;
			existingRegion.ImportedOn = DateTime.Now;
			existingRegion.IsActive = importedRegion.IsActive;
			existingRegion.IdState = idExistingState;
			existingRegion.Localizations = TransferLocalizationsFromImported(importedRegion.Localizations.ToList(), existingRegion);

			return existingRegion;
		}

		public Guid GetIdStateFromExternal(string idStateExternal)
		{
			var country = regionContext.States?.SingleOrDefault(c => c.IdExtern == idStateExternal);
			if (country != null)
				idExistingState = country.Id;

			return idExistingState;
		}

		public ImportationResult ValidateExternalState(string idStateExternal)
		{
			if (GetIdStateFromExternal(idStateExternal) == Guid.Empty)
				return new ImportationResult{EntityName = "State", HasBeenImported = false, Messages = new List<string>{"Region_UnknownState"},IdEntity = idStateExternal};
			return new ImportationResult{HasBeenImported = true};
		}

		public List<RegionLocalization> TransferLocalizationsFromImported(List<ApiClient.DataTransferObjects.Base.Localization> importedLocalizations, Region existingRegion)
		{
			List<RegionLocalization> newLocalizations = new List<RegionLocalization>();
			importedLocalizations.ForEach(localization => newLocalizations.Add(ImportLocalization(localization,existingRegion)));
		   
			return newLocalizations;
		}


		public RegionLocalization ImportLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Region existingRegion)
		{
			RegionLocalization existingLocalization =
				existingRegion.Localizations?.SingleOrDefault(loc => loc.LanguageCode == importedLoc.LanguageCode);
			if(existingLocalization != null)
				return UpdateLocalization(importedLoc, existingLocalization, existingRegion.IsActive);
			return CreateLocalization(importedLoc, existingRegion.Id, existingRegion.IsActive);
		}

		public RegionLocalization UpdateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc,
			RegionLocalization newLocalization, bool isActive)
		{
			newLocalization.Name = importedLoc.Name;
			newLocalization.IsActive = isActive;
			return newLocalization;
		}

		public RegionLocalization CreateLocalization(ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
		{
			return new RegionLocalization {IdParent = newCountryId, LanguageCode = importedLoc.LanguageCode, Name = importedLoc.Name, IsActive = isActive};
		}

		public ValidationResult GetValidationResult(ApiClient.DataTransferObjects.Region stateToImport)
		{
			return validator.Validate(stateToImport);
		}
	}
}
