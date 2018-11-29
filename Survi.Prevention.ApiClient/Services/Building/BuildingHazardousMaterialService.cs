using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingHazardousMaterialService : BaseSecureService<BuildingHazardousMaterial>
	{
		protected override string BaseUrl { get; set; } = "building/hazardousmaterial/Import";

		public BuildingHazardousMaterialService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}