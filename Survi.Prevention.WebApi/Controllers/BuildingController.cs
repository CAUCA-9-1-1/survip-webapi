using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Building")]
	public class BuildingController : BaseCrudController<BuildingService, Building>
	{
		private readonly WebuserService userService;
		private readonly CityService cityService;
		
		public BuildingController(BuildingService service, CityService cityService, WebuserService userService) : base(service)
		{
			this.cityService = cityService;
			this.userService = userService;
		}
		
		private List<Guid> GetUserCityIds()
		{
			var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}
		
		[HttpGet, Route("Active")]
		public ActionResult GetListActive([FromHeader] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode, GetUserCityIds()));
		}
		
        [HttpGet, Route("child/{idParentBuilding:Guid}")]
        public ActionResult GetChildList(Guid idParentBuilding)
        {
            return Ok(Service.GetChildList(idParentBuilding));
        }
    }
}