using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingParticularRisk : BaseTransferObject
    {
        public ParticularRiskType RiskType { get; set; }
        public string IdBuilding { get; set; }
        public bool IsWeakened { get; set; }
        public bool HasOpening { get; set; }
        public string Comments { get; set; } = "";
        public string Wall { get; set; }
        public string Sector { get; set; }
        public string Dimension { get; set; } = "";
    }
}