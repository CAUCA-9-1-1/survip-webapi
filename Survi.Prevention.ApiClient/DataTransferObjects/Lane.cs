using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class Lane : BaseLocalizableTransferObject
    {
        public bool IsValid { get; set; }

        public string IdPublicCode { get; set; }
        public string IdLaneGenericCode { get; set; }
        public string IdCity { get; set; }
    }
}