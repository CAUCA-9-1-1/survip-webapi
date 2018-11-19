using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SurveyManagement;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services
{

	public class SurveyQuestionChoiceService : BaseCrudService<SurveyQuestionChoice>
	{

		public SurveyQuestionChoiceService(ManagementContext context) : base(context)
		{
		}

		public override SurveyQuestionChoice Get(Guid id)
		{
			var result = Context.SurveyQuestionChoices
				.Include(sqc => sqc.Localizations)
				.Single(sqc => sqc.Id == id);

			return result;
		}

		public override List<SurveyQuestionChoice> GetList()
		{
			var result = Context.SurveyQuestionChoices
						.Include(sqc => sqc.Localizations)
						.ToList();

			return result;
		}

		public List<SurveyQuestionChoice> GetListLocalized(Guid idSurveyQuestion, string languageCode)
		{
			var result = Context.SurveyQuestionChoices
						.Include(sqcl => sqcl.Localizations)
						.Where(sqc => sqc.IdSurveyQuestion == idSurveyQuestion && sqc.IsActive)
						.ToList();

			return result;
		}

		public override bool Remove(Guid idSurveyQuestionChoice)
		{
			if (idSurveyQuestionChoice != Guid.Empty)
			{
				var questionChoice = Context.SurveyQuestionChoices.Include(sqc => sqc.Localizations).Single(sq => sq.Id == idSurveyQuestionChoice);
				questionChoice.IsActive = false;

			    if (questionChoice.Localizations.Any())
			    {
			        List<SurveyQuestionChoiceLocalization> questionLocalization = new List<SurveyQuestionChoiceLocalization>();
			        questionLocalization.AddRange(questionChoice.Localizations);
			        questionLocalization.ForEach(sql => sql.IsActive = false);
				}
				Context.SaveChanges();
				return true;
			}
			return false;
		}

		public bool DeleteQuestionChoices(Guid idSurveyQuestion)
		{
			if (idSurveyQuestion != Guid.Empty)
			{
				var questionChoices = Context.SurveyQuestionChoices
					.Include(sqcl => sqcl.Localizations)
					.Where(sqc => sqc.IdSurveyQuestion == idSurveyQuestion && sqc.IsActive)
					.ToList();

				questionChoices.ForEach(qc =>
				{
					qc.IsActive = false;
					List<SurveyQuestionChoiceLocalization> choices = new List<SurveyQuestionChoiceLocalization>();
					choices.AddRange(qc.Localizations);
					choices.ForEach(sqcl => sqcl.IsActive = false);
				});

				Context.SaveChanges();

				return true;
			}
			return false;
		}
	}

}