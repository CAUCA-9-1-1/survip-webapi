using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.SurveyManagement
{
	public class SurveyQuestion : BaseModel
	{
		public int Sequence { get; set; }
		public int QuestionType { get; set; }
		public int MaxOccurrence { get; set; }
		public int MinOccurrence { get; set; }

		public Guid IdSurvey { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }

		public Survey Survey { get; set; }

		public bool IsRecursive { get; set; }
		public Guid? IdSurveyQuestionParent { get; set; }

		public ICollection<SurveyQuestionChoice> Choices { get; set; } = new List<SurveyQuestionChoice>();
		public ICollection<SurveyQuestionLocalization> Localizations { get; set; } = new List<SurveyQuestionLocalization>();
	}
}
