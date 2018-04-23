using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingSidingType : BaseModel
	{
		public ICollection<BuildingSidingTypeLocalization> Localizations { get; set; }
	}
}