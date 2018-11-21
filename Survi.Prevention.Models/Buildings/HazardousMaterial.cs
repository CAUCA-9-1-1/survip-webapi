using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models.Buildings
{
	public class HazardousMaterial : BaseLocalizableImportedModel<HazardousMaterialLocalization>
	{
		public string Number { get; set; }
		public string GuideNumber { get; set; }
		public bool ReactToWater { get; set; }
		public bool ToxicInhalationHazard { get; set; }
	}
}
