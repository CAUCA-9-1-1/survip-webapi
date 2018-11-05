using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class AvailableBuildingForManagement
	{
		public Guid IdBuilding { get; set; }
		public Guid IdRiskLevel { get; set; }
		public Guid IdCity { get; set; }
		public string Matricule { get; set; }
		public string FullCivicNumber { get; set; }
		public string FullCivicNumberSortable { get; set; }
		public string FullLaneName { get; set; }
		public string CityName { get; set; }
		public string RiskLevel { get; set; }
		public string LanguageCode { get; set; }
	}
}