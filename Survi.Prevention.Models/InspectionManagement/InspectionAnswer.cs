using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InspectionAnswer : BaseModel
	{
		public DateTime AnsweredOn { get; set; }
		public bool HasRefused { get; set; }
		public bool ReasonForRefusal { get; set; }
		public bool IsAbsent { get; set; }
		public bool IsSeasonal { get; set; }
		public bool IsVacant { get; set; }

		public Guid IdInspection { get; set; }
		public Guid IdWebUser { get; set; }

		public Inspection Inspection { get; set; }
		public Webuser AnsweredBy { get; set; }

		public ICollection<InspectionQuestion> SurveyAnswers { get; set; }
	}
}
