using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class County : BaseLocalizableImportedModel<CountyLocalization>
	{
		public Guid IdRegion { get; set; }

		public Region Region { get; set; }

		public ICollection<City> Cities { get; set; }
		public ICollection<FireSafetyDepartment> FireSafetyDepartments { get; set; }
	}
}
