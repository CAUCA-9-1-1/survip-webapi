using Survi.Prevention.Models.InspectionManagement;
using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class InspectionForDashboard
    {
		public Guid Id { get; set; }
        public Guid? IdRiskLevel { get; set; }
        public string Address { get; set; }
        public string WebuserAssignedTo { get; set; }
        public Guid? IdWebuserAssignedTo { get; set; }
        public Guid IdBatch { get; set; }
        public string BatchDescription { get; set; }
        public DateTime? ShouldStartOn { get; set; }
        public Boolean IsReadyForInspection { get; set; }
        public InspectionStatus InspectionStatus { get; set; }
        public Boolean HasVisitNote { get; set; }
        public Boolean HasAnomaly { get; set; }
        public DateTime LastInspectionOn { get; set; }
        public Guid IdBuilding { get; set; }
        public Guid? IdLaneTransversal { get; set; }
        public Guid IdCity { get; set; }
        public string PostalCode { get; set; }
        public string Contact { get; set; }
        public string Owner { get; set; }
        public string Matricule { get; set; }
        public Guid? IdUtilisationCode { get; set; }
        public Guid? IdPicture { get; set; }
        public decimal BuildingValue { get; set; }
        public int NumberOfAppartment { get; set; }
        public int NumberOfBuilding { get; set; }
        public int NumberOfFloor { get; set; }
        public Boolean VacantLand { get; set; }
        public int YearOfConstruction { get; set; }
        public string Details { get; set; }
    }

	public class BuildingForDashboard
	{
		public Guid Id { get; set; }
		public Guid? IdRiskLevel { get; set; }

		public string FullLaneName { get; set; }
		public string FullCivicNumber { get;set; }

		/*public string BuildingCivicNumber { get; set; }
		public string BuildingCivicLetter { get; set; }
		public string LaneName { get; set; }
		public string LanePublicDescription { get; set; }
		public string LaneGenericDescription { get; set; }
		public bool LaneAddWhiteSpaceAfterGenericDescription { get; set; }*/

		public string WebuserAssignedTo { get; set; }
		public Guid? IdWebuserAssignedTo { get; set; }
		public Guid IdBatch { get; set; }
		public string BatchDescription { get; set; }
		public DateTime? ShouldStartOn { get; set; }
		public Boolean IsReadyForInspection { get; set; }
		public InspectionStatus InspectionStatus { get; set; }
		public Boolean HasVisitNote { get; set; }
		public Boolean HasAnomaly { get; set; }
		public DateTime? LastInspectionOn { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid? IdLaneTransversal { get; set; }
		public Guid IdCity { get; set; }
		public string PostalCode { get; set; }
		public string Contacts { get; set; }
		public string Owner { get; set; }
		public string Matricule { get; set; }
		public Guid? IdUtilisationCode { get; set; }
		public Guid? IdPicture { get; set; }
		public decimal BuildingValue { get; set; }
		public int NumberOfAppartment { get; set; }
		public int NumberOfBuilding { get; set; }
		public int NumberOfFloor { get; set; }
		public Boolean VacantLand { get; set; }
		public int YearOfConstruction { get; set; }
		public string Details { get; set; }
		public string LanguageCode { get; set; }
	}
}
