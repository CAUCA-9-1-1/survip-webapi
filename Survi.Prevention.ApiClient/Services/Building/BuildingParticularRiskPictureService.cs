using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingParticularRiskPictureService : BaseSecureService<BuildingParticularRiskPicture>
	{
		protected override string BaseUrl { get; set; } = "Building/ParticularRisk/Picture/Import";

		public BuildingParticularRiskPictureService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}