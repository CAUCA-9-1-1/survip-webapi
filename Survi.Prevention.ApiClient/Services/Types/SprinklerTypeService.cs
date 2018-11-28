using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class SprinklerTypeService : BaseSecureService<SprinklerType>
	{
		protected override string BaseUrl { get; set; } = "SprinklerType/Import";
	}    
}