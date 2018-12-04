using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class HazardousMaterialService : BaseSecureService<HazardousMaterial>
	{
		protected override string BaseUrl { get; set; } = "HazardousMaterial/Import";

		public HazardousMaterialService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}