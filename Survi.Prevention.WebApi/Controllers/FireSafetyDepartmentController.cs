using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartment")]
	public class FireSafetyDepartmentController : BaseCrudControllerWithImportation<FireSafetyDepartmentService, FireSafetyDepartment, ApiClient.DataTransferObjects.FireSafetyDepartment>
	{
		private readonly WebuserService userService;

		public FireSafetyDepartmentController(FireSafetyDepartmentService service, WebuserService userService) : base(service)
		{
			this.userService = userService;
		}

		private List<Guid> GetDepartmentIds()
		{
			return userService.GetUserFireSafetyDepartments(CurrentUserId);
		}

		[HttpGet, Route("localized")]
		public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetLocalized(languageCode, GetDepartmentIds()));
		}

		[HttpGet, Route("alllocalized")]
		public ActionResult GetFullListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetLocalized(languageCode));
		}

		[HttpPost, Route("CityServing/Import")]
		public ActionResult ImportFireSafetyDepartmentCityServings([FromBody] List<ApiClient.DataTransferObjects.FireSafetyDepartmentCityServing> importedEntities)
		{
			return Ok(Service.ImportFireSafetyDepartmentCityServings(importedEntities));
		}
	}
}