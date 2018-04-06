using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestionChoice : BaseModel
	{
		public int Sequence { get; set; }

		public Guid IdSurveyQuestion { get; set; }
		public Guid IdLanguageContentName { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public SurveyQuestion Question { get; set; }
		public SurveyQuestion NextQuestion { get; set; }
	}
}
