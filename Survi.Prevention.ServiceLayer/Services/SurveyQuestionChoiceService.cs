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
						.Include(sqc => sqc.Localizations)
						.Where(sqc => sqc.IdSurveyQuestion == idSurveyQuestion)
						.ToList();

			return result;
		}
	}

}