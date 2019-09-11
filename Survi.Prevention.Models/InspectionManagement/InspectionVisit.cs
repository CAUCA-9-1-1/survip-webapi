using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Security;
using System;

namespace Survi.Prevention.Models.InspectionManagement
{
	public class InspectionVisit : BaseModel
	{
		public InspectionVisitStatus Status { get; set; }
		public string ReasonForApprobationRefusal { get; set; }
		public string ReasonForInspectionRefusal { get; set; }
		public bool HasBeenRefused { get; set; }
		public bool OwnerWasAbsent { get; set; }
		public bool IsSeasonal { get; set; }
		public bool IsVacant { get; set; }
		public bool DoorHangerHasBeenLeft { get; set; }
		public DateTime? RequestedDateOfVisit { get; set; }
		public DateTime? StartedOn { get; set; }
		public DateTime? EndedOn { get; set; }

		public Guid IdInspection { get; set; }
		public Guid? IdWebuserVisitedBy { get; set; }

		public Inspection Inspection { get; set; }
		public User VisitedBy { get; set; }		
	}
}