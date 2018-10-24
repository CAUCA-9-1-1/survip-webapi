using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;

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
		
		private List<Guid> GetUserCityIds(Guid idFireSafetyDepartment = new Guid())
		{
			var departmentIds = new List<Guid>();

			if(idFireSafetyDepartment != Guid.Empty)
				departmentIds.Add(idFireSafetyDepartment);
			else
			 departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);

			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		[HttpGet, Route("Active")]
		public ActionResult GetListActive([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode, GetUserCityIds()));
		}

		[HttpGet, Route("Active/{idFireSafetyDepartment:Guid}")]
		public ActionResult GetListActiveForFireSafetyDepartment(Guid idFireSafetyDepartment, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode, GetUserCityIds(idFireSafetyDepartment)));
		}
		
        [HttpGet, Route("child/{idParentBuilding:Guid}")]
        public ActionResult GetChildList(Guid idParentBuilding)
        {
            return Ok(Service.GetChildList(idParentBuilding));
        }

		[HttpPost, Route("ForInspectionList")]
		public ActionResult<AvailableBuildingForManagement> GetBuildingForInspectionList([FromBody]List<Guid> buildingIds, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetForInspectionList(languageCode, buildingIds));
		}
	}
}