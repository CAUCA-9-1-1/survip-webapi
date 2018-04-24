using System;
using System.Collections.Generic;
using NpgsqlTypes;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings
{
	public enum BuildingChildType
	{
		None,
		Child
	}

	public class Building : BaseModel
	{
		public string CivicNumber { get; set; }
		public string CivicLetter { get; set; }
		public string CivicSupp { get; set; }
		public string CivicLetterSupp { get; set; }
		public string AppartmentNumber { get; set; }
		public string Floor { get; set; }
		public int NumberOfFloor { get; set; }
		public int NumberOfAppartment { get; set; }
		public int NumberOfBuilding { get; set; }
		public bool VacantLand { get; set; }
		public int YearOfConstruction { get; set; }
		public decimal BuildingValue { get; set; }
		public string PostalCode { get; set; }
		public int Suite { get; set; }
		public string Source { get; set; }
		public bool IsParent { get; set; }
		public string UtilisationDescription { get; set; }
		public bool ShowInResources { get; set; }
		public string Matricule { get; set; }
		public /*PostgisGeometry*/string Coordinates { get; set; }
		public string CoordinatesSource { get; set; }
		public string Details { get; set; }
		public BuildingChildType ChildType { get; set; }

		public Guid IdLane { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid? IdUtilisationCode { get; set; }
		public Guid IdRiskLevel { get; set; }
		public Guid? IdParentBuilding { get; set; }
		public Guid? IdPicture { get; set; }		
		
		public RiskLevel RiskLevel { get; set; }
		public UtilisationCode UtilisationCode { get; set; }
		public Lane Lane { get; set; }
		public Lane Transversal { get; set; }
		public Building Parent { get; set; }
		public Picture Picture { get; set; }
		public BuildingDetail Detail { get; set; }		

		public ICollection<BuildingContact> Contacts { get; set; }
		public ICollection<BuildingHazardousMaterial> HazardousMaterials { get; set; }
		public ICollection<BuildingPersonRequiringAssistance> PersonsRequiringAssistance { get; set; }
		public ICollection<BuildingLocalization> Localizations { get; set; }
		public ICollection<BuildingCourse> Courses { get; set; }
		public ICollection<BuildingFireHydrant> FireHydrants { get; set; }
		public ICollection<BuildingAlarmPanel> AlarmPanels { get; set; }
		public ICollection<BuildingSprinkler> Sprinklers { get; set; }
		public ICollection<Building> Children { get; set; }
		public ICollection<BuildingAnomaly> Anomalies { get; set; }
	}
}