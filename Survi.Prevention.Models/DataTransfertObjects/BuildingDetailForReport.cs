using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingDetailForReport
	{
		public Guid Id { get; set; }
		public string BuildingType { get; set; }
		public string GarageTypeLocalized { get; set; }
		public decimal BuildingHeight { get; set; }
		public int EstimatedWaterFlow { get; set; }
		public string ConstructionTypeLocalized { get; set; }
		public string ConstructionFireResistanceLocalized { get; set; }
		public string ConstructionSidingLocalized { get; set; }
		public string RoofTypeLocalized { get; set; }
		public string RoofMaterialLocalized { get; set; }
		public Picture ImplementationPlan { get; set; }
	}
}