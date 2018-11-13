using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class LaneGenericCode : BaseTransferObject
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool AddWhiteSpaceAfter { get; set; }
    }
}