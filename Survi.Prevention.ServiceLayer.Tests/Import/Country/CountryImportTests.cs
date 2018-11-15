using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Country;
using countryImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class CountryImportTests
    {
	    private readonly countryImported.Country importedCountry;
	    private readonly CountryModelConnector service = new CountryModelConnector();

	    public CountryImportTests()
	    {
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
	    public void NewIdLocalizationHasBeenCorrectlySet()
	    {			
		    var newId = Guid.NewGuid();
		    var copy = service.ImportLocalization(importedCountry.Localizations.First(), newId);

		    Assert.True(newId == copy.IdParent);
	    }

	    [Fact]
	    public void LocalizationFieldsAreCorrectlyCopied()
	    {			
		    var copy = service.ImportLocalization(importedCountry.Localizations.First(), Guid.NewGuid());

		    Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedCountry.Localizations.First(), copy));
	    }

	    private static bool LocalizationHasBeenCorrectlyDuplicated(countryImported.Base.Localization original, CountryLocalization copy)
	    {
		    return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
	    }

	    [Fact]
	    public void LocalizationsAreComplete()
	    {
		    var copy = service.TransferLocalizationFromImported(importedCountry.Localizations.ToList(), Guid.NewGuid());
		    Assert.Equal(importedCountry.Localizations.Count, copy.Count);
	    }


	    [Fact]
	    public void CountryFieldsHasBeenCorrectlySet()
	    {			
		    var copy = service.TransferDtoImportedToOriginal(importedCountry);

		    Assert.True(importedCountry.Id == copy.IdExtern && 
		                importedCountry.CodeAlpha2 == copy.CodeAlpha2 && 
		                importedCountry.CodeAlpha3 == copy.CodeAlpha3);
	    }
    }
}
