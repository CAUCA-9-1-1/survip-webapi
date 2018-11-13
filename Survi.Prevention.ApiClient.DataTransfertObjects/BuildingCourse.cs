using System.Collections.Generic;
using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class BuildingCourse : BaseTransferObject
    {
        public string IdBuilding { get; set; }
        public string IdFirestation { get; set; }
        public List<BuildingCourseLane> Lanes { get; set; }
    }
}