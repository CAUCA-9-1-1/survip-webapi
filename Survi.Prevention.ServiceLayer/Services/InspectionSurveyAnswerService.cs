using System;
using System.Linq;
using System.Collections.Generic;
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
					idInspectionSurveyQuestionParent = surveyquestion.IdSurveyQuestionParent
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
					IdSurveyQuestionParent = question.idInspectionSurveyQuestionParent,
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

			return inspectionQuestionWithChoice.ToList();
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
					 IdSurveyQuestionParent = surveyquestion.IdSurveyQuestionParent
				 };

			return surveyQuestionQuery.ToList();
		}

		public Guid SaveQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			if (inspectionQuestionAnswer.Id != null && inspectionQuestionAnswer.Id != Guid.Empty)
				return UpdateQuestionAnswer(inspectionQuestionAnswer);

			return AddQuestionAnswer(inspectionQuestionAnswer);
		}

		private Guid AddQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			var questionAnswer = new InspectionSurveyAnswer
			{
				Answer = inspectionQuestionAnswer.Answer,
				IdSurveyQuestion = inspectionQuestionAnswer.IdSurveyQuestion,
				IdInspection = inspectionQuestionAnswer.IdInspection,
				IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice
			};
			Context.InspectionSurveyAnswers.Add(questionAnswer);
			Context.SaveChanges();

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
			var answerSummary = (
				from inspectionQuestion in Context.InspectionSurveyAnswers
				from surveyQuestion in Context.SurveyQuestions.Where(sq => sq.IsActive && sq.Id == inspectionQuestion.IdSurveyQuestion)
				join surveyQuestionChoice in Context.SurveyQuestionChoices.Where(sqc => sqc.IsActive) on inspectionQuestion.IdSurveyQuestionChoice equals surveyQuestionChoice.Id into aqc
				from surveyQuestionChoice in aqc.DefaultIfEmpty()
				where inspectionQuestion.IdInspection == idInspection
				from questionLocalization in surveyQuestion.Localizations
				where questionLocalization.IsActive && questionLocalization.LanguageCode == languageCode
				orderby inspectionQuestion.CreatedOn
				select new InspectionQuestionForSummary
				{
					Id = inspectionQuestion.Id,
					NextQuestionId = surveyQuestion.Id,
					QuestionTitle = questionLocalization.Title,
					QuestionDescription = questionLocalization.Name,
					Answer = surveyQuestion.QuestionType != 1 ? inspectionQuestion.Answer : questionLocalization.Name,
					QuestionType = surveyQuestion.QuestionType,
					Sequence = surveyQuestion.Sequence,
					IsRecursive = surveyQuestion.IsRecursive
					
				}).ToList();

			List<InspectionQuestionForSummary> recursiveList = new RecursiveInspectionQuestionProcess().GroupRecursiveQuestion(answerSummary);

			var groupedTitle =
				from groupedQuestion in recursiveList
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