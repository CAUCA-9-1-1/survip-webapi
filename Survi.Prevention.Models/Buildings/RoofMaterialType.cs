using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class RoofMaterialType : BaseModel
	{
		public ICollection<RoofMaterialTypeLocalization> Localizations { get; set; }
	}
}