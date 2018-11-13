using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingCourseLane : BaseTransferObject
    {
        public string IdLane { get; set; }
        public string IdBuildingCourse { get; set; }

        public CourseLaneDirection Direction { get; set; }
        public int Sequence { get; set; }    
    }
}