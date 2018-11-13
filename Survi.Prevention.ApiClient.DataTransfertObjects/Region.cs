using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class Region : BaseLocalizableTransferObject
    {
        public string Code { get; set; }
        public string IdState { get; set; }
    }
}