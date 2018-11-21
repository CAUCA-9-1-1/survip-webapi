using System;
using System.Collections.Generic;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Imported = Survi.Prevention.ApiClient.DataTransferObjects.Base;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class EntityLocalizationConverterTests
    {
        [Fact]
        public void MissingLocalizationAreCorrectlyAdded()
        {
            var converter = new EntityLocalizationConverterMock();
            var localization = new Imported.Localization {Name = "Test", LanguageCode = "fr"};
            var idParent = Guid.NewGuid();
            var result = converter.CreateMyLocalization(localization, idParent, true);

            Assert.True(LocalizationsAreEqual(result, idParent, localization, true));
        }

        [Fact]
        public void ExistingLocalizationAreCorrectlyUpdated()
        {
            var converter = new EntityLocalizationConverterMock();
            var localization = new Imported.Localization { Name = "Test", LanguageCode = "fr" };
            var existingLocalization = new CountryLocalization { LanguageCode = "fr", Name = "TestOld" };
            var result = converter.UpdateMyLocalization(localization, existingLocalization, true);

            Assert.True(LocalizationsAreEqual(result, existingLocalization.IdParent, localization, true));
        }

        [Fact]
        public void CustomFieldsAreCorrectlyCopiedWhenLocalizationIsMissing()
        {
            var converter = new EntityLocalizationConverterMock();
            var localization = new Imported.Localization { Name = "Test", LanguageCode = "fr" };
            var idParent = Guid.NewGuid();
            converter.CreateMyLocalization(localization, idParent, true);

            Assert.True(converter.CustomFieldsAreBeingCopied);
        }

        [Fact]
        public void CustomsFieldsAreCorrectlyCopiedWhenUpdatingExisingLocalization()
        {
            var converter = new EntityLocalizationConverterMock();
            var localization = new Imported.Localization { Name = "Test", LanguageCode = "fr" };
            var existingLocalization = new CountryLocalization { LanguageCode = "fr", Name = "TestOld" };
            converter.UpdateMyLocalization(localization, existingLocalization, true);

            Assert.True(converter.CustomFieldsAreBeingCopied);
        }

        [Fact]
        public void ConverterIsCorrectlyAddingMissingLocalization()
        {
            var converter = new EntityLocalizationConverterMock();
            var localizations = new List<Imported.Localization> {
                new Imported.Localization {Name = "Test", LanguageCode = "fr"}};
            var country = new Country { Localizations = new List<CountryLocalization>() };

            converter.Convert(localizations, country);

            Assert.True(converter.LocalizationIsBeingCreatedWhenItDoesNotExist);
        }

        [Fact]
        public void ConverterIsCorrectlyUpdatingExistingLocalization()
        {
            var converter = new EntityLocalizationConverterMock();
            var localizations = new List<Imported.Localization> {
                new Imported.Localization {Name = "Test", LanguageCode = "fr"}};
            var country = new Country { Localizations = new List<CountryLocalization>{ new CountryLocalization{ LanguageCode = "fr", Name = "TestOld"}} };

            converter.Convert(localizations, country);

            Assert.True(converter.LocalizationIsBeingUpdatedWhenItExists);
        }

        private static bool LocalizationsAreEqual(CountryLocalization result, Guid idParent, Imported.Localization localization, bool isActive)
        {
            return result.IdParent == idParent 
               && result.LanguageCode == localization.LanguageCode 
               && result.Name == localization.Name 
               && result.IsActive == isActive;
        }
    }
}
