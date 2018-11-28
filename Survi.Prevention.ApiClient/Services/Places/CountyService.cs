using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class CountyService : BaseSecureService<County>
	{
		protected override string BaseUrl { get; set; } = "County/Import";
	}    
}
