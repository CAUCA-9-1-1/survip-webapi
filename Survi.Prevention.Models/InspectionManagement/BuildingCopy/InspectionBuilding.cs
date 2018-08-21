using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.InspectionManagement.BuildingCopy
{
	public class InspectionBuilding : BaseBuilding
	{
		public Guid IdInspection;

		public Inspection Inspection { get; set; }
		public InspectionBuildingDetail Detail { get; set; }
		public InspectionBuilding Parent { get; set; }

		public ICollection<InspectionBuildingContact> Contacts { get; set; }
		public ICollection<InspectionBuildingHazardousMaterial> HazardousMaterials { get; set; }
		public ICollection<InspectionBuildingPersonRequiringAssistance> PersonsRequiringAssistance { get; set; }
		public ICollection<InspectionBuildingLocalization> Localizations { get; set; }
		public ICollection<InspectionBuildingCourse> Courses { get; set; }
		public ICollection<InspectionBuildingFireHydrant> FireHydrants { get; set; }
		public ICollection<InspectionBuildingAlarmPanel> AlarmPanels { get; set; }
		public ICollection<InspectionBuildingSprinkler> Sprinklers { get; set; }
		public ICollection<InspectionBuilding> Children { get; set; }
		public ICollection<InspectionBuildingAnomaly> Anomalies { get; set; }
		public ICollection<InspectionBuildingParticularRisk> ParticularRisks { get; set; }
	}
}