using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingParticularRiskService : BaseSecureService<BuildingParticularRisk>
	{
		protected override string BaseUrl { get; set; } = "Building/ParticularRisk/Import";

		public BuildingParticularRiskService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}