using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Places
{
	public class RegionService : BaseSecureService<Region>
	{
		protected override string BaseUrl { get; set; } = "Region/Import";

		public RegionService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
