using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingAnomalyPictureService : BaseSecureService<DataTransferObjects.BuildingAnomalyPicture>
	{
		protected override string BaseUrl { get; set; } = "Building/Anomaly/Picture/Import";

		public BuildingAnomalyPictureService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}