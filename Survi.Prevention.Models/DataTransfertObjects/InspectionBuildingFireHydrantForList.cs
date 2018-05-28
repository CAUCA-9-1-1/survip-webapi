using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingFireHydrantForList
	{
		public Guid Id { get; set; }
		public Guid IdInspection { get; set; }
		public string Color { get; set; }
		public string Number { get; set; }
		public string Address { get; set; }
	}
}