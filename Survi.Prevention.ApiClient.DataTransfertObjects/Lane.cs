using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class Lane : BaseLocalizableTransferObject
    {
        public string IdPublicCode { get; set; }
        public string IdLaneGenericCode { get; set; }
        public string IdCity { get; set; }
    }
}