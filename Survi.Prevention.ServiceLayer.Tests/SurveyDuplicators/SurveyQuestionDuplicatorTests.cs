using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Xunit;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;
using Survi.Prevention.ServiceLayer.Tests.Mocks;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
	public class SurveyQuestionDuplicatorTests
	{
		private readonly SurveyQuestionDuplicator duplicatorService = new SurveyQuestionDuplicator();
		private readonly SurveyQuestionLocalization originalLocalization;
		private readonly List<SurveyQuestionLocalization> originalLocalizations;
		private readonly SurveyQuestion originalSurveyQuestion;
		private readonly List<SurveyQuestion> originalSurveyQuestions;
		private readonly Guid idWebUserLastModifiedBy;

		public SurveyQuestionDuplicatorTests()
		{
			
			originalLocalization = new SurveyQuestionLocalization
			{
				Name = "Question name",
				LanguageCode = "en",
				Title = "Question title"
			};
			originalLocalizations = new List<SurveyQuestionLocalization>
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
				Localizations = originalLocalizations
			};

			originalSurveyQuestions = new List<SurveyQuestion>
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
					IdSurveyQuestionParent = Guid.NewGuid(),
					Localizations = originalLocalizations
				}
			};

			idWebUserLastModifiedBy = Guid.NewGuid();
		}

		[Fact]
		public void NewIdSurveyLocalizationHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyQuestionLocalization(originalLocalization, newId, idWebUserLastModifiedBy);

			Assert.True(newId == copy.IdParent);
		}

		[Fact]
		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyQuestionLocalization(originalLocalization, Guid.NewGuid(), idWebUserLastModifiedBy);

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyQuestionLocalization original, SurveyQuestionLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode && copy.Title == original.Title;
		}

		[Fact]
		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionLocalizations(originalLocalizations, Guid.NewGuid(), idWebUserLastModifiedBy);
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}

		[Fact]
		public void SurveyQuestionFieldsAreCorrectlyDuplicated()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionFields(originalSurveyQuestion, Guid.NewGuid(), idWebUserLastModifiedBy);
			Assert.True(SurveyQuestionHasBeenCorrectlyDuplicated(originalSurveyQuestion, copy));
		}

		private bool SurveyQuestionHasBeenCorrectlyDuplicated(SurveyQuestion originalQuestion, SurveyQuestion copy)
		{
			return originalQuestion.IsRecursive == copy.IsRecursive && originalQuestion.MaxOccurrence == copy.MaxOccurrence &&
			       originalQuestion.MinOccurrence == copy.MinOccurrence && originalQuestion.Sequence == copy.Sequence &&
			       originalQuestion.IdSurveyQuestionNext == copy.IdSurveyQuestionNext && 
			       originalQuestion.IdSurveyQuestionParent == copy.IdSurveyQuestionParent;
		}

		[Fact]
		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyQuestion(originalSurveyQuestion, newId, idWebUserLastModifiedBy);

			Assert.True(newId == copy.IdSurvey);
		}

		[Fact]
		public void QuestionsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestions(originalSurveyQuestions, Guid.NewGuid(), idWebUserLastModifiedBy);
			Assert.Equal(originalSurveyQuestions.Count, copy.Count);
		}

		[Fact]
		public void IdParentIsCorrectlyUpdated()
		{
			var newIdSurveyQuestionParent = Guid.NewGuid();
			originalSurveyQuestion.IdSurveyQuestionParent = Guid.NewGuid();
			var dictionary = new List<SurveyQuestionIdsConnector> { new SurveyQuestionIdsConnector{ NewId = newIdSurveyQuestionParent, OriginalId = originalSurveyQuestion.IdSurveyQuestionParent.Value} };
			new SurveyQuestionDuplicatorMock().UpdateQuestionIdParent(dictionary, originalSurveyQuestion);
			
			Assert.Equal(originalSurveyQuestion.IdSurveyQuestionParent, newIdSurveyQuestionParent);
		}
		 
		[Fact]
		public void IdParentIsNotUpdatedWhenNull()
		{
			var dictionary = new List<SurveyQuestionIdsConnector>();
			originalSurveyQuestion.IdSurveyQuestionParent = null;
			new SurveyQuestionDuplicatorMock().UpdateQuestionIdParent(dictionary, originalSurveyQuestion);
			
			Assert.Null(originalSurveyQuestion.IdSurveyQuestionParent);
		}
	}
}
