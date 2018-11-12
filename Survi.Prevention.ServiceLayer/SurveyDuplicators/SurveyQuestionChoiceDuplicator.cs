using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicators
{
    public class SurveyQuestionChoiceDuplicator
    {
		public List<SurveyQuestionChoice> DuplicateSurveyQuestionChoices(ICollection<SurveyQuestionChoice> questionChoicesToCopy, Guid newIdSurveyQuestion, Guid idWebUserLastModifiedBy)
		{
			List<SurveyQuestionChoice> newSurveyQuestionChoices = new List<SurveyQuestionChoice>();

			questionChoicesToCopy?.Where(qc=>qc.IsActive).ToList().ForEach(choice => newSurveyQuestionChoices.Add(DuplicateSurveyQuestionChoice(choice, newIdSurveyQuestion, idWebUserLastModifiedBy)));

			return newSurveyQuestionChoices;
		}

		public SurveyQuestionChoice DuplicateSurveyQuestionChoice(SurveyQuestionChoice questionChoiceToCopy, Guid newIdSurveyQuestion, Guid idWebUserLastModifiedBy)
		{
			SurveyQuestionChoice newSurveyQuestionChoice = DuplicateSurveyQuestionChoiceFields(questionChoiceToCopy, newIdSurveyQuestion, idWebUserLastModifiedBy);
			newSurveyQuestionChoice.Localizations = DuplicateSurveyQuestionChoiceLocalizations(questionChoiceToCopy.Localizations, newSurveyQuestionChoice.Id, idWebUserLastModifiedBy);
			return newSurveyQuestionChoice;
		}

		public SurveyQuestionChoice DuplicateSurveyQuestionChoiceFields(SurveyQuestionChoice questionChoiceToCopy, Guid newIdSurveyQuestion, Guid idWebUserLastModifiedBy)
		{
			return new SurveyQuestionChoice { IdSurveyQuestion = newIdSurveyQuestion, IdSurveyQuestionNext = questionChoiceToCopy.IdSurveyQuestionNext, Sequence = questionChoiceToCopy.Sequence, IdWebUserLastModifiedBy = idWebUserLastModifiedBy};
		}

		public List<SurveyQuestionChoiceLocalization> DuplicateSurveyQuestionChoiceLocalizations(ICollection<SurveyQuestionChoiceLocalization> localizationsToCopy, Guid newIdSurveyQuestionChoice, Guid idWebUserLastModifiedBy)
		{
			List<SurveyQuestionChoiceLocalization> newQuestionChoiceLocalizations = new List<SurveyQuestionChoiceLocalization>();
			localizationsToCopy.Where(loc=>loc.IsActive).ToList().ForEach(choiceLocalization => newQuestionChoiceLocalizations.Add(DuplicateSurveyQuestionChoiceLocalization(choiceLocalization, newIdSurveyQuestionChoice, idWebUserLastModifiedBy)));
			return newQuestionChoiceLocalizations;
		}

		public SurveyQuestionChoiceLocalization DuplicateSurveyQuestionChoiceLocalization(SurveyQuestionChoiceLocalization localizationsToCopy, Guid newIdSurveyQuestionChoice, Guid idWebUserLastModifiedBy)
		{
			return new SurveyQuestionChoiceLocalization { LanguageCode = localizationsToCopy.LanguageCode, Name = localizationsToCopy.Name, IdParent = newIdSurveyQuestionChoice, IdWebUserLastModifiedBy = idWebUserLastModifiedBy};
		}
    }
}
