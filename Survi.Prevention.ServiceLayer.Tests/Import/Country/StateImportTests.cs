using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireSafetyDepartments;
using stateImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Country;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
    public class StateImportTests
    {

	internal static Mock<DbSet<T>> GetMockDbSet<T>(ICollection<T> entities) where T : class
	{
	var mockSet = new Mock<DbSet<T>>();
	mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
	mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
	mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
	mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
	mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(entities.Add);
	return mockSet;
	}

		private readonly stateImported.State importedState;
	    private readonly StateModelConnector service;

	    public StateImportTests()
	    {
		    var countries = new List<Models.FireSafetyDepartments.Country>();
		    var ctx = new Mock<IManagementContext>();
			ctx.Setup(context => context.Countries).Returns(GetMockDbSet(countries).Object);

			service = new StateModelConnector(ctx.Object);

		    importedState = new stateImported.State
			{
				Id = "state1",
				AnsiCode = "CO",
				IdCountry = "CO3",
				IsActive = true,
				Localizations = new List<stateImported.Base.Localization>
				{
					new stateImported.Base.Localization{Name = "State 1", LanguageCode = "en"},
					new stateImported.Base.Localization{Name = "Province 1", LanguageCode = "fr"}
				}
			};
	    }

	    [Fact]
	    public void NewIdLocalizationHasBeenCorrectlySet()
	    {			
		    var newId = Guid.NewGuid();
		    var copy = service.ImportLocalization(importedState.Localizations.First(), newId);

		    Assert.True(newId == copy.IdParent);
	    }

	    [Fact]
	    public void LocalizationFieldsAreCorrectlyCopied()
	    {			
		    var copy = service.ImportLocalization(importedState.Localizations.First(), Guid.NewGuid());

		    Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedState.Localizations.First(), copy));
	    }

	    private static bool LocalizationHasBeenCorrectlyDuplicated(stateImported.Base.Localization original, StateLocalization copy)
	    {
		    return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
	    }

	    [Fact]
	    public void LocalizationsAreComplete()
	    {
		    var copy = service.TransferLocalizationFromImported(importedState.Localizations.ToList(), Guid.NewGuid());
		    Assert.Equal(importedState.Localizations.Count, copy.Count);
	    }


	    [Fact]
	    public void CountryFieldsHasBeenCorrectlySet()
	    {			
		    var copy = service.TransferDtoImportedToOriginal(importedState);

		    Assert.True(importedState.Id == copy.IdExtern && importedState.AnsiCode == copy.AnsiCode);
	    }
    }
}
