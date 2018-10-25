using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartment")]
	public class FireSafetyDepartmentController : BaseCrudController<FireSafetyDepartmentService, FireSafetyDepartment>
	{
		private readonly WebuserService userService;
		public FireSafetyDepartmentController(FireSafetyDepartmentService service, WebuserService userService) : base(service)
		{
			this.userService = userService;
		}

		private List<Guid> GetUserFireDepartmentsIds()
		{
			return userService.GetUserFireSafetyDepartments(CurrentUserId);
		}

		[HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode, GetUserFireDepartmentsIds()));
        }
	}
}