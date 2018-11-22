using Survi.Prevention.DataLayer;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Import.Base;

namespace Survi.Prevention.ServiceLayer.Services
{
    public class FireHydrantConnectionService 
        : BaseCrudServiceWithImportation<FireHydrantConnection, ApiClient.DataTransferObjects.FireHydrantConnection>
    {
        public FireHydrantConnectionService(
            IManagementContext context, 
            IEntityConverter<ApiClient.DataTransferObjects.FireHydrantConnection, FireHydrantConnection> converter) 
            : base(context, converter)
        {
        }
    }
}