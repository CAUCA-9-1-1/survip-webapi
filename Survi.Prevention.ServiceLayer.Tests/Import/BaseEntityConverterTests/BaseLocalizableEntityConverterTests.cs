using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class BaseLocalizableEntityConverterTests
    {
        [Fact]
        public void LocalizationCustomFieldsAreBeingCopied()
        {
            var importedCountry = new ApiClient.DataTransferObjects.Country {Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>()};
            var dataCountry = new Models.FireSafetyDepartments.Country {Localizations = new List<Models.FireSafetyDepartments.CountryLocalization>()};

            var converter = new BaseLocalizableEntityConverterMock(null, null);
            converter.CopyField(importedCountry, dataCountry);

            Assert.True(converter.LocalizationFieldsAreBeingCopied);
        }
    }
}