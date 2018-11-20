using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class State : BaseLocalizableImportedModel<StateLocalization>
	{
		public string AnsiCode { get; set; }
		public Guid IdCountry { get; set; }

		public Country Country { get; set; }

		public ICollection<County> Counties { get; set; }
		public ICollection<Region> Regions { get; set; }
	}
}
