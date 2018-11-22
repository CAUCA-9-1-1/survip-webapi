using System;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Places;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using cityImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CityImportTests
    {
		private readonly cityImported.City importedCity;
        private readonly City existingCity;

        public CityImportTests()
        {
            importedCity = new cityImported.City
            {
                Id = "city1",
                Code = "CO",
                Code3Letters = "CO3",
				EmailAddress = "",
                IsActive = true,
				IdCounty = "CAUCA21092005-10",
				IdCityType = "CAUCA16022006-15",
                Localizations = new List<cityImported.Base.Localization>
                {
                    new cityImported.Base.Localization {Name = "City 1", LanguageCode = "en"},
                    new cityImported.Base.Localization {Name = "Ville 1", LanguageCode = "fr"}
                }
            };

            existingCity = new City
            {
                Id = Guid.NewGuid(),
	            Code = "PhilCity",
	            Code3Letters = "PSC",
	            EmailAddress = "philCity@rule.com",
                IsActive = true,
	            IdCounty = Guid.NewGuid(),
	            IdCityType = Guid.NewGuid(),

            };
            existingCity.Localizations = new List<CityLocalization>
            {
                new CityLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existingCity.Id},
                new CityLocalization
                    {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existingCity.Id}
            };
        }

        private IManagementContext CreateMockContext()
        {
            var cities = new List<City>{existingCity};
			var counties = new List<County>{new County{IdExtern = "CAUCA21092005-10"}};
	        var cityTypes = new List<CityType>{new CityType{IdExtern = "CAUCA16022006-15"}};
            var mockCtx = new BaseContextMock();
            mockCtx.Setup(ctx => ctx.Set<City>()).Returns(mockCtx.GetMockDbSet(cities).Object);
	        mockCtx.Setup(ctx => ctx.Set<County>()).Returns(mockCtx.GetMockDbSet(counties).Object);
	        mockCtx.Setup(ctx => ctx.Set<CityType>()).Returns(mockCtx.GetMockDbSet(cityTypes).Object);
            return mockCtx.Object;
        }

        [Fact]
        public void CustomFieldsAreCorrectlyCopied()
        {
            var validator = new CityValidator();
            var converter = new CityImportationConverter(CreateMockContext(), validator);
            var result = converter.Convert(importedCity).Result;

            Assert.True(result.Code == importedCity.Code && result.Code3Letters == importedCity.Code3Letters && result.EmailAddress == importedCity.EmailAddress);
        }
    }
}
