using System;
using Newtonsoft.Json;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.FireSafetyDepartments;

namespace Survi.Prevention.Models.Buildings.Base
{
	public class BaseBuilding : BaseModel
	{
		private NetTopologySuitePointWrapper wrapper;

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
		public string UtilisationDescription { get; set; }
		public bool ShowInResources { get; set; }
		public string Matricule { get; set; }

		[JsonIgnore]
		public NetTopologySuite.Geometries.Point PointCoordinates { get => wrapper; set => wrapper = value; }

		public string Coordinates { get => wrapper; set => wrapper = value; }

		public string CoordinatesSource { get; set; }
		public string Details { get; set; }
		public BuildingChildType ChildType { get; set; }

		public Guid IdCity { get; set; }
		public Guid IdLane { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid? IdUtilisationCode { get; set; }
		public Guid IdRiskLevel { get; set; }
		public Guid? IdParentBuilding { get; set; }
		public Guid? IdPicture { get; set; }

		public RiskLevel RiskLevel { get; set; }
		public UtilisationCode UtilisationCode { get; set; }
		public City City { get; set; }
		public Lane Lane { get; set; }
		public Lane Transversal { get; set; }
		public Building Parent { get; set; }
		public Picture Picture { get; set; }
	}
}