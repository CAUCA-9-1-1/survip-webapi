using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class City : BaseImportedModel
	{
		public string Code { get; set; }
		public string Code3Letters { get; set; }
		public string EmailAddress { get; set; } = "";

		public Guid IdCityType { get; set; }
		public Guid IdCounty { get; set; }

		public CityType CityType { get; set; }
		public County County { get; set; }

		public ICollection<FireSafetyDepartmentCityServing> ServedByFireSafetyDepartments { get; set; }
		public ICollection<Lane> Lanes { get; set; }
		public ICollection<CityLocalization> Localizations { get; set; }
	}
}
