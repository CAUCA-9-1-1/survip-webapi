using System;
using System.Linq;
using System.Collections.Generic;
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SurveyManagement;
using Microsoft.EntityFrameworkCore;

namespace Survi.Prevention.ServiceLayer.Services { 
	
	public class SurveyService : BaseCrudService<Survey> {

		public SurveyService(ManagementContext context) : base(context)
		{
		}

		public override Survey Get(Guid id)
		{
			var result = Context.Surveys
				.Include(s => s.Localizations)
				.FirstOrDefault(s => s.Id == id);

			return result;
		}

		public override List<Survey> GetList()
		{
			var result = Context.Surveys
						.Include(s => s.Localizations)
						.ToList();

			return result;
		}
	}

}