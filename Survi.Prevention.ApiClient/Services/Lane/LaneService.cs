using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Lane
{
	public class LaneService : BaseSecureService<DataTransferObjects.Lane>
	{
		protected override string BaseUrl { get; set; } = "Lane/Import";
	}    
}
