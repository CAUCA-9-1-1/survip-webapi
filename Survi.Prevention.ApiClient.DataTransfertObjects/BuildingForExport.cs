using Survi.Prevention.ApiClient.DataTransferObjects.Base;
using System;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
   public class BuidldingForExport: BaseTransferObject
    {
        public Guid IdBuilding { get; set; }
        public Guid IdCity { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string IdBuildingExtern { get; set; }
    }
}
