using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireHydrant
{
	public class FireHydrantConnectionTypeService : BaseSecureService<FireHydrantConnectionType>
	{
		protected override string BaseUrl { get; set; } = "FireHydrantConnectionType/Import";

		public FireHydrantConnectionTypeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
