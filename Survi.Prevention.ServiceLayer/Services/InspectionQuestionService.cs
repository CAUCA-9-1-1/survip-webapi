using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services
{

	public class InspectionQuestionService : BaseCrudService<QuestionAnswer>
	{

		public InspectionQuestionService(ManagementContext context) : base(context)
		{
		}

		public override QuestionAnswer Get(Guid id)
		{
			var result = Context.InspectionQuestions
				.SingleOrDefault(s => s.Id == id);

			return result;
		}

		public override List<QuestionAnswer> GetList()
		{
			var result = Context.InspectionQuestions
						.ToList();

			return result;
		}

		public List<InspectionQuestionForList> GetAnswerListLocalized(Guid idInspection, string languageCode)
		{
			var inspectionQuestionQuery =
				from inspection in Context.Inspections.Where(i => i.Id == idInspection && i.IsActive)
				from surveyquestion in Context.SurveyQuestions.Where(sq => sq.IdSurvey == inspection.IdSurvey && sq.IsActive)
				from questionanswser in Context.InspectionQuestions.Where(iq => iq.IsActive && iq.IdSurveyQuestion == surveyquestion.Id && iq.IdInspection == inspection.Id)
				select new
				{
					questionanswser.Id,
					IdSurveyQuestion = surveyquestion.Id,
					questionanswser.IdSurveyQuestionChoice,
					questionanswser.Answer,
					surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					Description = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					ChoicesList = surveyquestion.Choices,
					surveyquestion.Sequence,
					surveyquestion.QuestionType,
					idInspection = inspection.Id,
					surveyquestion.IdSurveyQuestionNext,
					created_on = questionanswser.CreatedOn
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
			var questionAnswer = new QuestionAnswer
			{
				Answer = inspectionQuestionAnswer.Answer,
				IdSurveyQuestion = inspectionQuestionAnswer.IdSurveyQuestion,
				IdInspection = inspectionQuestionAnswer.IdInspection,
				IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice
			};
			Context.InspectionQuestions.Add(questionAnswer);
			Context.SaveChanges();

			return questionAnswer.Id;
		}
		private Guid UpdateQuestionAnswer(InspectionQuestionForList inspectionQuestionAnswer)
		{
			var existingAnswer = Context.InspectionQuestions.Single(ea => ea.Id == inspectionQuestionAnswer.Id);
			existingAnswer.Answer = inspectionQuestionAnswer.Answer;
			existingAnswer.IdSurveyQuestionChoice = inspectionQuestionAnswer.IdSurveyQuestionChoice;
			Context.InspectionQuestions.Update(existingAnswer);
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
				from inspectionQuestion in Context.InspectionQuestions
				from surveyQuestion in Context.SurveyQuestions.Where(sq => sq.IsActive && sq.Id == inspectionQuestion.IdSurveyQuestion)
				join surveyQuestionChoice in Context.SurveyQuestionChoices.Where(sqc => sqc.IsActive) on inspectionQuestion.IdSurveyQuestionChoice equals surveyQuestionChoice.Id into aqc
				from surveyQuestionChoice in aqc.DefaultIfEmpty()
				where inspectionQuestion.IdInspection == idInspection
				orderby inspectionQuestion.CreatedOn
				select new InspectionQuestionForSummary
				{
					Id = inspectionQuestion.Id,
					NextQuestionId = surveyQuestion.Id,
					QuestionTitle = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					QuestionDescription = surveyQuestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
					Answer = surveyQuestion.QuestionType != 1 ? inspectionQuestion.Answer : surveyQuestionChoice.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
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