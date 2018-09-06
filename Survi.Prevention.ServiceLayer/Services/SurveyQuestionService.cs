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

		public override Guid AddOrUpdate(SurveyQuestion entity)
		{
			UpdateSequenceOnAddingChild(entity);

			return base.AddOrUpdate(entity);
		}

		private void UpdateSequenceOnAddingChild(SurveyQuestion questionChild)
		{
			if (questionChild.IdSurveyQuestionParent != null && questionChild.IdSurveyQuestionParent != Guid.Empty)
			{
				if (!Context.SurveyQuestions.Any(sq => sq.Id == questionChild.Id))
				{
					var lastParentSequence = GetQuestionMaxSequence(questionChild.IdSurveyQuestionParent);
					UpdateQuestionSequence(lastParentSequence);
					questionChild.Sequence = lastParentSequence + 1;
				}
			}
		}

		private int GetQuestionMaxSequence(Guid? idSurveyQuestionParent)
		{
			var childQuestions = Context.SurveyQuestions
						.Where(sq => sq.IdSurveyQuestionParent == idSurveyQuestionParent && sq.IsActive).ToList();
			if (childQuestions.Any())
				return childQuestions.Max(sq => sq.Sequence);
			return GetParentQuestionSequence(idSurveyQuestionParent);
		}

		private int GetParentQuestionSequence(Guid? idSurveyQuestionParent)
		{
			var inspection = Context.SurveyQuestions.FirstOrDefault(sq => sq.Id == idSurveyQuestionParent && sq.IsActive);
			if (inspection != null)
				return inspection.Sequence;
			return 0;
		}

		private void UpdateQuestionSequence(int sequenceStart)
		{
			foreach (var surveyQuestion in Context.SurveyQuestions
											.Where(sql =>sql.Sequence > sequenceStart))
			{
				surveyQuestion.Sequence += 1;
			}
		}

		public override bool Remove(Guid idSurveyQuestion)
		{
			if (idSurveyQuestion != Guid.Empty)
			{
				DeleteQuestion(idSurveyQuestion);

				DeleteChildQuestion(idSurveyQuestion);

				Context.SaveChanges();

				return true;
			}
			return false;
		}

		private void DeleteQuestion(Guid idSurveyQuestion)
		{
			var question = Context.SurveyQuestions.Include(sqc => sqc.Localizations).Single(sq => sq.Id == idSurveyQuestion);
			question.IsActive = false;
			if (question.Localizations.Any())
			{
				List<SurveyQuestionLocalization> questionLocalization = new List<SurveyQuestionLocalization>();
				questionLocalization.AddRange(question.Localizations);
				questionLocalization.ForEach(sql => sql.IsActive = false);
			}
			
			DeleteQuestionChoices(idSurveyQuestion);
		}

		private void DeleteChildQuestion(Guid idSurveyQuestion)
		{
			var childQuestions = Context.SurveyQuestions.Include(sqc => sqc.Localizations).Where(sq => sq.IdSurveyQuestionParent == idSurveyQuestion).ToList();
			childQuestions.ForEach(cq =>
			{
				DeleteQuestion(cq.Id);
			});
		}

		private void DeleteQuestionChoices(Guid idSurveyQuestion)
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
				var question = Context.SurveyQuestions.Single(sq => sq.Id == idSurveyQuestion);
				if (question.Sequence != sequence)
				{
					var questionDest = Context.SurveyQuestions.Single(sqd => sqd.Sequence == sequence && sqd.Id != idSurveyQuestion && sqd.IdSurvey == question.IdSurvey && sqd.IsActive);

					int oldSequence = question.Sequence;
					questionDest.Sequence = oldSequence;
				}

				question.Sequence = sequence;
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

			var result = query.ToList();

			RemoveNextQuestionNavigationPropertyValue(result);

			return result;
		}

		private static void RemoveNextQuestionNavigationPropertyValue(List<SurveyQuestion> result)
		{
			// This is because EFCore does automatically load self referencing navigation property
			// and we don't want them in angular/ionic.
			result.ForEach(question => question.NextQuestion = null);
		}
	}

}