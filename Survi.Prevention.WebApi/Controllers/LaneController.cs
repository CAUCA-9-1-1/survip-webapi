using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Lane")]
    public class LaneController : BaseCrudController<LaneService, Lane>
    {
	    public LaneController(LaneService service) : base(service)
	    {
	    }

		[HttpGet, Route("{cityId:Guid}")]
		public ActionResult GetListLocalized(Guid cityId, [FromHeader]string languageCode)
		{
			return Ok(Service.GetListLocalized(cityId, languageCode));
		}
    }
}
