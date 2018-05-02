using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
	public class BuildingForWeb
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
        public string CivicNumber { get; set; }
        public string Lane { get; set; }
        public string City { get; set; }
        public string RiskLevel { get; set; }
    }
}