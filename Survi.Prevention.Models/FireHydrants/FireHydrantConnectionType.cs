using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireHydrants
{
	public class FireHydrantConnectionType : BaseModel
	{
		public ICollection<FireHydrantConnectionTypeLocalization> Localizations { get; set; }
	}
}
