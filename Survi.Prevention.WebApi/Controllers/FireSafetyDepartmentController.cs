using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartment")]
	public class FireSafetyDepartmentController : BaseCrudControllerWithImportation<FireSafetyDepartmentService, FireSafetyDepartment, ApiClient.DataTransferObjects.FireSafetyDepartment>
	{
		private readonly UserService userService;

		public FireSafetyDepartmentController(FireSafetyDepartmentService service, UserService userService) : base(service)
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