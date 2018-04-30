using System;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InspectionVisit : BaseModel
	{
		public DateTime AnsweredOn { get; set; }
		public InspectionVisitStatus Status { get; set; }
		public string ReasonForRefusal { get; set; }
		public bool IsSeasonal { get; set; }
		public bool IsVacant { get; set; }
		public bool DoorHangerHasBeenLeft { get; set; }
		public DateTime? StartedOn { get; set; }
		public DateTime? CompletedOn { get; set; }

		public Guid IdInspection { get; set; }
		public Guid? IdWebuserVisitedBy { get; set; }

		public Inspection Inspection { get; set; }
		public Webuser VisitedBy { get; set; }		
	}
}