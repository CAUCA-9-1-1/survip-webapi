using System;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionForStatistics
    {
        public Guid Id { get; set; }
        public InspectionStatus Status { get; set; }
        public string ApprobationRefusalReason { get; set; }
        public DateTime? InspectionOn { get; set; }
    }
}