using System.Collections.Generic;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Places;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Places
{
    public class RegionImportValidatorTests
    {
		private readonly Region importedRegion;
	    private readonly RegionValidator validator;

	    public RegionImportValidatorTests()
	    {
		    importedRegion = new Region
		    {
			    Id = "region1",
				IdState = "existing state",
			    Code = "RegionDePhil",
			    IsActive = true,
			    Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
			    {
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "Region 1", LanguageCode = "en"},
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "Région 1", LanguageCode = "fr"}
			    }
		    };
		    validator = new RegionValidator();
	    }

	    [Fact]
	    public void RegionIsInvalid()
	    {
		    importedRegion.IdState = null;
		    var result = validator.Validate(importedRegion);
		    Assert.False(result.IsValid);
	    }
    }
}
