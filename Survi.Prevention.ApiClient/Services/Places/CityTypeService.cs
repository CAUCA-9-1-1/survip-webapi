using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class CityTypeService : BaseSecureService<CityType>
	{
		protected override string BaseUrl { get; set; } = "CityType/Import";
	}    
}