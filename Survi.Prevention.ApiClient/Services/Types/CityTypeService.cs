using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class CityTypeService : BaseSecureService<CityType>
	{
		protected override string BaseUrl { get; set; } = "CityType/Import";

		public CityTypeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}