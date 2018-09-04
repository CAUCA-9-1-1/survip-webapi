using System;

namespace Survi.Prevention.Models.DataTransfertObjects.Reporting
{
	public class InspectionForReport
	{
		public Guid Id { get; set; }

		public DateTime? StartedOn { get; set; }
		public DateTime? EndedOn { get; set; }

		public string InspectorName { get; set; }
	}
}
