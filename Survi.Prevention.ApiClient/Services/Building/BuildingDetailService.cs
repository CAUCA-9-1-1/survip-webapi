using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingDetailService : BaseSecureService<BuildingDetail>
	{
		protected override string BaseUrl { get; set; } = "Building/Detail/Import";

		public BuildingDetailService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}