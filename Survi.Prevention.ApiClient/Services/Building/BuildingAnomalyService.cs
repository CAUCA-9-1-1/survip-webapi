using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingAnomalyService : BaseSecureService<DataTransferObjects.BuildingAnomaly>
	{
		protected override string BaseUrl { get; set; } = "Building/Anomaly/Import";

		public BuildingAnomalyService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}