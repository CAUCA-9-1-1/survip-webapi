using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionSurveyCompletion
    {
		public Guid idInspection { get; set; }
		public bool isCompleted { get; set; }
    }
}
