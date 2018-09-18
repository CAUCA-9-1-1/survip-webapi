using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{

	public class InspectionSurveyAnswerService : BaseCrudService<InspectionSurveyAnswer>
	{

		public InspectionSurveyAnswerService(ManagementContext context) : base(context)
		{
		}

		public override InspectionSurveyAnswer Get(Guid id)
		{
			var result = Context.InspectionSurveyAnswers
				.SingleOrDefault(s => s.Id == id);

			return result;
		}

		public override List<InspectionSurveyAnswer> GetList()
		{
			var result = Context.InspectionSurveyAnswers
						.ToList();

			return result;
		}

		public List<InspectionQuestionForList> GetAnswerListLocalized(Guid idInspection, string languageCode)
		{
			var inspectionQuestionQuery =
				from inspection in Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
				from surveyquestion in Context.SurveyQuestions.Where(sq => sq.IdSurvey == inspection.IdSurvey && sq.IsActive)
				from questionanswser in Context.InspectionSurveyAnswers.Where(iq => iq.IsActive && iq.IdSurveyQuestion == surveyquestion.Id && iq.IdInspection == inspection.Id)
				from questionLocalization in surveyquestion.Localizations
				where questionLocalization.IsActive && questionLocalization.LanguageCode == languageCode
				select new
				{
					questionanswser.Id,
					IdSurveyQuestion = surveyquestion.Id,
					questionanswser.IdSurveyQuestionChoice,
					questionanswser.Answer,
					questionLocalization.Title,
					Description = questionLocalization.Name,
					ChoicesList = surveyquestion.Choices,
					surveyquestion.Sequence,
					surveyquestion.QuestionType,
					idInspection = inspection.Id,
					surveyquestion.IdSurveyQuestionNext,
					created_on = questionanswser.CreatedOn,
					idParent = questionanswser.IdSurveyAnswerParent,
					surveyquestion.MinOccurrence,
					surveyquestion.MaxOccurrence
				};

			var inspectionQuestionWithChoice =
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
					IdParent = question.idParent,
					MinOccurrence = question.MinOccurrence,
					MaxOccurrence = question.MaxOccurrence,
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

			var formatedList =  new InspectionSurveyTreeGenerator().GetSurveyAnswerTreeList(inspectionQuestionWithChoice.ToList());
			return formatedList;
		}

		public List<InspectionQuestionForList> GetSurveyQuestionListLocalized(Guid idInspection, string languageCode)
		{
			var surveyQuestionQuery =
				from inspection in Context.Inspections
				 from surveyquestion in Context.SurveyQuestions.Where(sq => sq.IdSurvey == inspection.IdSurvey && sq.IsActive)
				 where inspection.IsActive && inspection.Id == idInspection
				from questionLocalization in surveyquestion.Localizations
				where questionLocalization.IsActive && questionLocalization.LanguageCode == languageCode
				orderby surveyquestion.Sequence
				 select new InspectionQuestionForList
				 {
					 Id = null,
					 IdSurveyQuestion = surveyquestion.Id,
					 IdSurveyQuestionChoice = null,
					 Answer = null,
					 Title = questionLocalization.Title,
					 Description = questionLocalization.Name,
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
					 IdSurveyQuestionNext = surveyquestion.IdSurveyQuestionNext,
					 IdParent = surveyquestion.IdSurveyQuestionParent,
					 MinOccurrence = surveyquestion.MinOccurrence,
					 MaxOccurrence = surveyquestion.MaxOccurrence
				 };

			var formatedList = new InspectionSurveyTreeGenerator().GetSurveyQuestionTreeList(surveyQuestionQuery.ToList());
			return formatedList;
		}

		public Guid SaveQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			var existingAnswer = false;
			if (inspectionQuestionAnswer.Id != null && inspectionQuestionAnswer.Id != Guid.Empty)
				existingAnswer = Context.InspectionSurveyAnswers.AsNoTracking().Any(ea => ea.Id == inspectionQuestionAnswer.Id);

			if(existingAnswer)
				return UpdateQuestionAnswer(inspectionQuestionAnswer);
			return AddQuestionAnswer(inspectionQuestionAnswer);
		}

		private Guid AddQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
				var questionAnswer = new InspectionSurveyAnswer
				{
					Id = inspectionQuestionAnswer.Id ?? Guid.NewGuid() ,
					Answer = inspectionQuestionAnswer.Answer,
					IdSurveyQuestion = inspectionQuestionAnswer.IdSurveyQuestion,
					IdInspection = inspectionQuestionAnswer.IdInspection,
					IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice,
					IdSurveyAnswerParent = inspectionQuestionAnswer.IdParent
				};
				Context.InspectionSurveyAnswers.Add(questionAnswer);
				Context.SaveChanges();

				inspectionQuestionAnswer.Id = questionAnswer.Id;

				return questionAnswer.Id;
		}

		private Guid UpdateQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			var existingAnswer = Context.InspectionSurveyAnswers.Single(ea => ea.Id == inspectionQuestionAnswer.Id);
			existingAnswer.Answer = inspectionQuestionAnswer.Answer;
			existingAnswer.IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice;
			Context.InspectionSurveyAnswers.Update(existingAnswer);
			Context.SaveChanges();

			return existingAnswer.Id;
		}

		public bool CompleteSurvey(Guid idInspection)
		{
			if(idInspection != Guid.Empty)
			{
				Context.Inspections.Single(i => i.Id == idInspection && i.IsActive).IsSurveyCompleted = true;
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public List<InspectionSummaryCategoryForList> GetInspectionQuestionSummaryListLocalized(Guid idInspection, string languageCode)
		{
			var answerSummary = 
				from surveyAnswerQuestion in Context.InspectionSurveyAnswers
				from surveyQuestion in Context.SurveyQuestions.Where(sq => sq.IsActive && sq.Id == surveyAnswerQuestion.IdSurveyQuestion)
				join surveyQuestionChoice in Context.SurveyQuestionChoices.Where(sqc => sqc.IsActive) on surveyAnswerQuestion.IdSurveyQuestionChoice equals surveyQuestionChoice.Id into aqc
				from surveyQuestionChoice in aqc.DefaultIfEmpty()
				where surveyAnswerQuestion.IdInspection == idInspection && surveyAnswerQuestion.IsActive
				let choiceName = surveyQuestionChoice.Localizations.FirstOrDefault(sql=> sql.LanguageCode == languageCode)
				from questionLocalization in surveyQuestion.Localizations
				where questionLocalization.IsActive && questionLocalization.LanguageCode == languageCode
				orderby surveyAnswerQuestion.CreatedOn
				select new InspectionQuestionForSummary
				{
					Id = surveyAnswerQuestion.Id,
					NextQuestionId = surveyQuestion.Id,
					QuestionTitle = questionLocalization.Title,
					QuestionDescription = questionLocalization.Name,
					Answer = surveyQuestion.QuestionType == 1 ? choiceName.Name :surveyAnswerQuestion.Answer,
					QuestionType = surveyQuestion.QuestionType,
					Sequence = surveyQuestion.Sequence,
					IdParent = surveyAnswerQuestion.IdSurveyAnswerParent
					};

			var formatedList =  new InspectionSurveyTreeGenerator().GetSurveySummaryTreeList(answerSummary.ToList());

			var categoryGroupedAnswerList = from groupedAnswers in formatedList
				group groupedAnswers by groupedAnswers.QuestionTitle
				into gq
				select new InspectionSummaryCategoryForList
				{
					Title = gq.Key,
					AnswerSummary = gq.ToList()
				};

			return categoryGroupedAnswerList.ToList();

		}
	}
}