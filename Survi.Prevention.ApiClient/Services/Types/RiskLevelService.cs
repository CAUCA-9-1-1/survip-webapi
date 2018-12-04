using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class RiskLevelService : BaseSecureService<RiskLevel>
	{
		protected override string BaseUrl { get; set; } = "RiskLevel/Import";

		public RiskLevelService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}