using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class SidingType : BaseModel
	{
		public ICollection<SidingTypeLocalization> Localizations { get; set; }
	}
}