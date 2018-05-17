using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.ServiceLayer.Services
{

	public class InspectionQuestionService : BaseCrudService<InspectionQuestion>
	{

		public InspectionQuestionService(ManagementContext context) : base(context)
		{
		}

		public override InspectionQuestion Get(Guid id)
		{
			var result = Context.InspectionQuestions
				.SingleOrDefault(s => s.Id == id);

			return result;
		}

		public override List<InspectionQuestion> GetList()
		{
			var result = Context.InspectionQuestions
						.ToList();

			return result;
		}

		public List<InspectionQuestionForList> GetAnswerListLocalized(Guid idInspection, string languageCode)
		{
			var inspectionQuestionQuery =
				(from inspection in Context.Inspections
				 from surveyquestion in Context.SurveyQuestions.Where(sq => sq.IdSurvey == inspection.IdSurvey && sq.IsActive)
				 from questionanswser in Context.InspectionQuestions.Where(iq => iq.IsActive && iq.IdSurveyQuestion == surveyquestion.Id)
				 where inspection.IsActive && inspection.Id == idInspection
				 select new
				 {
					 Id = questionanswser.Id,
					 IdSurveyQuestion = surveyquestion.Id,
					 IdSurveyQuestionChoice = questionanswser.IdSurveyQuestionChoice,
					 Answer = questionanswser.Answer,
					 Title = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					 Description = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					 ChoicesList = surveyquestion.Choices,
					 Sequence = surveyquestion.Sequence,
					 QuestionType = surveyquestion.QuestionType,
					 idInspection = inspection.Id,
					 IdSurveyQuestionNext = surveyquestion.IdSurveyQuestionNext,
					 created_on = questionanswser.CreatedOn
				 });

			var InspectionQuestionWithChoice =
				from question in inspectionQuestionQuery
				orderby question.created_on, question.Sequence
				select new InspectionQuestionForList
				{
					Id = question.Id,
					IdSurveyQuestion = question.IdSurveyQuestion,
					IdSurveyQuestionChoice = question.IdSurveyQuestionChoice,
					Answer = question.Answer,
					Title = question.Title,
					Description = question.Description,
					Sequence = question.Sequence,
					QuestionType = question.QuestionType,
					IdInspection = question.idInspection,
					IdSurveyQuestionNext = question.IdSurveyQuestionNext,
					ChoicesList = (
						from choice in question.ChoicesList
						where choice.IsActive
						from loc in choice.Localizations
						where loc.IsActive && loc.LanguageCode == languageCode
						orderby choice.Sequence
						select new SurveyQuestionChoiceForList
						{
							Id = choice.Id,
							Description = loc.Name,
							IdSurveyQuestionNext = choice.IdSurveyQuestionNext,
							Sequence = choice.Sequence
						}
					).ToList()
				};
				

			return InspectionQuestionWithChoice.ToList();
		}

		public List<InspectionQuestionForList> GetSurveyQuestionListLocalized(Guid idInspection, string languageCode)
		{
			var SurveyQuestionQuery =
				(from inspection in Context.Inspections
				 from surveyquestion in Context.SurveyQuestions.Where(sq => sq.IdSurvey == inspection.IdSurvey && sq.IsActive)
				 where inspection.IsActive && inspection.Id == idInspection
				 orderby surveyquestion.Sequence
				 select new InspectionQuestionForList
				 {
					 Id = null,
					 IdSurveyQuestion = surveyquestion.Id,
					 IdSurveyQuestionChoice = null,
					 Answer = null,
					 Title = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					 Description = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					 ChoicesList = (
										from choice in surveyquestion.Choices
										where choice.IsActive
										from loc in choice.Localizations
										where loc.IsActive && loc.LanguageCode == languageCode
										orderby choice.Sequence
										select new SurveyQuestionChoiceForList
										{
											Id = choice.Id,
											Description = loc.Name,
											IdSurveyQuestionNext = choice.IdSurveyQuestionNext,
											Sequence = choice.Sequence
										}
									).ToList(),
					 Sequence = surveyquestion.Sequence,
					 QuestionType = surveyquestion.QuestionType,
					 IdInspection = inspection.Id,
					 IdSurveyQuestionNext = surveyquestion.IdSurveyQuestionNext
				 });

			return SurveyQuestionQuery.ToList();
		}

		public Guid SaveQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			if((inspectionQuestionAnswer.Id != null)&&(inspectionQuestionAnswer.Id != Guid.Empty))
			{
				var existingAnswer = Context.InspectionQuestions.Single(ea => ea.Id == inspectionQuestionAnswer.Id);
				existingAnswer.Answer = inspectionQuestionAnswer.Answer;
				existingAnswer.IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice;
				Context.InspectionQuestions.Update(existingAnswer);
			}
			else
			{
				var questionAnswer = new InspectionQuestion();
				questionAnswer.Answer = inspectionQuestionAnswer.Answer;
				questionAnswer.IdSurveyQuestion = inspectionQuestionAnswer.IdSurveyQuestion;
				questionAnswer.IdInspection = inspectionQuestionAnswer.IdInspection;
				questionAnswer.IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice;
				inspectionQuestionAnswer.Id = questionAnswer.Id;
				Context.InspectionQuestions.Add(questionAnswer);
			}

			Context.SaveChanges();

			return inspectionQuestionAnswer.Id.Value;
		}

		public bool CompleteSurvey(Guid idInspection)
		{
			if(idInspection != null && idInspection != Guid.Empty)
			{
				Context.Inspections.Single(i => i.Id == idInspection && i.IsActive).IsSurveyCompleted = true;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public List<InspectionSummaryCategoryForList> getInspectionQuestionSummaryListLocalized(Guid idInspection, string languageCode)
		{
			var AnswerSummary = (
				from inspectionQuestion in Context.InspectionQuestions
				from surveyQuestion in Context.SurveyQuestions.Where(sq => sq.IsActive && sq.Id == inspectionQuestion.IdSurveyQuestion)
				join surveyQuestionChoice in Context.SurveyQuestionChoices.Where(sqc => sqc.IsActive) on inspectionQuestion.IdSurveyQuestionChoice equals surveyQuestionChoice.Id into aqc
				from surveyQuestionChoice in aqc.DefaultIfEmpty()
				orderby inspectionQuestion.CreatedOn
				select new InspectionQuestionForSummary
				{
					Id = inspectionQuestion.Id,
					QuestionTitle = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					QuestionDescription = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					Answer = surveyQuestion.QuestionType != 1 ? inspectionQuestion.Answer : surveyQuestionChoice.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					QuestionType = surveyQuestion.QuestionType,
					Sequence = surveyQuestion.Sequence
				}).ToList();

			var groupedTitle =
				from groupedQuestion in AnswerSummary
				group groupedQuestion by groupedQuestion.QuestionTitle
				into gq
				select new InspectionSummaryCategoryForList
				{
					Title = gq.Key,
					AnswerSummary = gq.ToList()
				};

			return groupedTitle.ToList();
		}

	}

}