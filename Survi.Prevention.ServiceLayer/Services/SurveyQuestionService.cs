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
				.FirstOrDefault(sq => sq.Id == id);

			return result;
		}

		public override List<SurveyQuestion> GetList()
		{
			var result = Context.SurveyQuestions
						.Include(sq => sq.Localizations)
						.ToList();

			return result;
		}

		public bool MoveQuestion(Guid idSurveyQuestion, int sequence)
		{
			if ((idSurveyQuestion != Guid.Empty) && (sequence > 0))
			{
				var Question = Context.SurveyQuestions.FirstOrDefault(sq => sq.Id == idSurveyQuestion);
				Question.Sequence = sequence;
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
						.ToList();

			return result;
		}
	}

}