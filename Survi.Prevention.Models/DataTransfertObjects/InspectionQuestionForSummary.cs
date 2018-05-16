using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionQuestionForSummary
	{
		public Guid Id { get; set; }
		public string QuestionDescription { get; set; }
		public string Answer { get; set; } = "";
	}
}
