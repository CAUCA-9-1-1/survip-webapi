using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/City")]
    public class CityController : BaseCrudControllerWithImportation<CityService, City, ApiClient.DataTransferObjects.City>
    {
	    private readonly UserService userService;
	    private readonly GeolocationService geolocationService;

        public CityController(CityService service, UserService userService, GeolocationService geolocationService) : base(service)
        {
	        this.userService = userService;
	        this.geolocationService = geolocationService;
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
	    
	    [HttpGet, Route("{id:guid}/geolocation")]
	    public async Task<ActionResult> GetCityGeolocation(Guid id, [FromHeader(Name = "Language-Code")] string languageCode)
	    {
		    var city = Service.GetCityWithRegionLocalized(id, languageCode);
		    var json = await geolocationService.SearchWithICherche("municipalite", city.Name + "," + city.CountyName + "," + city.RegionName);

		    return Ok(json);
	    }
    }
}