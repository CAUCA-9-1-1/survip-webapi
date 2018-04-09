using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestion : BaseModel
	{
		public int Sequence { get; set; }
		public int QuestionType { get; set; }

		public Guid IdSurvey { get; set; }
		public Guid IdLanguageContentTitle { get; set; }
		public Guid IdLanguageContentName { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public Survey Survey { get; set; }
		public SurveyQuestion NextQuestion { get; set; }

		public ICollection<SurveyQuestionChoice> Choices { get; set; }
	}
}
