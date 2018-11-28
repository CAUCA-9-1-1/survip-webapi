using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class RoofTypeService : BaseSecureService<RoofType>
	{
		protected override string BaseUrl { get; set; } = "Construction/RoofType/Import";
	}    
}