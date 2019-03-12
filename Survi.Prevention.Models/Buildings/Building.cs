using System.Collections.Generic;
using Survi.Prevention.Models.Buildings.Base;

namespace Survi.Prevention.Models.Buildings
{
	public enum BuildingChildType
	{
		None,
		Child
	}

	public class Building : BaseBuilding
	{		
		public BuildingDetail Detail { get; set; }
		public Building Parent { get; set; }
		public Picture Picture { get; set; }

		public ICollection<BuildingContact> Contacts { get; set; }
		public ICollection<BuildingHazardousMaterial> HazardousMaterials { get; set; }
		public ICollection<BuildingPersonRequiringAssistance> PersonsRequiringAssistance { get; set; }
		public ICollection<BuildingCourse> Courses { get; set; }
		public ICollection<BuildingFireHydrant> FireHydrants { get; set; }
		public ICollection<BuildingAlarmPanel> AlarmPanels { get; set; }
		public ICollection<BuildingSprinkler> Sprinklers { get; set; }
		public ICollection<Building> Children { get; set; }
		public ICollection<BuildingAnomaly> Anomalies { get; set; }
		public ICollection<BuildingParticularRisk> ParticularRisks { get; set; }
	}
}