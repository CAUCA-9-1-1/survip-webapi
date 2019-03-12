using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class InspectionBuildingForList
	{
		public Guid Id { get; set; }
		public Guid IdInspection { get; set; }
        public bool IsParent { get; set; }
        public string AliasName { get; set; }
        public string CorporateName { get; set; }
		public string Picture { get; set; }
	}
}