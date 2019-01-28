using System;
using System.Collections.Generic;
using Survi.Prevention.Models.InspectionManagement;

namespace Survi.Prevention.Models.DataTransfertObjects.Inspections
{
    public class InspectionWithBuildings
    {
        public Guid Id { get; set; }
        public List<InspectionBuildingResume> Buildings { get; set; }
        public InspectionConfiguration Configuration { get; set; }
        public Guid? IdSurvey { get; set; }
        public bool IsSurveyCompleted { get; set; }
        public InspectionStatus Status { get; set; }
    }

    public class InspectionBuildingResume
    {
        public Guid IdBuilding { get; set; }
        public string Name { get; set; }
        public bool IsMainBuilding { get; set; }
        public string Coordinates { get; set; }
        public Guid? IdLaneTransversal { get; set; }
    }
}
