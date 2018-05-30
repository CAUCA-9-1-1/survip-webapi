using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingForList
	{
		public Guid Id { get; set; }
		public Guid IdInspection { get; set; }
        public Boolean IsParent { get; set; }
        public string Name { get; set; }
		public string Picture { get; set; }
	}
}