using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/City")]
    public class CityController : BaseCrudController<CityService, City>
    {
	    private readonly WebuserService userService;

        public CityController(CityService service, WebuserService userService) : base(service)
        {
	        this.userService = userService;
        }

	    private List<Guid> GetUserCityIds()
	    {
		    var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
		    return Service.GetCityIdsByFireSafetyDepartments(departmentIds);
	    }
	    
        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode, GetUserCityIds()));
        }

	    [HttpGet, Route("{id:guid}/localized")]
	    public ActionResult GetCityWithRegionLocalized(Guid id, [FromHeader(Name = "Language-Code")] string languageCode)
	    {
		    return Ok(Service.GetCityWithRegionLocalized(id, languageCode));
	    }
    }
}