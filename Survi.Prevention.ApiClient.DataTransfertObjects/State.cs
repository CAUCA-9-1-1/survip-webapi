using Survi.Prevention.ApiClient.DataTransferObjects.Base;

namespace Survi.Prevention.ApiClient.DataTransferObjects
{
    public class State : BaseLocalizableTransferObject
    {
        public string AnsiCode { get; set; }
        public string IdCountry { get; set; }
    }
}