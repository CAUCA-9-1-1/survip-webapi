using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireHydrant
{
	public class FireHydrantConnectionService : BaseSecureService<FireHydrantConnection>
	{
		protected override string BaseUrl { get; set; } = "FireHydrant/Connection/Import";

		public FireHydrantConnectionService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
