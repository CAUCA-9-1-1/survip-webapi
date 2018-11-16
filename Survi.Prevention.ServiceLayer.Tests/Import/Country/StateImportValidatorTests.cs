using Survi.Prevention.ApiClient.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.ServiceLayer.Import.Country;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class StateImportValidatorTests
    {
		private readonly State importedState;
	    private readonly StateValidator validator;

	    public StateImportValidatorTests()
	    {
		    var states = new List<Models.FireSafetyDepartments.State>();
		    var ctx = new BaseContextMock();
		    ctx.Setup(context => context.States).Returns(ctx.GetMockDbSet(states).Object);

			validator = new StateValidator(ctx.Object);
		    importedState = new State
		    {
			    Id = "country1",
				IdCountry = "existing country",
			    AnsiCode = "CO",
			    IsActive = true,
			    Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>
			    {
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "Country 1", LanguageCode = "en"},
				    new ApiClient.DataTransferObjects.Base.Localization{Name = "Pays 1", LanguageCode = "fr"}
			    }
		    };
	    }

	    [Fact]
	    public void CountryIsInvalid()
	    {
		    importedState.IdCountry = null;
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustBeNotNull()
	    {
		    importedState.Localizations = null;
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectLanguageCode()
	    {
		    var locFrench = importedState.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.LanguageCode = "";
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void LocalizationsMustContainsCorrectName()
	    {
		    var locFrench = importedState.Localizations.SingleOrDefault(loc =>loc.LanguageCode == "fr");
		    if (locFrench != null) locFrench.Name = "";
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }

	    [Fact]
	    public void CountryMustContainsValidCodeAnsi()
	    {
		    importedState.AnsiCode = "CA1";
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }

		[Fact]
		public void CountryMustContainsRequiredLanguages()
		{
			importedState.Localizations = new List<ApiClient.DataTransferObjects.Base.Localization>{new ApiClient.DataTransferObjects.Base.Localization{Name = "Country 1", LanguageCode = "en"}};
			var result = validator.Validate(importedState);
			Assert.False(result.IsValid);
		}
    }
}
