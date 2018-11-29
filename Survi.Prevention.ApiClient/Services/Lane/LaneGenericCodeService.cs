using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Lane
{
	public class LaneGenericCodeService : BaseSecureService<LaneGenericCode>
	{
		protected override string BaseUrl { get; set; } = "LaneGenericCode/Import";

		public LaneGenericCodeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}
