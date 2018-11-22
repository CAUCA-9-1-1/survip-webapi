using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrantType")]
    public class FireHydrantTypeController
        : BaseCrudControllerWithImportation<FireHydrantTypeService, FireHydrantType, ApiClient.DataTransferObjects.FireHydrantType>
    {
	    public FireHydrantTypeController(FireHydrantTypeService service) : base(service)
	    {
	    }

	    [HttpGet, Route("localized")]
	    public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode));
	    }
    }
}
