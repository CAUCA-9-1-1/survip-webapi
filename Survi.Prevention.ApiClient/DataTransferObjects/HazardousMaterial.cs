using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class HazardousMaterial : BaseLocalizableTransferObject
    {
        public string Number { get; set; }
        public string GuideNumber { get; set; }
        public bool ReactToWater { get; set; }
        public bool ToxicInhalationHazard { get; set; }
    }
}