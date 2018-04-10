using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.SurveyManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InspectionQuestion : BaseModel
	{
		public Guid IdInspectionAnswer { get; set; }
		public Guid IdSurveyQuestion { get; set; }
		public Guid? IdSurveyQuestionChoice { get; set; }
		public string Answer { get; set; }

		public InspectionAnswer InspectionAnswer { get; set; }
		public SurveyQuestion Question { get; set; }
		public SurveyQuestionChoice Choice { get; set; }		
	}
}
