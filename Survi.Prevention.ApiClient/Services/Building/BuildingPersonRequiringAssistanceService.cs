using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingPersonRequiringAssistanceService : BaseSecureService<BuildingPersonRequiringAssistance>
	{
		protected override string BaseUrl { get; set; } = "building/pnaps/Import";

		public BuildingPersonRequiringAssistanceService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}