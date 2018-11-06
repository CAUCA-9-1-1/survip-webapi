using Survi.Prevention.Models.SurveyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survi.Prevention.ServiceLayer.SurveyDuplicator
{
    public class SurveyQuestionDuplicator
    {
		public class SurveyQuestionConnector
		{
			public Guid OriginalId { get; set; }
			public Guid NewId { get; set; }
		}

		private List<SurveyQuestionConnector> surveyQuestionConnectorList = new List<SurveyQuestionConnector>();

		public List<SurveyQuestion> DuplicateSurveyQuestions(ICollection<SurveyQuestion> questionsToCopy, Guid newIdSurvey)
		{
			List<SurveyQuestion> newSurveyQuestion = new List<SurveyQuestion>();
			questionsToCopy.ToList().ForEach(question => newSurveyQuestion.Add(DuplicateSurveyQuestion(question, newIdSurvey)));
			return newSurveyQuestion;
		}

		public SurveyQuestion DuplicateSurveyQuestion(SurveyQuestion questionToCopy, Guid newIdSurvey)
		{
			SurveyQuestion newSurveyQuestion = DuplicateSurveyQuestionFields(questionToCopy, newIdSurvey);
			newSurveyQuestion.Localizations = DuplicateSurveyQuestionLocalizations(questionToCopy.Localizations, newSurveyQuestion.Id);
			newSurveyQuestion.Choices = new SurveyQuestionChoiceDuplicator().DuplicateSurveyQuestionChoices(newSurveyQuestion.Choices, newSurveyQuestion.Id);

			surveyQuestionConnectorList.Add(new SurveyQuestionConnector { OriginalId = questionToCopy.Id, NewId = newSurveyQuestion.Id });

			return newSurveyQuestion;
		}

		public SurveyQuestion DuplicateSurveyQuestionFields(SurveyQuestion questionToCopy, Guid newIdSurvey)
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
				IsRecursive = questionToCopy.IsRecursive
			};
		}

		public List<SurveyQuestionLocalization> DuplicateSurveyQuestionLocalizations(ICollection<SurveyQuestionLocalization> localizationsToCopy, Guid newIdSurveyQuestion)
		{
			List<SurveyQuestionLocalization> newQuestionLocalizations = new List<SurveyQuestionLocalization>();
			localizationsToCopy.ToList().ForEach(questionLocalization => newQuestionLocalizations.Add(DuplicateSurveyQuestionLocalization(questionLocalization, newIdSurveyQuestion)));
			return newQuestionLocalizations;
		}

		public SurveyQuestionLocalization DuplicateSurveyQuestionLocalization(SurveyQuestionLocalization localizationToCopy, Guid newIdSurveyQuestion)
		{
			return new SurveyQuestionLocalization { IdParent = newIdSurveyQuestion, LanguageCode = localizationToCopy.LanguageCode, Name = localizationToCopy.Name, Title = localizationToCopy.Title };
		}

		public void UpdateSurveyQuestionsFromConnector(List<SurveyQuestion> surveyQuestions)
		{
			surveyQuestions.ForEach(question => UpdateSurveyQuestionFromConnector(question));
		}

		public void UpdateSurveyQuestionFromConnector(SurveyQuestion surveyQuestion)
		{
			UdapteQuestionNextQuestion(surveyQuestion);
			UdapteQuestionIdParent(surveyQuestion);
			UpdateChoiceNextQuestionFromConnector(surveyQuestion.Choices.ToList());
		}

		public void UdapteQuestionNextQuestion(SurveyQuestion surveyQuestion)
		{
			if(surveyQuestion.IdSurveyQuestionNext != null)
			{
				var idsConnector = surveyQuestionConnectorList.Single(sqid => sqid.OriginalId == surveyQuestion.IdSurveyQuestionNext);
				if(idsConnector != null)
					surveyQuestion.IdSurveyQuestionNext = idsConnector.NewId;
			}
		}

		public void UdapteQuestionIdParent(SurveyQuestion surveyQuestion)
		{
			if(surveyQuestion.IdSurveyQuestionParent != null)
			{
				var idsConnector = surveyQuestionConnectorList.Single(sqid => sqid.OriginalId == surveyQuestion.IdSurveyQuestionParent);
				if(idsConnector != null)
					surveyQuestion.IdSurveyQuestionParent = idsConnector.NewId;
			}
		}

		public void UpdateChoiceNextQuestionFromConnector(List<SurveyQuestionChoice> surveyQuestionChoices)
		{
			surveyQuestionChoices.ForEach(choice =>
			{
				var idsConnector = surveyQuestionConnectorList.Single(sqid => sqid.OriginalId == choice.IdSurveyQuestionNext && choice.IdSurveyQuestionNext != null);
				if (idsConnector != null)
					choice.IdSurveyQuestionNext = idsConnector.NewId;
			});
		}
    }
}
