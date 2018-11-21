using System.Collections.Generic;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class CountyImportValidatorTests
    {
		private readonly County importedCounty;
	    private readonly CountyValidator validator;

	    public CountyImportValidatorTests()
	    {
			validator = new CountyValidator();
		    importedCounty = new County
		    {
			    Id = "county1",
				IdState = "existing state",
				IdRegion = "existing region",
			    IsActive = true,
			    Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
			    {
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "County 1", LanguageCode = "en"},
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "Mrc 1", LanguageCode = "fr"}
			    }
		    };
	    }

	    [Fact]
	    public void StateIsInvalid()
	    {
		    importedCounty.IdState = null;
		    var result = validator.Validate(importedCounty);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void RegionIsInvalid()
	    {
		    importedCounty.IdRegion = null;
		    var result = validator.Validate(importedCounty);
		    Assert.False(result.IsValid);
	    }
    }
}
