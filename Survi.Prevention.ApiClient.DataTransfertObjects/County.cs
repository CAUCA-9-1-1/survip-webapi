using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class County : BaseLocalizableTransferObject
    {
        public string IdRegion { get; set; }
        public string IdState { get; set; }
    }
}