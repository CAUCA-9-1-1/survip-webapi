using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingSprinkler : BaseTransferObject
    {
        public string Floor { get; set; }
        public string Wall { get; set; }
        public string Sector { get; set; }
        public string PipeLocation { get; set; }
        public string CollectorLocation { get; set; }

        public string IdBuilding { get; set; }
        public string IdSprinklerType { get; set; }
    }
}