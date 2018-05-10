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

		public List<InspectionQuestionForList> GetListLocalized(Guid idSurvey, string languageCode)
		{
			var inspectionQuestionQuery =
				(from surveyquestion in Context.SurveyQuestions
				 join questionanswser in Context.InspectionQuestions.Where(iq => iq.IsActive) on surveyquestion.Id equals questionanswser.IdSurveyQuestion into iqa
				 from questionanswser in iqa.DefaultIfEmpty()
				 where surveyquestion.IsActive && surveyquestion.IdSurvey == idSurvey
				 select new
				 {
					 Id = questionanswser.Id,
					 IdSurveyQuestion = surveyquestion.Id,
					 IdSurveyQuestionChoice = questionanswser.IdSurveyQuestionChoice,
					 Answer = questionanswser.Answer,
					 Title = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Title,
					 Description = surveyquestion.Localizations.SingleOrDefault(l => l.IsActive && l.LanguageCode == languageCode).Name,
 					 ChoicesList = surveyquestion.Choices,
					 Sequence = surveyquestion.Sequence
				 });

			var InspectionQuestionWithChoice =
				from question in inspectionQuestionQuery
				orderby question.Sequence
				select new InspectionQuestionForList
				{
					Id = question.Id,
					IdSurveyQuestion = question.IdSurveyQuestion,
					IdSurveyQuestionChoice = question.IdSurveyQuestionChoice,
					Answer = question.Answer,
					Title = question.Title,
					Description = question.Description,
					Sequence = question.Sequence,
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
	}

}