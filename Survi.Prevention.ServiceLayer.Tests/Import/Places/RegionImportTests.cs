using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Places;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;
using regionImported = Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class RegionImportTests
    {
	    private readonly regionImported.Region importedRegion;
	    private Region existingRegion;
	    private readonly RegionModelConnector service;

	    public RegionImportTests()
	    {
		    importedRegion = new regionImported.Region
		    {
			    Id = "region1",
			    Code = "region de phil",
			    IdState= "PhilState1",
			    IsActive = true,
			    Localizations = new List<regionImported.Base.Localization>
			    {
				    new regionImported.Base.Localization{Name = "Region 1", LanguageCode = "en"},
				    new regionImported.Base.Localization{Name = "Région 1", LanguageCode = "fr"}
			    }
		    };

		    existingRegion = new Region
		    {
			    Id = Guid.NewGuid(),
			    Code = "CO",
			    IdState = Guid.NewGuid(),
			    IsActive = true,
		    };
		    existingRegion.Localizations = new List<RegionLocalization>
		    {
			    new RegionLocalization{Id = Guid.NewGuid(), Name = "State 1", LanguageCode = "en", IdParent = existingRegion.Id},
			    new RegionLocalization{Id = Guid.NewGuid(), Name = "Province 1", LanguageCode = "fr", IdParent = existingRegion.Id}
		    };

		    var states = new List<State>();
		    var ctx = new BaseContextMock();
		    ctx.Setup(context => context.States).Returns(ctx.GetMockDbSet(states).Object);

		    service = new RegionModelConnector(ctx.Object);
	    }

	    [Fact]
	    public void NewIdLocalizationHasBeenCorrectlySet()
	    {
		    var newId = Guid.NewGuid();
		    var copy = service.CreateLocalization(importedRegion.Localizations.First(), newId, true);

		    Assert.True(newId == copy.IdParent);
	    }

	    [Fact]
	    public void ExistingIdLocalizationHasBeenCorrectlySet()
	    {
		    var copy = service.ImportLocalization(importedRegion.Localizations.First(), existingRegion);

		    Assert.True(existingRegion.Id == copy.IdParent);
	    }

	    [Fact]
	    public void LocalizationFieldsAreCorrectlyCopied()
	    {
		    var copy = service.CreateLocalization(importedRegion.Localizations.First(), Guid.NewGuid(), true);

		    Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedRegion.Localizations.First(), copy));
	    }

	    private static bool LocalizationHasBeenCorrectlyDuplicated(regionImported.Base.Localization original, RegionLocalization copy)
	    {
		    return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
	    }

	    [Fact]
	    public void LocalizationsAreComplete()
	    {
		    existingRegion = new Region();
		    var copy = service.TransferLocalizationsFromImported(importedRegion.Localizations.ToList(), existingRegion);
		    Assert.Equal(importedRegion.Localizations.Count, copy.Count);
	    }

	    [Fact]
	    public void EntityFieldsHasBeenCorrectlySet()
	    {
		    existingRegion = new Region();
		    var copy = service.TransferDtoImportedToOriginal(importedRegion, existingRegion);

		    Assert.True(importedRegion.Id == copy.IdExtern && importedRegion.Code == copy.Code);
	    }

	    [Fact]
	    public void EntityHasBeenCorrectlyValidated()
	    {
		    importedRegion.Code = "test avec plus que 10";
		    var validationResult = service.GetValidationResult(importedRegion);

		    Assert.False(validationResult.IsValid);
	    }

	    [Fact]
	    public void RegionStateDoesNotExists()
	    {
		    var validationResult = service.ValidateExternalState(importedRegion.IdState);

		    Assert.False(validationResult.HasBeenImported);
	    }
    }
}
