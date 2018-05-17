using System;
using System.Collections.Generic;
using System.Text;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionSummaryCategoryForList
    {
		public string Title { get; set; } = "";
		public List<InspectionQuestionForSummary> AnswerSummary { get; set; }
	}
}
