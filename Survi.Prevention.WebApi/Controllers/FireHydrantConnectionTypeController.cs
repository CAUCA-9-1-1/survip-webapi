using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrantConnectionType")]
    public class FireHydrantConnectionTypeController 
        : BaseCrudControllerWithImportation<FireHydrantConnectionTypeService, FireHydrantConnectionType, ApiClient.DataTransferObjects.FireHydrantConnectionType>
    {
	    public FireHydrantConnectionTypeController(FireHydrantConnectionTypeService service) : base(service)
	    {
	    }
    }
}
