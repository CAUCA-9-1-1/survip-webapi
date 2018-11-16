using System;
using System.Collections.Generic;
using System.Linq;
using Survi.Prevention.Models.FireSafetyDepartments;
using stateImported = Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Import.Country;
using Survi.Prevention.ServiceLayer.Tests.Mocks;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.Import.Country
{
	public class StateImportTests
	{
		private readonly stateImported.State importedState;
		private State existingState;
		private readonly StateModelConnector service;

		public StateImportTests()
		{
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

			existingState = new State
			{
				Id = Guid.NewGuid(),
				AnsiCode = "CO",
				IdCountry = Guid.NewGuid(),
				IsActive = true,
			};
			existingState.Localizations = new List<StateLocalization>
			{
				new StateLocalization
					{Id = Guid.NewGuid(), Name = "State 1", LanguageCode = "en", IdParent = existingState.Id},
				new StateLocalization
					{Id = Guid.NewGuid(), Name = "Province 1", LanguageCode = "fr", IdParent = existingState.Id}
			};

			var countries = new List<Models.FireSafetyDepartments.Country>();
			var ctx = new BaseContextMock();
			ctx.Setup(context => context.Countries).Returns(ctx.GetMockDbSet(countries).Object);

			service = new StateModelConnector(ctx.Object);
		}

		[Fact]
		public void NewIdLocalizationHasBeenCorrectlySet()
		{
			var newId = Guid.NewGuid();
			var copy = service.CreateLocalization(importedState.Localizations.First(), newId);

			Assert.True(newId == copy.IdParent);
		}

		[Fact]
		public void ExistingIdLocalizationHasBeenCorrectlySet()
		{
			var copy = service.ImportLocalization(importedState.Localizations.First(), existingState);

			Assert.True(existingState.Id == copy.IdParent);
		}

		[Fact]
		public void LocalizationFieldsAreCorrectlyCopied()
		{
			var copy = service.CreateLocalization(importedState.Localizations.First(), Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(importedState.Localizations.First(), copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(stateImported.Base.Localization original, StateLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
		}

		[Fact]
		public void LocalizationsAreComplete()
		{
			existingState = new State();
			var copy = service.TransferLocalizationsFromImported(importedState.Localizations.ToList(), existingState);
			Assert.Equal(importedState.Localizations.Count, copy.Count);
		}

		[Fact]
		public void EntityFieldsHasBeenCorrectlySet()
		{
			existingState = new State();
			var copy = service.TransferDtoImportedToOriginal(importedState, existingState);

			Assert.True(importedState.Id == copy.IdExtern && importedState.AnsiCode == copy.AnsiCode);
		}

		[Fact]
		public void EntityHasBeenCorrectlyValidated()
		{
			importedState.AnsiCode = "test 4";
			var validationResult = service.GetValidationResult(importedState);

			Assert.False(validationResult.IsValid);
		}

		[Fact]
		public void StateCountryDoesNotExists()
		{
			var validationResult = service.ValidateExternalCountry(importedState.IdCountry);

			Assert.False(validationResult.HasBeenImported);
		}
	}
}
