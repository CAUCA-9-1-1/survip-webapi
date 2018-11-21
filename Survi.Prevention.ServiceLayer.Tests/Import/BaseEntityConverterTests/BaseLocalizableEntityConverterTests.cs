using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests.Mocks;
using Xunit;
using imported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.ServiceLayer.Tests.Import.BaseEntityConverterTests
{
    public class BaseLocalizableEntityConverterTests
    {
        [Fact]
        public void LocalizationCustomFieldsAreBeingCopied()
        {
            var importedCountry = new imported.Country {Localizations = new List<imported.Base.Localization>()};
            var dataCountry = new Country {Localizations = new List<CountryLocalization>()};

            var converter = new BaseLocalizableEntityConverterMock(null, null);
            converter.CopyField(importedCountry, dataCountry);

            Assert.True(converter.LocalizationFieldsAreBeingCopied);
        }
    }
}