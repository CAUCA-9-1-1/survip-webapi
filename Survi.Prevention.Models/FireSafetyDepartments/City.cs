using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;
using Survi.Prevention.Models.Buildings;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class City : BaseModel
	{
		public string Code { get; set; }
		public string Code3Letters { get; set; }
		public string EmailAddress { get; set; }

		public Guid? IdBuilding { get; set; }
		public Guid IdCityType { get; set; }
		public Guid IdCounty { get; set; }
		public Guid IdLanguageContentName { get; set; }

		public Building Building { get; set; }
		public CityType CityType { get; set; }
		public County County { get; set; }

		public ICollection<FireSafetyDeparmentServing> ServedByFireSafetyDeparments { get; set; }
	}
}
