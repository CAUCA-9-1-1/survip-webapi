using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
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
	    private readonly RegionImportationConverter service;

	    public RegionImportTests()
	    {
		    importedRegion = new regionImported.Region
		    {
			    Id = "region1",
			    Code = "PhilRegion",
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

		    var ctx = new BaseContextMock();
		    ctx.Setup(context => context.States).Returns(ctx.GetMockDbSet(new List<State>()).Object);
		    ctx.Setup(context => context.Set<State>()).Returns(ctx.GetMockDbSet(new List<State>()).Object);
		    ctx.Setup(context => context.Set<Region>()).Returns(ctx.GetMockDbSet(new List<Region>()).Object);
		    ctx.Object.Set<State>().Add(new State{Id = Guid.NewGuid(), IdExtern = "PhilState1", Localizations = new List<StateLocalization>()});
		    service = new RegionImportationConverter(ctx.Object, new RegionValidator());
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
		    var validationResult = service.Convert(importedRegion);
			Assert.True(validationResult.Result.Code == importedRegion.Code && validationResult.Result.IdState.ToString() == importedRegion.IdState);
	    }

	    [Fact]
	    public void EntityHasBeenCorrectlyValidated()
	    {
		    importedRegion.Code = "test avec plus que 10";
		    Assert.False(service.Convert(importedRegion).IsValid);
	    }

	    [Fact]
	    public void RegionStateDoesNotExists()
	    {
		    importedRegion.IdState = "123465789";
		    Assert.False(service.Convert(importedRegion).IsValid);
	    }
    }
}
