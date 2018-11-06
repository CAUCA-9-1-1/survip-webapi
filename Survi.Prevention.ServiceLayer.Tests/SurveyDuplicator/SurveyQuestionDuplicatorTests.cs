using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicator
{
	public class SurveyQuestionDuplicatorTests
	{
		private ServiceLayer.SurveyDuplicator.SurveyQuestionDuplicator duplicatorService = new ServiceLayer.SurveyDuplicator.SurveyQuestionDuplicator();
		private SurveyQuestionLocalization originalLocalization;
		private List<SurveyQuestionLocalization> originalLocalizations;
		private SurveyQuestion originalSurveyQuestion;
		private List<SurveyQuestion> originalSurveyQuestions;

		public void Setup()
		{
			originalSurveyQuestion = new SurveyQuestion
			{
				IsRecursive = false,
				MaxOccurrence = 5,
				MinOccurrence = 1,
				Sequence = 1,
				QuestionType = 4,
				IdSurveyQuestionNext = Guid.NewGuid(),
				IdSurveyQuestionParent = Guid.NewGuid()
			};
			originalLocalization = new SurveyQuestionLocalization
			{
				Name = "Question name",
				LanguageCode = "en",
				Title = "Question title"
			};
			originalLocalizations = new List<SurveyQuestionLocalization>()
			{
				originalLocalization, new SurveyQuestionLocalization{ Name = "Nom de question", LanguageCode = "fr", Title = "Titre de la question"}
			};

			originalSurveyQuestions = new List<SurveyQuestion>()
			{
				originalSurveyQuestion,
				new SurveyQuestion
				{
					IsRecursive = false,
					MaxOccurrence = 5,
					MinOccurrence = 1,
					Sequence = 1,
					QuestionType = 4,
					IdSurveyQuestionNext = Guid.NewGuid(),
					IdSurveyQuestionParent = Guid.NewGuid()
				}
			};
		}

		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyQuestionLocalization(originalLocalization, newId);

			Assert.True(newId == copy.IdParent);
		}

		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyQuestionLocalization(originalLocalization, Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyQuestionLocalization original, SurveyQuestionLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode && copy.Title == original.Title;
		}

		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionLocalizations(originalLocalizations, Guid.NewGuid());
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}
	}
}
