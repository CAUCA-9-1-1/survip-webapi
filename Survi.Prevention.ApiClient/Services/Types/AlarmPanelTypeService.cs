using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Types
{
	public class AlarmPanelTypeService : BaseSecureService<AlarmPanelType>
	{
		protected override string BaseUrl { get; set; } = "AlarmPanelType/Import";

	    public AlarmPanelTypeService(IConfiguration configuration) : base(configuration)
	    {
	    }
	}    
}