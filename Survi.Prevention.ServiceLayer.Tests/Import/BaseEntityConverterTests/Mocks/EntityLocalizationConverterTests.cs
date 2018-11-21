using System;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;
using Imported = Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class EntityLocalizationConverterMock 
        : EntityLocalizationConverter<Country, CountryLocalization>
    {
        public bool CustomFieldsAreBeingCopied { get; set; }
        public bool LocalizationIsBeingCreatedWhenItDoesNotExist { get; set; }
        public bool LocalizationIsBeingUpdatedWhenItExists { get; set; }

        public CountryLocalization UpdateMyLocalization(
	        Imported.Localization importedLoc,
            CountryLocalization existingLocalization, bool isActive)
        {
            return base.UpdateLocalization(importedLoc, existingLocalization, isActive);
        }

        public CountryLocalization CreateMyLocalization(
	        Imported.Localization importedLoc,
            Guid idParent, bool isActive)
        {
            return base.CreateLocalization(importedLoc, idParent, isActive);
        }
        
        protected override void CopyCustomLocalizationFields(
	        Imported.Localization importedLoc, 
            CountryLocalization existingLocalization)
        {
            CustomFieldsAreBeingCopied = true;
            base.CopyCustomLocalizationFields(importedLoc, existingLocalization);
        }

        protected override CountryLocalization CreateLocalization(
	        Imported.Localization importedLoc, Guid newCountryId, bool isActive)
        {
	        LocalizationIsBeingCreatedWhenItDoesNotExist = true;
            return base.CreateLocalization(importedLoc, newCountryId, isActive);
        }

        protected override CountryLocalization UpdateLocalization(
	        Imported.Localization importedLoc, 
            CountryLocalization existingLocalization, bool isActive)
        {
            LocalizationIsBeingUpdatedWhenItExists = true;
            return base.UpdateLocalization(importedLoc, existingLocalization, isActive);
        }
    }
}
