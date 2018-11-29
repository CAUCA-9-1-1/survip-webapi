using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class SidingTypeService : BaseSecureService<SidingType>
	{
		protected override string BaseUrl { get; set; } = "Construction/SidingType/Import";

	    public SidingTypeService(IConfiguration configuration) : base(configuration)
	    {
	    }
	}    
}