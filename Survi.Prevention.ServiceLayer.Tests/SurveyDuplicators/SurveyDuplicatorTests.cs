using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Xunit;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
    public class SurveyDuplicatorTests
    {
		private SurveyDuplicator duplicatorService = new SurveyDuplicator();
		private SurveyLocalization originalLocalization;
		private List<SurveyLocalization> originalLocalizations; 
		private Survey originalSurvey;


		public void Setup()
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

		public void SurveyFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyFields(originalSurvey);

			Assert.True(originalSurvey.SurveyType == copy.SurveyType);
		}

		private void BaseInformationHasBeenCorrectlySet(Survey originalSurvey, Survey copy)
		{
			Assert.True(originalSurvey.Id != copy.Id && originalSurvey.CreatedOn != copy.CreatedOn);
		}

		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyLocalization(originalLocalization, newId);

			Assert.True(newId == copy.IdParent);
		}

		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyLocalization(originalLocalization, Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyLocalization localizationToCopy, SurveyLocalization copy)
		{
			return copy.Name != localizationToCopy.Name && copy.LanguageCode == localizationToCopy.LanguageCode;
		}

		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyLocalizations(originalLocalizations, Guid.NewGuid());
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}
	}
}
