using System;
using System.Collections.Generic;
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
        private RegionImportationConverter service;

	    public RegionImportTests()
	    {
	        importedRegion = new regionImported.Region
		    {
			    Id = "region1",
			    Code = "PhilRegion",
			    IdState= "CAUCA04062012-11",
			    IsActive = true,
			    Localizations = new List<regionImported.Base.Localization>
			    {
				    new regionImported.Base.Localization{Name = "Region 1", LanguageCode = "en"},
				    new regionImported.Base.Localization{Name = "Région 1", LanguageCode = "fr"}
			    }
		    };

		    var existingRegion = new Region
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

		    InitiateTestingMock();
	    }

		private void InitiateTestingMock()
		{
			var mockContext = new BaseContextMock();
			mockContext.Setup(context => context.States).Returns(mockContext.GetMockDbSet(new List<State>()).Object);
			mockContext.Setup(context => context.Set<State>()).Returns(mockContext.GetMockDbSet(new List<State>()).Object);
			mockContext.Setup(context => context.Set<Region>()).Returns(mockContext.GetMockDbSet(new List<Region>()).Object);
			mockContext.Object.Set<State>().Add(new State{Id = Guid.NewGuid(), IdExtern = "CAUCA04062012-11", Localizations = new List<StateLocalization>()});
			service = new RegionImportationConverter(mockContext.Object, new RegionValidator());
		}

	    [Fact]
	    public void EntityFieldsHasBeenCorrectlySet()
	    {
		    var validationResult = service.Convert(importedRegion);
			Assert.True(validationResult.Result.Code == importedRegion.Code && validationResult.Result.IdExtern == importedRegion.Id);
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
