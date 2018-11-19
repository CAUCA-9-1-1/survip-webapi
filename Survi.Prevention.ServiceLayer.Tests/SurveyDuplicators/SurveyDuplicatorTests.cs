using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Xunit;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
    public class SurveyDuplicatorTests
    {
		private readonly SurveyDuplicator duplicatorService = new SurveyDuplicator();
		private readonly SurveyLocalization originalLocalization;
		private readonly List<SurveyLocalization> originalLocalizations; 
		private readonly Survey originalSurvey;
	
		public SurveyDuplicatorTests()
		{
			originalSurvey = new Survey{Id = Guid.NewGuid(), SurveyType = 1};
			originalLocalization = new SurveyLocalization
			{
				Name = "Test",
				LanguageCode = "en"
			};
			originalLocalizations = new List<SurveyLocalization>()
			{
				originalLocalization, new SurveyLocalization{ Name = "Test", LanguageCode = "en"}
			};
		}
		[Fact]
		public void SurveyFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyFields(originalSurvey);

			Assert.True(originalSurvey.SurveyType == copy.SurveyType);
		}

		[Fact]
		private void BaseInformationHasBeenCorrectlySet()
		{
			var copy = duplicatorService.DuplicateSurveyFields(originalSurvey);
			Assert.True(originalSurvey.Id != copy.Id && originalSurvey.CreatedOn != copy.CreatedOn);
		}
		[Fact]
		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyLocalization(originalLocalization, newId);

			Assert.True(newId == copy.IdParent);
		}

		[Fact]
		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyLocalization(originalLocalization, Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyLocalization localizationToCopy, SurveyLocalization copy)
		{
			return copy.Name != localizationToCopy.Name && copy.LanguageCode == localizationToCopy.LanguageCode;
		}

		[Fact]
		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyLocalizations(originalLocalizations, Guid.NewGuid());
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}
	}
}
