using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicators
{
    public class SurveyQuestionDuplicator
    {
		protected List<SurveyQuestionIdsConnector> SurveyQuestionConnectorList = new List<SurveyQuestionIdsConnector>();

		public List<SurveyQuestion> DuplicateSurveyQuestions(ICollection<SurveyQuestion> questionsToCopy, Guid newIdSurvey, Guid idWebUserLastModifiedByy)
		{
			List<SurveyQuestion> newSurveyQuestions = new List<SurveyQuestion>();
			questionsToCopy.Where(q=>q.IsActive).ToList().ForEach(question => newSurveyQuestions.Add(DuplicateSurveyQuestion(question, newIdSurvey, idWebUserLastModifiedByy)));

			UpdateSurveyQuestionsFromConnector(newSurveyQuestions);

			return newSurveyQuestions;
		}

		public SurveyQuestion DuplicateSurveyQuestion(SurveyQuestion questionToCopy, Guid newIdSurvey, Guid idWebUserLastModifiedBy)
		{
			SurveyQuestion newSurveyQuestion = DuplicateSurveyQuestionFields(questionToCopy, newIdSurvey, idWebUserLastModifiedBy);
			newSurveyQuestion.Localizations = DuplicateSurveyQuestionLocalizations(questionToCopy.Localizations, newSurveyQuestion.Id, idWebUserLastModifiedBy);
			newSurveyQuestion.Choices = new SurveyQuestionChoiceDuplicator().DuplicateSurveyQuestionChoices(questionToCopy.Choices, newSurveyQuestion.Id, idWebUserLastModifiedBy);

			SurveyQuestionConnectorList.Add(new SurveyQuestionIdsConnector { OriginalId = questionToCopy.Id, NewId = newSurveyQuestion.Id });

			return newSurveyQuestion;
		}

		public SurveyQuestion DuplicateSurveyQuestionFields(SurveyQuestion questionToCopy, Guid newIdSurvey, Guid idWebUserLastModifiedBy)
		{
			return new SurveyQuestion
			{
				IdSurvey = newIdSurvey,
				MaxOccurrence = questionToCopy.MaxOccurrence,
				MinOccurrence = questionToCopy.MinOccurrence,
				Sequence = questionToCopy.Sequence,
				QuestionType = questionToCopy.QuestionType,
				IdSurveyQuestionNext = questionToCopy.IdSurveyQuestionNext,
				IdSurveyQuestionParent = questionToCopy.IdSurveyQuestionParent,
				IsRecursive = questionToCopy.IsRecursive,
				IdWebUserLastModifiedBy = idWebUserLastModifiedBy
			};
		}

		public List<SurveyQuestionLocalization> DuplicateSurveyQuestionLocalizations(ICollection<SurveyQuestionLocalization> localizationsToCopy, Guid newIdSurveyQuestion, Guid idWebUserLastModifiedBy)
		{
			List<SurveyQuestionLocalization> newQuestionLocalizations = new List<SurveyQuestionLocalization>();
			localizationsToCopy.Where(loc=>loc.IsActive).ToList().ForEach(questionLocalization => newQuestionLocalizations.Add(DuplicateSurveyQuestionLocalization(questionLocalization, newIdSurveyQuestion, idWebUserLastModifiedBy)));
			return newQuestionLocalizations;
		}

		public SurveyQuestionLocalization DuplicateSurveyQuestionLocalization(SurveyQuestionLocalization localizationToCopy, Guid newIdSurveyQuestion, Guid idWebUserLastModifiedBy)
		{
			return new SurveyQuestionLocalization { IdParent = newIdSurveyQuestion, LanguageCode = localizationToCopy.LanguageCode, Name = localizationToCopy.Name, Title = localizationToCopy.Title, IdWebUserLastModifiedBy = idWebUserLastModifiedBy};
		}

		public void UpdateSurveyQuestionsFromConnector(List<SurveyQuestion> surveyQuestions)
		{
			surveyQuestions.ForEach(UpdateSurveyQuestionFromConnector);
		}

		public void UpdateSurveyQuestionFromConnector(SurveyQuestion surveyQuestion)
		{
			UpdateQuestionNextQuestion(surveyQuestion);
			UdapteQuestionIdParent(surveyQuestion);
			UpdateChoiceNextQuestionFromConnector(surveyQuestion.Choices.ToList());
		}

		public void UpdateQuestionNextQuestion(SurveyQuestion surveyQuestion)
		{
			if(surveyQuestion.IdSurveyQuestionNext != null && surveyQuestion.IdSurveyQuestionNext != Guid.Empty)
			{
				var idsConnector = SurveyQuestionConnectorList.SingleOrDefault(sqid => sqid.OriginalId == surveyQuestion.IdSurveyQuestionNext);
				if(idsConnector != null)
					surveyQuestion.IdSurveyQuestionNext = idsConnector.NewId;
			}
		}

		public void UdapteQuestionIdParent(SurveyQuestion surveyQuestion)
		{
			if(surveyQuestion.IdSurveyQuestionParent != null)
			{
				var idsConnector = SurveyQuestionConnectorList.SingleOrDefault(sqid => sqid.OriginalId == surveyQuestion.IdSurveyQuestionParent);
				if(idsConnector != null)
					surveyQuestion.IdSurveyQuestionParent = idsConnector.NewId;
			}
		}

		public void UpdateChoiceNextQuestionFromConnector(List<SurveyQuestionChoice> surveyQuestionChoices)
		{
			surveyQuestionChoices.ForEach(choice =>
			{
				if (choice.IdSurveyQuestionNext != null && choice.IdSurveyQuestionNext != Guid.Empty)
				{
					var idsConnector = SurveyQuestionConnectorList.SingleOrDefault(sqid => sqid.OriginalId == choice.IdSurveyQuestionNext);
					if (idsConnector != null)
						choice.IdSurveyQuestionNext = idsConnector.NewId;
				}
			});
		}
    }
}
