using System.Collections.Generic;
using System.Linq;
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

	    [Fact]
	    public void LocalizationsMustBeNotNull()
	    {
		    importedRegion.Localizations = null;
		    var result = validator.Validate(importedRegion);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectLanguageCode()
	    {
		    var locFrench = importedRegion.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.LanguageCode = "";
		    var result = validator.Validate(importedRegion);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectName()
	    {
		    var locFrench = importedRegion.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.Name = "";
		    var result = validator.Validate(importedRegion);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void CountryMustContainsValidCode()
	    {
		    importedRegion.Code = "CA1 avec plus de 10 caractères";
		    var result = validator.Validate(importedRegion);
		    Assert.False(result.IsValid);
	    }

		[Fact]
		public void RegionMustContainsRequiredLanguages()
		{
			importedRegion.Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>{new ApiClient.DataTransferObjects.Base.Localization{Name = "Region 1", LanguageCode = "en"}};
			var result = validator.Validate(importedRegion);
			Assert.False(result.IsValid);
		}
    }
}
