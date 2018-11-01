using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Lane")]
    public class LaneController : BaseCrudController<LaneService, Lane>
    {
	    private readonly WebuserService userService;
	    private readonly CityService cityService;

		public LaneController(LaneService service, WebuserService userService, CityService cityService) 
			: base(service)
		{
			this.userService = userService;
			this.cityService = cityService;
		}

	    private List<Guid> GetUserCityIds()
	    {
		    var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
		    return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
	    }

		[HttpGet, Route("city/{cityId:Guid}")]
		public ActionResult GetListByCityLocalized(Guid cityId, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetListByCityLocalized(cityId, languageCode));
		}

	    [HttpGet, Route("city/{cityId:Guid}/Search/{*searchTerm}")]
	    public ActionResult GetFilteredLanesLocalized(Guid cityId, [FromHeader(Name = "Language-Code")]string languageCode, string searchTerm)
	    {
			return Ok(Service.GetFilteredLanesLocalized(cityId, languageCode, searchTerm));
	    }

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(GetUserCityIds(), languageCode));
        }

        [HttpGet, Route("localized/{laneId:Guid}")]
		public ActionResult GetLocalizedLane(Guid laneId, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			var lane = Service.GetLaneLocalizedName(laneId, languageCode);
			if (lane == null)
				return BadRequest("Unknown lane.");
			return Ok(lane);
		}
    }
}
