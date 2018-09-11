using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionQuestionForList
    {
		public Guid? Id { get; set; }
		public Guid IdInspection { get; set; }
		public Guid IdSurveyQuestion { get; set; }
		public Guid? IdSurveyQuestionChoice { get; set; }
		public int QuestionType { get; set; }
		public string Answer { get; set; } = "";
		public string Title { get; set; }
		public string Description { get; set; }
		public Guid? IdSurveyQuestionNext { get; set; }
	    public Guid? IdSurveyQuestionParent { get; set; }
		public int Sequence { get; set; }

	    public List<InspectionQuestionForList> ChildSurveyAnswerList { get; set; }
		public List<SurveyQuestionChoiceForList> ChoicesList { get; set; }

	}
}
