using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionSummaryCategoryForList
    {
		public string Title { get; set; } = "";
		public List<InspectionQuestionForSummary> AnswerSummary { get; set; }
	}
}
