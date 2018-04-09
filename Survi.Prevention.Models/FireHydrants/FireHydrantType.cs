using System;
using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.FireHydrants
{
	public class FireHydrantType : BaseModel
	{
		public ICollection<FireHydrantTypeLocalization> Localizations { get; set; }
	}
}
