using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class ConstructionFireResistanceType : BaseModel
	{
		public ICollection<ConstructionFireResistanceTypeLocalization> Localizations { get; set; }
	}
}