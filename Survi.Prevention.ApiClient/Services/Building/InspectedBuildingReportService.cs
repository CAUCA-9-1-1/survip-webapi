
using Survi.Prevention.ApiClient.Configurations;
using Survi.Prevention.ApiClient.Services.Base;

namespace Survi.Prevention.ApiClient.Services.Building
{
    public class InspectedBuildingReportService : BaseSecureService<DataTransferObjects.InpectedBuildingReportForExport>
    {
        protected override string BaseUrl { get; set; } = "ReportGeneration/Import";

        public InspectedBuildingReportService(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
