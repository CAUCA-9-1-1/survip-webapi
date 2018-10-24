using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireSafetyDepartments
{
	public class CityType : BaseImportedModel
	{
		public ICollection<CityTypeLocalization> Localizations { get; set; }
	}
}
