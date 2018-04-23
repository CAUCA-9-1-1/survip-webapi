using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class ConstructionType : BaseModel
	{
		public ICollection<ConstructionTypeLocalization> Localizations { get; set; }
	}
}
