using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingService : BaseSecureService<DataTransferObjects.Building>
	{
		protected override string BaseUrl { get; set; } = "Building/Import";

		public BuildingService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}