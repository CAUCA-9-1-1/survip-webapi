using System;

namespace Survi.Prevention.Models.DataTransfertObjects
{
    public class CityLocalized
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string RegionName { get; set; }
		public string CountyName { get; set; }
    }
}
