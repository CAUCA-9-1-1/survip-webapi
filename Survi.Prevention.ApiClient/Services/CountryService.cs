using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services
{
    public class CountryService : BaseSecureService<Country>
    {
        protected override string BaseUrl { get; set; } = "Country/Import";
    }

    
}
