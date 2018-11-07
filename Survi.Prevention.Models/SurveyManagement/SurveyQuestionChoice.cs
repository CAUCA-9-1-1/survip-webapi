using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestionChoice : BaseModel
	{
		public int Sequence { get; set; }

		public Guid IdSurveyQuestion { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public SurveyQuestion Question { get; set; }
		public SurveyQuestion NextQuestion { get; set; }
		public ICollection<SurveyQuestionChoiceLocalization> Localizations { get; set; } = new List<SurveyQuestionChoiceLocalization>();
	}
}
