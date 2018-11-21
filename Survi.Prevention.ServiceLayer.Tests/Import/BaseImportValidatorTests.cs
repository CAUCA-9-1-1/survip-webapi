using System.Collections.Generic;
using Xunit;
using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Tests.Mocks.Validations;
using Imported = Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ServiceLayer.Tests.Import
{
    public class BaseImportValidatorTests
    {
        private readonly MockLocalizableObjectValidator validator;

        public BaseImportValidatorTests()
        {
            validator = new MockLocalizableObjectValidator();
        }

        [Fact]
        public void NoValidationErrorWhenLocalizationAreCorrectlyConfigured()
        {
            var loc = new List<Imported.Localization>
            {
                new Imported.Localization {Name = "Country 1", LanguageCode = "en"},
                new Imported.Localization {Name = "Pays 1", LanguageCode = "fr"}
            };

            validator.ShouldNotHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void DoesNotValidateWhenLocalizationsIsNull()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, null as List<Imported.Localization>);
        }

        [Fact]
        public void LocalizationsMustContainsCorrectLanguageCode()
        {
            var loc = new List<Imported.Localization>
            {
                new Imported.Localization {Name = "Country 1", LanguageCode = "en"},
                new Imported.Localization {Name = "Pays 1", LanguageCode = ""}
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void LocalizationsMustContainsCorrectName()
        {
            var loc = new List<Imported.Localization>
            {
                new Imported.Localization {Name = "Country 1", LanguageCode = "en"},
                new Imported.Localization {Name = "", LanguageCode = "fr"}
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void CountryMustContainsRequiredLanguages()
        {
            var loc = new List<Imported.Localization>
            {
                new Imported.Localization {Name = "Country 1", LanguageCode = "en"},
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }
    }
}
