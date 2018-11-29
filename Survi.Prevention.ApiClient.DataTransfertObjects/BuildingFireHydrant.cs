using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingFireHydrant : BaseTransferObject
    {
        public string IdBuilding { get; set; }
        public string IdFireHydrant { get; set; }
    }
}