using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireHydrant
{
	public class FireHydrantTypeService : BaseSecureService<DataTransferObjects.FireHydrantType>
	{
		protected override string BaseUrl { get; set; } = "FireHydrantType/Import";

		public FireHydrantTypeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}