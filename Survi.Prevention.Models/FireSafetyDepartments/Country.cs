using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class Country : BaseLocalizableImportedModel<CountryLocalization>
	{
		public string CodeAlpha2 { get; set; }
		public string CodeAlpha3 { get; set; }

		public ICollection<State> States { get; set; }
	}
}
