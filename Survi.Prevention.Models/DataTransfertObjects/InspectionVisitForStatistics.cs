using System;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionVisitForStatistics
    {
        public Guid Id { get; set; }
        public InspectionVisitStatus Status { get; set; }
        public int RiskLevel { get; set; }
        public Guid IdFireSafetyDepartment { get; set; }
        public DateTime? CompletedOn { get; set; }
        public Boolean HasBeenRefused { get; set; }
        public Boolean OwnerWasAbsent { get; set; }
        public Boolean DoorHangerHasBeenLeft { get; set; }
    }
}
