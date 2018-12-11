
using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.SecurityManagement;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class GeneralConfigurationService: BaseService
    {
        public GeneralConfigurationService(IManagementContext context) : base(context)
        {
        }

        public GeneralConfiguration GetGeneralConfiguration()
        {
            return new GeneralConfiguration();
        }
    }
}
