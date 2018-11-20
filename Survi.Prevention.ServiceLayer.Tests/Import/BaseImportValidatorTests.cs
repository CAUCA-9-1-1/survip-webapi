using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Survi.Prevention.ServiceLayer.Import;
using Xunit;
using FluentValidation.TestHelper;
using Survi.Prevention.ServiceLayer.Tests.Mocks.Validations;

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
            var loc = new List<ApiClient.DataTransferObjects.Base.Localization>
            {
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Country 1", LanguageCode = "en"},
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Pays 1", LanguageCode = "fr"}
            };

            validator.ShouldNotHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void DoesNotValidateWhenLocalizationsIsNull()
        {
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, null as List<ApiClient.DataTransferObjects.Base.Localization>);
        }

        [Fact]
        public void LocalizationsMustContainsCorrectLanguageCode()
        {
            var loc = new List<ApiClient.DataTransferObjects.Base.Localization>
            {
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Country 1", LanguageCode = "en"},
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Pays 1", LanguageCode = ""}
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void LocalizationsMustContainsCorrectName()
        {
            var loc = new List<ApiClient.DataTransferObjects.Base.Localization>
            {
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Country 1", LanguageCode = "en"},
                new ApiClient.DataTransferObjects.Base.Localization {Name = "", LanguageCode = "fr"}
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }

        [Fact]
        public void CountryMustContainsRequiredLanguages()
        {
            var loc = new List<ApiClient.DataTransferObjects.Base.Localization>
            {
                new ApiClient.DataTransferObjects.Base.Localization {Name = "Country 1", LanguageCode = "en"},
            };
            validator.ShouldHaveValidationErrorFor(m => m.Localizations, loc);
        }
    }
}
