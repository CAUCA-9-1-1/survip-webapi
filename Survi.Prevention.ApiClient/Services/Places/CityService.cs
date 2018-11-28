using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class CityService : BaseSecureService<City>
	{
		protected override string BaseUrl { get; set; } = "City/Import";
	}    
}
