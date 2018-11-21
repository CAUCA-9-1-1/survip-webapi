using System;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks
{
    public class EntityLocalizationConverterMock 
        : EntityLocalizationConverter<Models.FireSafetyDepartments.Country, CountryLocalization>
    {
        public bool CustomFieldsAreBeingCopied { get; set; }
        public bool LocalizationIsBeingCreatedWhenItDoesntExist { get; set; }
        public bool LocalizationIsBeingUpdatedWhenItExists { get; set; }

        public CountryLocalization UpdateMyLocalization(
            ApiClient.DataTransferObjects.Base.Localization importedLoc,
            CountryLocalization existingLocalization, bool isActive)
        {
            return base.UpdateLocalization(importedLoc, existingLocalization, isActive);
        }

        public CountryLocalization CreateMyLocalization(
            ApiClient.DataTransferObjects.Base.Localization importedLoc,
            Guid idParent, bool isActive)
        {
            return base.CreateLocalization(importedLoc, idParent, isActive);
        }
        
        protected override void CopyCustomLocalizationFields(
            ApiClient.DataTransferObjects.Base.Localization importedLoc, 
            CountryLocalization existingLocalization)
        {
            CustomFieldsAreBeingCopied = true;
            base.CopyCustomLocalizationFields(importedLoc, existingLocalization);
        }

        protected override CountryLocalization CreateLocalization(
            ApiClient.DataTransferObjects.Base.Localization importedLoc, Guid newCountryId, bool isActive)
        {
            LocalizationIsBeingCreatedWhenItDoesntExist = true;
            return base.CreateLocalization(importedLoc, newCountryId, isActive);
        }

        protected override CountryLocalization UpdateLocalization(
            ApiClient.DataTransferObjects.Base.Localization importedLoc, 
            CountryLocalization existingLocalization, bool isActive)
        {
            LocalizationIsBeingUpdatedWhenItExists = true;
            return base.UpdateLocalization(importedLoc, existingLocalization, isActive);
        }
    }
}
