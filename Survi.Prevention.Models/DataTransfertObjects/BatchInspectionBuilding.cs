using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class BatchInspectionBuilding
    {
		public Guid IdInspection { get; set; }
		public Guid IdBatch { get; set; }
		public Guid IdBuilding { get; set; }
		public Guid? IdWebuserAssignedTo { get; set; }
		public Guid IdWebuserCreatedBy { get; set; }
		public Guid IdRiskLevel { get; set; }
		public int Sequence { get; set; }
		public string Matricule { get; set; }
		public string FullCivicNumber { get; set; }
		public string FullCivicNumberSortable { get; set; }
		public string FullLaneName { get; set; }
		public string CityName { get; set; }
		public string RiskLevel { get; set; }
		public string LanguageCode { get; set; }
		public int InspectionStatus { get; set; }
        public bool HasBeenDownloaded { get; set; }
    }
}
