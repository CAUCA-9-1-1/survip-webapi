using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services
{
    public class InspectionBuildingService : BaseSecureService<DataTransferObjects.BuidldingForExport>
    {
        protected override string BaseUrl { get; set; } = "inspection/Building/Import";

        public InspectionBuildingService(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
