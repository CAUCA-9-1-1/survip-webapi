using System.Collections.Generic;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class HazardousMaterial : BaseModel
	{
		public string Number { get; set; }
		public string GuideNumber { get; set; }
		public bool ReactToWater { get; set; }
		public bool ToxicInhalationHazard { get; set; }
		public ICollection<HazardousMaterialLocalization> Localizations { get; set; }
	}
}
