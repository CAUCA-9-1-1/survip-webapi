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

		[HttpGet, Route("city/{cityId:Guid}")]
		public ActionResult GetListLocalized(Guid cityId, [FromHeader]string languageCode)
		{
			return Ok(Service.GetListLocalized(cityId, languageCode));
		}

	    [HttpGet, Route("city/{cityId:Guid}/Search/{searchTerm}")]
	    public ActionResult GetFilteredLanesLocalized(Guid cityId, [FromHeader]string languageCode, string searchTerm)
	    {
		    return Ok(Service.GetFilteredLanesLocalized(cityId, languageCode, searchTerm));
	    }

		[HttpGet, Route("localized/{laneId:Guid}")]
		public ActionResult GetLocalizedLane(Guid laneId, [FromHeader] string languageCode)
		{
			var lane = Service.GetLaneLocalizedName(laneId, languageCode);
			if (lane == null)
				return BadRequest("Unknown lane.");
			return Ok(lane);
		}
    }
}
