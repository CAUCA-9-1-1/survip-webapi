using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class SprinklerType : BaseModel
	{
		public ICollection<SprinklerTypeLocalization> Localizations { get; set; }
	}
}