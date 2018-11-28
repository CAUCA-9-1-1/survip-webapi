using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Lane
{
	public class LanePublicCodeService : BaseSecureService<LanePublicCode>
	{
		protected override string BaseUrl { get; set; } = "LanePublicCode/Import";
	}    
}