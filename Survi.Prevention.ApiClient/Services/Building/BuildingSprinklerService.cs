using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingSprinklerService : BaseSecureService<DataTransferObjects.BuildingSprinkler>
	{
		protected override string BaseUrl { get; set; } = "Building/Sprinklers/Import";

		public BuildingSprinklerService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}