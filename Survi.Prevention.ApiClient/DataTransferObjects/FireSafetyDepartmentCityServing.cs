using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class FireSafetyDepartmentCityServing : BaseTransferObject
    {
        public string IdFireSafetyDepartment { get; set; }
        public string IdCity { get; set; }
    }
}