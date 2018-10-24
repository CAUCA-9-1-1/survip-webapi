using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireHydrants
{
	public class FireHydrantType : BaseImportedModel
	{
		public ICollection<FireHydrantTypeLocalization> Localizations { get; set; }
	}
}
