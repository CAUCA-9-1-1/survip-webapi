using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class RegionService : BaseSecureService<Region>
	{
		protected override string BaseUrl { get; set; } = "Region/Import";
	}    
}
