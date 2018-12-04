using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class LanePublicCodeService : BaseSecureService<LanePublicCode>
	{
		protected override string BaseUrl { get; set; } = "LanePublicCode/Import";

		public LanePublicCodeService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}