using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
    public class BuildingFireHydrantService : BaseSecureService<DataTransferObjects.BuildingFireHydrant>
    {
        protected override string BaseUrl { get; set; } = "Building/FireHydrant/Import";

        public BuildingFireHydrantService(IConfiguration configuration) : base(configuration)
        {
        }        
    }
}