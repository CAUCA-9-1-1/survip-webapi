using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireSafetyDepartment
{
	public class FireSafetyDepartmentService : BaseSecureService<DataTransferObjects.FireSafetyDepartment>
	{
		protected override string BaseUrl { get; set; } = "FireSafetyDepartment/Import";

		public FireSafetyDepartmentService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}