using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingAlarmPanelService : BaseSecureService<DataTransferObjects.BuildingAlarmPanel>
	{
		protected override string BaseUrl { get; set; } = "Building/AlarmPanel/Import";

		public BuildingAlarmPanelService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}