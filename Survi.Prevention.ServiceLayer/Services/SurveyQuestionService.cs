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

		public override bool Remove(Guid idSurveyQuestion, Guid idWebUserModified = new Guid())
		{
			if (idSurveyQuestion != Guid.Empty)
			{
				DeleteQuestion(idSurveyQuestion, idWebUserModified);

				DeleteChildQuestion(idSurveyQuestion, idWebUserModified);

				Context.SaveChanges();

				return true;
			}
			return false;
		}

		private void DeleteQuestion(Guid idSurveyQuestion, Guid idWebUserModified = new Guid())
		{
			var question = Context.SurveyQuestions.Include(sqc => sqc.Localizations).Single(sq => sq.Id == idSurveyQuestion);
			question.IsActive = false;
			question = UpdateModifiedInformation(question, idWebUserModified);
			if (question.Localizations.Any())
			{
				List<SurveyQuestionLocalization> questionLocalization = new List<SurveyQuestionLocalization>();
				questionLocalization.AddRange(question.Localizations);
				questionLocalization.ForEach(sql =>
				{
					sql.IsActive = false;
					sql.IdWebUserLastModifiedBy = idWebUserModified;
					sql.LastModifiedOn = DateTime.Now;
				});
			}

			DeleteQuestionChoices(idSurveyQuestion);
		}

		private void DeleteChildQuestion(Guid idSurveyQuestion, Guid idWebUserModified = new Guid())
		{
			var childQuestions = Context.SurveyQuestions.Include(sqc => sqc.Localizations).Where(sq => sq.IdSurveyQuestionParent == idSurveyQuestion && sq.IsActive).ToList();
			childQuestions.ForEach(cq =>
			{
				DeleteQuestion(cq.Id, idWebUserModified);
			});
		}

		private void DeleteQuestionChoices(Guid idSurveyQuestion, Guid idWebUserModified = new Guid())
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
				choices.ForEach(sqcl => 
				{
					sqcl.IsActive = false;
					sqcl.IdWebUserLastModifiedBy = idWebUserModified;
					sqcl.LastModifiedOn = DateTime.Now;
					});
			});
		}

		public bool MoveQuestion(Guid idSurveyQuestion, int sequence, Guid idWebUserModified = new Guid())
		{
			if (idSurveyQuestion != Guid.Empty && sequence > 0)
			{
				var question = Context.SurveyQuestions.Single(sq => sq.Id == idSurveyQuestion);
				if (question.Sequence != sequence)
				{
					var questionDest = Context.SurveyQuestions.Single(sqd => sqd.Sequence == sequence && sqd.Id != idSurveyQuestion && sqd.IdSurvey == question.IdSurvey && sqd.IsActive && sqd.IdSurveyQuestionParent == question.IdSurveyQuestionParent);

					int oldSequence = question.Sequence;
					questionDest.Sequence = oldSequence;
					questionDest = UpdateModifiedInformation(questionDest, idWebUserModified);
				}

				question.Sequence = sequence;
				question = UpdateModifiedInformation(question, idWebUserModified);

				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public List<SurveyQuestion> GetListLocalized(Guid idSurvey, string languageCode)
		{
			var query = Context.SurveyQuestions.AsNoTracking()
				.Include(sql => sql.Localizations)
				.Where(sq => sq.IdSurvey == idSurvey && sq.IsActive)
				.OrderBy(sq => sq.Sequence);

			var result = new InspectionSurveyTreeGenerator().GetSurveyQuestionTreeList(query.ToList());

			return result;
		}

		private SurveyQuestion UpdateModifiedInformation(SurveyQuestion question, Guid idWebUserModified)
		{
			if (idWebUserModified != Guid.Empty)
			{
				question.IdWebUserLastModifiedBy = idWebUserModified;
				question.LastModifiedOn = DateTime.Now;
			}
			return question;
		}
	}

}