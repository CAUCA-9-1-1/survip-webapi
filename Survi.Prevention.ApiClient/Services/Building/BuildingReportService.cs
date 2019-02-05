using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
    public class BuildingReportService : BaseSecureService<DataTransferObjects.BuildingReportForExport>
    {
        protected override string BaseUrl { get; set; } = "ReportGeneration/Import";

        public BuildingReportService(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
