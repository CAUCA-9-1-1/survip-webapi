using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingGeneralInformationForReport
	{
		public string Alias { get; set; }
		public Guid IdInspection { get; set; }
		public Guid IdBuilding { get; set; }
		public string RiskCategory { get; set; }
		public string Matricule { get; set; }
		public string ZipCode { get; set; }
		public string Lane { get; set; }
		public string Address { get; set; }
		public string Assignment { get; set; }
	}
}