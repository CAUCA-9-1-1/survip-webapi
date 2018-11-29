using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
	public class BuildingContactService : BaseSecureService<BuildingContact>
	{
		protected override string BaseUrl { get; set; } = "building/contact/Import";

		public BuildingContactService(IConfiguration configuration) : base(configuration)
		{
		}
	}    
}