using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using countyImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountyImportTests
    {
		private readonly countyImported.County importedCounty;
		private County existingCounty;
		private readonly CountyModelConnector service;

		public CountyImportTests()
		{
			importedCounty = new countyImported.County
			{
				Id = "state1",
				IdState = "St1",
				IdRegion = "Re1",
				IsActive = true,
				Localizations = new List<countyImported.Base.Localization>
				{
					new countyImported.Base.Localization{Name = "County 1", LanguageCode = "en"},
					new countyImported.Base.Localization{Name = "Mrc 1", LanguageCode = "fr"}
				}
			};

			existingCounty = new County
			{
				Id = Guid.NewGuid(),
				IdState = Guid.NewGuid(),
				IdRegion = Guid.NewGuid(),
				IsActive = true,
			};
			existingCounty.Localizations = new List<CountyLocalization>
			{
				new CountyLocalization
					{Id = Guid.NewGuid(), Name = "County 1", LanguageCode = "en", IdParent = existingCounty.Id},
				new CountyLocalization
					{Id = Guid.NewGuid(), Name = "Mrc 1", LanguageCode = "fr", IdParent = existingCounty.Id}
			};

			var countries = new List<Country>();
			var ctx = new BaseContextMock();
			ctx.Setup(context => context.Countries).Returns(ctx.GetMockDbSet(countries).Object);

			service = new CountyModelConnector(ctx.Object);
		}

		[Fact]
		public void NewIdLocalizationHasBeenCorrectlySet()
		{
			var newId = Guid.NewGuid();
			var copy = service.CreateLocalization(importedCounty.Localizations.First(), newId, true);

			Assert.True(newId == copy.IdParent);
		}

		[Fact]
		public void ExistingIdLocalizationHasBeenCorrectlySet()
		{
			var copy = service.ImportLocalization(importedCounty.Localizations.First(), existingCounty);

			Assert.True(existingCounty.Id == copy.IdParent);
		}

		[Fact]
		public void LocalizationFieldsAreCorrectlyCopied()
		{
			var copy = service.CreateLocalization(importedCounty.Localizations.First(), Guid.NewGuid(), true);

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedCounty.Localizations.First(), copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(countyImported.Base.Localization original, CountyLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
		}

		[Fact]
		public void LocalizationsAreComplete()
		{
			existingCounty = new County();
			var copy = service.TransferLocalizationsFromImported(importedCounty.Localizations.ToList(), existingCounty);
			Assert.Equal(importedCounty.Localizations.Count, copy.Count);
		}

		[Fact]
		public void CountyRegionDoesNotExists()
		{
			var validationResult = service.GetIdRegionFromExternal(importedCounty.IdRegion);

			Assert.False(validationResult.HasBeenImported);
		}

	    [Fact]
	    public void CountyStateDoesNotExists()
	    {
		    var validationResult = service.GetIdStateFromExternal(importedCounty.IdState);

		    Assert.False(validationResult.HasBeenImported);
	    }
    }
}
