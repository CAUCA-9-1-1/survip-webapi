using Survi.Prevention.ApiClient.DataTransferObjects;
using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.Import.Country;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class StateImportValidatorTests
    {
		private readonly State importedState;
	    private readonly StateValidator validator;

	    public StateImportValidatorTests()
	    {		    		    
			validator = new StateValidator();
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
	    public void CountryMustContainsValidCodeAnsi()
	    {
		    importedState.AnsiCode = "CA1";
		    var result = validator.Validate(importedState);
		    Assert.False(result.IsValid);
	    }
    }
}