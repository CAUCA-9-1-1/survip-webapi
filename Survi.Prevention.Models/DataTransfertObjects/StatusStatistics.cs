using System;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class StatusStatistics
    {
        public int OwnerWasAbsent { get; set; }
        public int DoorHangerHasBeenLeft { get; set; }
        public int InspectionRefused { get; set; }
        public int Success { get; set; }

    }
}