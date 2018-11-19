using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingAnomaly : BaseTransferObject
    {
        public string Theme { get; set; }
        public string Notes { get; set; }

        public string IdBuilding { get; set; }
    }
}