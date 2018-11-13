using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingAlarmPanel : BaseTransferObject
    {
        public string Floor { get; set; }
        public string Wall { get; set; }
        public string Sector { get; set; }

        public string IdAlarmPanelType { get; set; }
        public string IdBuilding { get; set; }
    }
}