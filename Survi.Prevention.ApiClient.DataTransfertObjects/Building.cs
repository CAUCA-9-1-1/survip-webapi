using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
	public class Building : BaseLocalizableTransferObjectWithPicture
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
		public string UtilisationDescription { get; set; }
		public bool ShowInResources { get; set; }
		public string Matricule { get; set; }

		public string WktCoordinates { get; set; }
		public string CoordinatesSource { get; set; }
		public string Details { get; set; }

		public BuildingChildType ChildType { get; set; }

		public string IdCity { get; set; }
		public string IdLane { get; set; }
		public string IdLaneTransversal { get; set; }
		public string IdUtilisationCode { get; set; }
		public string IdRiskLevel { get; set; }
		public string IdParentBuilding { get; set; }
	}
}