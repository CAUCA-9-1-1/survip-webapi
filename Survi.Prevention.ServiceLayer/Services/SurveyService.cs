using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SurveyManagement;
using Microsoft.EntityFrameworkCore;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.ServiceLayer.Services { 
	
	public class SurveyService : BaseCrudService<Survey> {

		public SurveyService(ManagementContext context) : base(context)
		{
		}

		public override Survey Get(Guid id)
		{
			var result = Context.Surveys
				.Include(sl => sl.Localizations)
				.Single(s => s.Id == id);

			return result;
		}

		public override List<Survey> GetList()
		{
			var result = Context.Surveys
						.Where(s => s.IsActive)
						.Include(s => s.Localizations)
						.ToList();

			return result;
		}

		public bool CopySurvey(Guid idSurvey)
		{
			return true;
		}

		public List<GenericModelForDisplay> GetListLocalized(string languageCode)
		{
			var query =
				from survey in Context.Surveys.AsNoTracking()
				where survey.IsActive
				from localization in survey.Localizations
				where localization.IsActive && localization.LanguageCode == languageCode
				select new GenericModelForDisplay
				{
					Id = survey.Id,
					Name = localization.Name
				};

			return query.ToList();
		}
	}

}