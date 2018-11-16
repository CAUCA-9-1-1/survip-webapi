using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Import.Country;
using countryImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class CountryImportTests
    {
	    private readonly countryImported.Country importedCountry;
	    private readonly Models.FireSafetyDepartments.Country existingCountry;
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

		    existingCountry = new Models.FireSafetyDepartments.Country
		    {
			    Id = Guid.NewGuid(),
			    CodeAlpha2 = "CO",
			    CodeAlpha3 = "CO3",
			    IsActive = true
			    
		    };
		    existingCountry.Localizations = new List<CountryLocalization>
		    {
			    new CountryLocalization
				    {Id = Guid.NewGuid(), LanguageCode = "en", Name = "existing Name", IdParent = existingCountry.Id},
			    new CountryLocalization
				    {Id = Guid.NewGuid(), LanguageCode = "fr", Name = "existing Name", IdParent = existingCountry.Id}
		    };
	    }

	    [Fact]
	    public void NewIdLocalizationHasBeenCorrectlySet()
	    {
		    var Id = Guid.NewGuid();
			    
		    var copy = service.CreateLocalization(importedCountry.Localizations.First(), Id);

		    Assert.True(Id == copy.IdParent);
	    }

	    [Fact]
	    public void ExistingIdLocalizationHasBeenCorrectlySet()
	    {
		    var copy = service.ImportLocalization(importedCountry.Localizations.First(), existingCountry);

		    Assert.True(existingCountry.Id == copy.IdParent);
	    }

	    [Fact]
	    public void LocalizationFieldsAreCorrectlyCopied()
	    {			
		    var copy = service.CreateLocalization(importedCountry.Localizations.First(), Guid.NewGuid());

		    Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedCountry.Localizations.First(), copy));
	    }

	    private static bool LocalizationHasBeenCorrectlyDuplicated(countryImported.Base.Localization original, CountryLocalization copy)
	    {
		    return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
	    }

	    [Fact]
	    public void LocalizationsAreComplete()
	    {
		    var newCountry = new Models.FireSafetyDepartments.Country();
		    var copy = service.TransferLocalizationsFromImported(importedCountry.Localizations.ToList(), newCountry);
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

	    [Fact]
	    public void CountryHasBeenCorrectlyValidated()
	    {
		    importedCountry.CodeAlpha3 = "test 4";
		    var validationResult = service.GetValidationResult(importedCountry);

		    Assert.False(validationResult.IsValid);
	    }

	    [Fact]
	    public void CountryValidationMessageHasBeenCorrectlySet()
	    {
		    var validationResult = service.ValidateCountry(importedCountry);

		    Assert.True(validationResult.HasBeenImported);
	    }
    }
}
