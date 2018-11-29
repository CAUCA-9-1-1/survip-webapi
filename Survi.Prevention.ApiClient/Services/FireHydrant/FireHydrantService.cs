using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireHydrant
{
	public class FireHydrantService : BaseSecureService<DataTransferObjects.FireHydrant>
	{
		protected override string BaseUrl { get; set; } = "FireHydrant/Import";

		public FireHydrantService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
