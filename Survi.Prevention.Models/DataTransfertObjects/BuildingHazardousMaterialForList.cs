using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingHazardousMaterialForList
	{
		public Guid Id { get; set; }
		public string HazardousMaterialNumber { get; set; }
		public string HazardousMaterialName { get; set; }
		public string QuantityDescription { get; set; }
	}
}