using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ServiceLayer.Import.Country;
using Xunit;
using countryImported = Survi.Prevention.ApiClient.DataTransferObjects;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class CountryImportValidatorTests
    {
	    private readonly countryImported.Country importedCountry;
	    private readonly CountryValidator validator;

	    public CountryImportValidatorTests()
	    {
			validator = new CountryValidator();
		    importedCountry = new countryImported.Country
		    {
			    Id = "country1",
			    CodeAlpha2 = "CO",
			    CodeAlpha3 = "CO3",
			    IsActive = true,
			    Localizations = new List<countryImported.Base.Localization>
			    {
				    new countryImported.Base.Localization{Name = "Country 1", LanguageCode = "en"},
				    new countryImported.Base.Localization{Name = "Pays 1", LanguageCode = "fr"}
			    }
		    };
	    }

	    [Fact]
	    public void CountryIsValid()
	    {
		    var result = validator.Validate(importedCountry);
		    Assert.True(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustBeNotNull()
	    {
		    importedCountry.Localizations = null;
		    var result = validator.Validate(importedCountry);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectLanguageCode()
	    {
		    var locFrench = importedCountry.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.LanguageCode = "";
		    var result = validator.Validate(importedCountry);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectName()
	    {
		    var locFrench = importedCountry.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.Name = "";
		    var result = validator.Validate(importedCountry);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void CountryMustContainsValidCodeAlpha2()
	    {
		    importedCountry.CodeAlpha2 = "test";
		    var result = validator.Validate(importedCountry);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void CountryMustContainsValidCodeAlpha3()
	    {
		    importedCountry.CodeAlpha3 = "test";
		    var result = validator.Validate(importedCountry);
		    Assert.False(result.IsValid);
	    }

		[Fact]
		public void CountryMustContainsRequiredLanguages()
		{
			importedCountry.Localizations = new List<countryImported.Base.Localization>{new countryImported.Base.Localization{Name = "Country 1", LanguageCode = "en"}};
			var result = validator.Validate(importedCountry);
			Assert.False(result.IsValid);
		}
    }
}
