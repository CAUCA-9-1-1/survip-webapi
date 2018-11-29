using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.FireSafetyDepartment
{
	public class FirestationService : BaseSecureService<Firestation>
	{
		protected override string BaseUrl { get; set; } = "Firestation/Import";

		public FirestationService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}