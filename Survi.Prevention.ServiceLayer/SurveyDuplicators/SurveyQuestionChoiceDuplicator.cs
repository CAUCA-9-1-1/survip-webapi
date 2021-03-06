﻿using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicators
{
    public class SurveyQuestionChoiceDuplicator
    {
		public List<SurveyQuestionChoice> DuplicateSurveyQuestionChoices(ICollection<SurveyQuestionChoice> questionChoicesToCopy, Guid newIdSurveyQuestion)
		{
			List<SurveyQuestionChoice> newSurveyQuestionChoices = new List<SurveyQuestionChoice>();

			questionChoicesToCopy?.Where(qc=>qc.IsActive).ToList().ForEach(choice => newSurveyQuestionChoices.Add(DuplicateSurveyQuestionChoice(choice, newIdSurveyQuestion)));

			return newSurveyQuestionChoices;
		}

		public SurveyQuestionChoice DuplicateSurveyQuestionChoice(SurveyQuestionChoice questionChoiceToCopy, Guid newIdSurveyQuestion)
		{
			SurveyQuestionChoice newSurveyQuestionChoice = DuplicateSurveyQuestionChoiceFields(questionChoiceToCopy, newIdSurveyQuestion);
			newSurveyQuestionChoice.Localizations = DuplicateSurveyQuestionChoiceLocalizations(questionChoiceToCopy.Localizations, newSurveyQuestionChoice.Id);
			return newSurveyQuestionChoice;
		}

		public SurveyQuestionChoice DuplicateSurveyQuestionChoiceFields(SurveyQuestionChoice questionChoiceToCopy, Guid newIdSurveyQuestion)
		{
			return new SurveyQuestionChoice { IdSurveyQuestion = newIdSurveyQuestion, IdSurveyQuestionNext = questionChoiceToCopy.IdSurveyQuestionNext, Sequence = questionChoiceToCopy.Sequence};
		}

		public List<SurveyQuestionChoiceLocalization> DuplicateSurveyQuestionChoiceLocalizations(ICollection<SurveyQuestionChoiceLocalization> localizationsToCopy, Guid newIdSurveyQuestionChoice)
		{
			List<SurveyQuestionChoiceLocalization> newQuestionChoiceLocalizations = new List<SurveyQuestionChoiceLocalization>();
			localizationsToCopy.Where(loc=>loc.IsActive).ToList()
			    .ForEach(choiceLocalization => newQuestionChoiceLocalizations
			        .Add(DuplicateSurveyQuestionChoiceLocalization(choiceLocalization, newIdSurveyQuestionChoice)));
			return newQuestionChoiceLocalizations;
		}

		public SurveyQuestionChoiceLocalization DuplicateSurveyQuestionChoiceLocalization(SurveyQuestionChoiceLocalization localizationsToCopy, Guid newIdSurveyQuestionChoice)
		{
			return new SurveyQuestionChoiceLocalization { LanguageCode = localizationsToCopy.LanguageCode, Name = localizationsToCopy.Name, IdParent = newIdSurveyQuestionChoice};
		}
    }
}
