using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class ConstructionFireResistanceTypeService : BaseSecureService<ConstructionFireResistanceType>
	{
		protected override string BaseUrl { get; set; } = "Construction/ConstructionFireResistanceType/Import";

	    public ConstructionFireResistanceTypeService(IConfiguration configuration) : base(configuration)
	    {
	    }
	}    
}