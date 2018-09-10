using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrant")]
    public class FireHydrantController : BaseCrudController<FireHydrantService, FireHydrant>
    {
	    public FireHydrantController(FireHydrantService service) : base(service)
	    {
	    }

		[HttpGet, Route("city/{idCity:Guid}")]
		public ActionResult GetListLocalized(Guid idCity, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetListForCity(idCity, languageCode));
		}

		[HttpGet, Route("city/{idCity:Guid}/building/{idBuilding:Guid}")]
		public ActionResult GetCityListLocalizedForBuilding(Guid idCity, Guid idBuilding, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetCityListForBuilding(idCity, idBuilding, languageCode));
		}
	}
}
