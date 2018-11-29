using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireSafetyDepartment
{
	public class FireSafetyDepartmentCityServingService : BaseSecureService<DataTransferObjects.FireSafetyDepartmentCityServing>
	{
		protected override string BaseUrl { get; set; } = "FireSafetyDepartment/CityServing/Import";

		public FireSafetyDepartmentCityServingService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}