using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SurveyManagement;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{

	public class SurveyQuestionService : BaseCrudService<SurveyQuestion>
	{

		public SurveyQuestionService(ManagementContext context) : base(context)
		{
		}

		public override SurveyQuestion Get(Guid id)
		{
			var result = Context.SurveyQuestions
				.Include(sq => sq.Localizations)
				.Single(sq => sq.Id == id);

			return result;
		}

		public override List<SurveyQuestion> GetList()
		{
			var result = Context.SurveyQuestions
						.Include(sq => sq.Localizations)
						.OrderBy(sq => sq.Sequence)
						.ToList();

			return result;
		}

		public override bool Remove(Guid idSurveyQuestion)
		{
			if (idSurveyQuestion != Guid.Empty)
			{
				deleteQuestion(idSurveyQuestion);

				deleteQuestionChoices(idSurveyQuestion);

				Context.SaveChanges();

				return true;
			}
			return false;
		}

		private void deleteQuestion(Guid idSurveyQuestion)
		{
			var question = Context.SurveyQuestions.Include(sqc => sqc.Localizations).Single(sq => sq.Id == idSurveyQuestion);
			question.IsActive = false;
			List<SurveyQuestionLocalization> questionLocalization = new List<SurveyQuestionLocalization>();
			questionLocalization.AddRange(question.Localizations);
			questionLocalization.ForEach(sql => sql.IsActive = false);
		}

		private void deleteQuestionChoices(Guid idSurveyQuestion)
		{
			var questionChoices = Context.SurveyQuestionChoices
					.Include(sqc => sqc.Localizations)
					.Where(sqc => sqc.IdSurveyQuestion == idSurveyQuestion)
					.ToList();

			questionChoices.ForEach(qc =>
			{
				qc.IsActive = false;
				List<SurveyQuestionChoiceLocalization> choices = new List<SurveyQuestionChoiceLocalization>();
				choices.AddRange(qc.Localizations);
				choices.ForEach(sqcl => sqcl.IsActive = false);
			});
		}

		public bool MoveQuestion(Guid idSurveyQuestion, int sequence)
		{
			if (idSurveyQuestion != Guid.Empty && sequence > 0)
			{
				var Question = Context.SurveyQuestions.Single(sq => sq.Id == idSurveyQuestion);
				var QuestionDest = Context.SurveyQuestions.Single(sqd => sqd.Sequence == sequence && sqd.Id != idSurveyQuestion);

				int OldSequence = Question.Sequence;
				Question.Sequence = sequence;
				QuestionDest.Sequence = OldSequence;

				Context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<SurveyQuestion> GetListLocalized(Guid idSurvey, string languageCode)
		{
			var result = Context.SurveyQuestions
						.Include(sq => sq.Localizations)
						.Where(sq => sq.IdSurvey == idSurvey)
						.OrderBy(sq => sq.Sequence)
						.ToList();

			return result;
		}
	}

}