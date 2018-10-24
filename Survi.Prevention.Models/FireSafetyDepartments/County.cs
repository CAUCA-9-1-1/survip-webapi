using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class County : BaseImportedModel
	{
		public Guid IdRegion { get; set; }
		public Guid IdState { get; set; }

		public Region Region { get; set; }
		public State State { get; set; }

		public ICollection<City> Cities { get; set; }
		public ICollection<FireSafetyDepartment> FireSafetyDepartments { get; set; }
		public ICollection<CountyLocalization> Localizations { get; set; }
	}
}
