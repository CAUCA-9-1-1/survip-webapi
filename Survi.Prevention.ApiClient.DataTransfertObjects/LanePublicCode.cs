using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class LanePublicCode : BaseTransferObject
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
    }
}