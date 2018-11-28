using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class RoofMaterialTypeService : BaseSecureService<RoofMaterialType>
	{
		protected override string BaseUrl { get; set; } = "Construction/RoofMaterialType/Import";
	}    
}