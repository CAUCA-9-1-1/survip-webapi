using System;
using System.Collections.Generic;

namespace Survi.Prevention.Models.DataTransfertObjects.Inspections
{
    public class InspectionWithBuildings
    {
        public Guid Id { get; set; }
        public List<InspectionBuildingResume> Buildings { get; set; }
    }

    public class InspectionBuildingResume
    {
        public Guid IdBuilding { get; set; }
        public string Name { get; set; }
        public bool IsMainBuilding { get; set; }
    }
}
