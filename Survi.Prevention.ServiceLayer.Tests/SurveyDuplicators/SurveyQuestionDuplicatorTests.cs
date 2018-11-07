using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Xunit;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
	public class SurveyQuestionDuplicatorTests
	{
		private SurveyQuestionDuplicator duplicatorService = new SurveyQuestionDuplicator();
		private SurveyQuestionLocalization originalLocalization;
		private List<SurveyQuestionLocalization> originalLocalizations;
		private SurveyQuestion originalSurveyQuestion;
		private List<SurveyQuestion> originalSurveyQuestions;

		public void Setup()
		{
			
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

			originalSurveyQuestion = new SurveyQuestion
			{
				IsRecursive = false,
				MaxOccurrence = 5,
				MinOccurrence = 1,
				Sequence = 1,
				QuestionType = 4,
				IdSurveyQuestionNext = Guid.NewGuid(),
				IdSurveyQuestionParent = Guid.NewGuid(),
				Localizations = originalLocalizations,
				Choices = new List<SurveyQuestionChoice>
				{ 
					new SurveyQuestionChoice{ Id= Guid.NewGuid(), Sequence=1, IdSurveyQuestion = originalSurveyQuestion.Id},
					new SurveyQuestionChoice{ Id= Guid.NewGuid(), Sequence=2, IdSurveyQuestion = originalSurveyQuestion.Id}
				}
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

		public void SurveyQuestionFieldsAreCorrectlyDuplicated()
		{
			var copy = duplicatorService.DuplicateSurveyQuestion(originalSurveyQuestion, Guid.NewGuid());
			Assert.True(SurveyQuestionHasBeenCorrectlyDuplicated(originalSurveyQuestion, copy));
		}

		private bool SurveyQuestionHasBeenCorrectlyDuplicated(SurveyQuestion originalSurveyQuestion, SurveyQuestion copy)
		{
			return originalSurveyQuestion.IsRecursive == copy.IsRecursive && originalSurveyQuestion.MaxOccurrence == copy.MaxOccurrence &&
				   originalSurveyQuestion.MinOccurrence == copy.MinOccurrence && originalSurveyQuestion.Sequence == copy.Sequence &&
				   originalSurveyQuestion.IdSurveyQuestionNext == copy.IdSurveyQuestionNext && 
				   originalSurveyQuestion.IdSurveyQuestionParent == copy.IdSurveyQuestionParent;
		}

		public void QuestionsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestions(originalSurveyQuestions, Guid.NewGuid());
			Assert.Equal(originalSurveyQuestions.Count, copy.Count);
		}
	}
}
