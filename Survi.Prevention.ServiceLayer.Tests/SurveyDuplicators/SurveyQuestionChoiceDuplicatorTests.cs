using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
    public class SurveyQuestionChoiceDuplicatorTests
    {
		private SurveyQuestionChoiceDuplicator duplicatorService = new SurveyQuestionChoiceDuplicator();
		private SurveyQuestionChoiceLocalization originalLocalization;
		private List<SurveyQuestionChoiceLocalization> originalLocalizations;
		private SurveyQuestionChoice originalSurveyQuestionChoice;
		private List<SurveyQuestionChoice> originalSurveyQuestionChoices;

		public void Setup()
		{
			originalLocalization = new SurveyQuestionChoiceLocalization
			{
				Name = "Choice name",
				LanguageCode = "en"
			};
			originalLocalizations = new List<SurveyQuestionChoiceLocalization>()
			{
				originalLocalization, new SurveyQuestionChoiceLocalization{ Name = "Nom du choix", LanguageCode = "fr"}
			};

			originalSurveyQuestionChoice = new SurveyQuestionChoice
			{
				IdSurveyQuestion = Guid.NewGuid(),
				Sequence = 1,
				IdSurveyQuestionNext = Guid.NewGuid(),
				Localizations = originalLocalizations
			};

			originalSurveyQuestionChoices = new List<SurveyQuestionChoice>()
			{
				originalSurveyQuestionChoice,
				new SurveyQuestionChoice { IdSurveyQuestion = Guid.NewGuid(), Sequence = 2 }
			};
		}

		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalization(originalLocalization, newId);

			Assert.True(newId == copy.IdParent);
		}

		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalization(originalLocalization, Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyQuestionChoiceLocalization original, SurveyQuestionChoiceLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
		}

		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalizations(originalLocalizations, Guid.NewGuid());
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}

		public void SurveyQuestionChoiceFieldsAreCorrectlyDuplicated()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoice(originalSurveyQuestionChoice, Guid.NewGuid());
			Assert.True(SurveyQuestionHasBeenCorrectlyDuplicated(originalSurveyQuestionChoice, copy));
		}

		private bool SurveyQuestionHasBeenCorrectlyDuplicated(SurveyQuestionChoice originalSurveyQuestionChoice, SurveyQuestionChoice copy)
		{
			return originalSurveyQuestionChoice.IdSurveyQuestion == copy.IdSurveyQuestion && originalSurveyQuestionChoice.Sequence == copy.Sequence &&
				   originalSurveyQuestionChoice.IdSurveyQuestionNext == copy.IdSurveyQuestionNext;
		}

		public void ChoicesAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoices(originalSurveyQuestionChoices, Guid.NewGuid());
			Assert.Equal(originalSurveyQuestionChoices.Count, copy.Count);
		}
    }
}
