using System;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.DataTransfertObjects.Reporting
{
	public class BuildingForReport : IDataTransferObjectWithId
	{
		public Guid Id { get; set; }
		public Guid? IdParentBuilding { get; set; }

		public string CivicNumber { get; set; }
		public string CivicLetter { get; set; }
		public string CivicSupp { get; set; }
		public string CivicLetterSupp { get; set; }
		public string AppartmentNumber { get; set; }
		public string FullLaneName { get; set; }		
		public string PostalCode { get; set; }
		public decimal BuildingValue { get; set; }
		public int YearOfConstruction { get; set; }

		public string OwnerName { get; set; }
		public string FullTransversalLaneName { get; set; }
		public string RiskLevel { get; set; }
		public string UtilisationCode { get; set; }
		public string Matricule { get; set; }
		public string Name { get; set; }

		public string CityName { get; set; }
		public string CountyName { get; set; }
		public string StateCode { get; set; }
		public string CountryName { get; set; }

		public string LanguageCode { get; set; }
		public BuildingChildType ChildType { get; set; }
	}
}