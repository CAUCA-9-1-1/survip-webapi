﻿using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using Survi.Prevention.ServiceLayer.SurveyDuplicators;
using Xunit;

namespace Survi.Prevention.ServiceLayer.Tests.SurveyDuplicators
{
    public class SurveyQuestionChoiceDuplicatorTests
    {
		private readonly SurveyQuestionChoiceDuplicator duplicatorService = new SurveyQuestionChoiceDuplicator();
		private readonly SurveyQuestionChoiceLocalization originalLocalization;
		private readonly List<SurveyQuestionChoiceLocalization> originalLocalizations;
		private readonly SurveyQuestionChoice originalSurveyQuestionChoice;
		private readonly List<SurveyQuestionChoice> originalSurveyQuestionChoices;

		public SurveyQuestionChoiceDuplicatorTests()
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
				new SurveyQuestionChoice { IdSurveyQuestion = Guid.NewGuid(), Sequence = 2, Localizations = originalLocalizations}
			};
		}

		[Fact]
		public void NewIdSurveyHasBeenCorrectlySet()
		{			
			var newId = Guid.NewGuid();
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalization(originalLocalization, newId);

			Assert.True(newId == copy.IdParent);
		}

		[Fact]
		public void LocalizationFieldsAreCorrectlyCopied()
		{			
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalization(originalLocalization, Guid.NewGuid());

			Assert.True(LocalizationHasBeenCorrectlyDuplicated(originalLocalization, copy));
		}

		private static bool LocalizationHasBeenCorrectlyDuplicated(SurveyQuestionChoiceLocalization original, SurveyQuestionChoiceLocalization copy)
		{
			return copy.Name == original.Name && copy.LanguageCode == original.LanguageCode;
		}

		[Fact]
		public void LocalizationsAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceLocalizations(originalLocalizations, Guid.NewGuid());
			Assert.Equal(originalLocalizations.Count, copy.Count);
		}

		[Fact]
		public void SurveyQuestionChoiceFieldsAreCorrectlyDuplicated()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoiceFields(originalSurveyQuestionChoice, Guid.NewGuid());
			Assert.True(SurveyQuestionHasBeenCorrectlyDuplicated(originalSurveyQuestionChoice, copy));
		}

		private bool SurveyQuestionHasBeenCorrectlyDuplicated(SurveyQuestionChoice originalChoice, SurveyQuestionChoice copy)
		{
			return originalChoice.Sequence == copy.Sequence && originalChoice.IdSurveyQuestionNext == copy.IdSurveyQuestionNext;
		}

	    [Fact]
	    public void NewIdSurveyQuestionHasBeenCorrectlySet()
	    {
		    var newIdSurveyQuestion = Guid.NewGuid();
		    var copy = duplicatorService.DuplicateSurveyQuestionChoiceFields(originalSurveyQuestionChoice, newIdSurveyQuestion);
		    Assert.True(newIdSurveyQuestion == copy.IdSurveyQuestion);
	    }

		[Fact]
		public void ChoicesAreComplete()
		{
			var copy = duplicatorService.DuplicateSurveyQuestionChoices(originalSurveyQuestionChoices, Guid.NewGuid());
			Assert.Equal(originalSurveyQuestionChoices.Count, copy.Count);
		}
    }
}
