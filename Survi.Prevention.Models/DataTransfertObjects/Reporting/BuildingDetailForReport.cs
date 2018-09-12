using System;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.DataTransfertObjects.Reporting
{
	public class BuildingDetailForReport : IDataTransferObjectWithId
	{
		public Guid Id { get; set; }
		public Guid IdBuilding { get; set; }

		public decimal Height { get; set; }
		public GarageType GarageType { get; set; }
		public decimal EstimatedWaterFlow { get; set; }
		public string BuildingType { get; set; }				
		public string ConstructionType { get; set; }
		public string ConstructionFireResistanceType { get; set; }
		public string SidingType { get; set; }
		public string RoofType { get; set; }
		public string RoofMaterialType { get; set; }
		public string EstimatedWaterFlowUnit { get; set; }
		public string HeightUnit { get; set; }

		public string LanguageCode { get; set; }
	}
}