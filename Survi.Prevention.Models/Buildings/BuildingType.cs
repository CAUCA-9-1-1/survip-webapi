using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class BuildingType : BaseImportedModel
	{
		public ICollection<BuildingTypeLocalization> Localizations { get; set; }
	}
}