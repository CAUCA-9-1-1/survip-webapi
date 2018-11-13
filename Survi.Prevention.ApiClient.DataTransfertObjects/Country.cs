using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class Country : BaseLocalizableTransferObject
    {
        public string CodeAlpha2 { get; set; }
        public string CodeAlpha3 { get; set; }        
    }
}
