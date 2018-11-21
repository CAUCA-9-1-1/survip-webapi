using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Places;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using countryImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountryImportTests
    {
        private readonly countryImported.Country importedCountry;
        private readonly Country existingCountry;

        public CountryImportTests()
        {
            importedCountry = new countryImported.Country
            {
                Id = "country1",
                CodeAlpha2 = "CO",
                CodeAlpha3 = "CO3",
                IsActive = true,
                Localizations = new List<countryImported.Base.Localization>
                {
                    new countryImported.Base.Localization {Name = "Country 1", LanguageCode = "en"},
                    new countryImported.Base.Localization {Name = "Pays 1", LanguageCode = "fr"}
                }
            };

            existingCountry = new Country
            {
                Id = Guid.NewGuid(),
                CodeAlpha2 = "BO",
                CodeAlpha3 = "BO3",
                IsActive = true

            };
            existingCountry.Localizations = new List<CountryLocalization>
            {
                new CountryLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existingCountry.Id},
                new CountryLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existingCountry.Id}
            };
        }

        private IManagementContext CreateMockContext()
        {
            var countries = new List<Country>{existingCountry};
            var mockCtx = new BaseContextMock();
            mockCtx.Setup(ctx => ctx.Set<Country>()).Returns(mockCtx.GetMockDbSet(countries).Object);
            return mockCtx.Object;
        }

        [Fact]
        public void CustomFieldsAreCorrectlyCopied()
        {
            var validator = new CountryValidator();
            var converter = new CountryImportationConverter(CreateMockContext(), validator);
            var result = converter.Convert(importedCountry).Result;

            Assert.True(result.CodeAlpha2 == importedCountry.CodeAlpha2 && result.CodeAlpha3 == importedCountry.CodeAlpha3);
        }
    }
}
