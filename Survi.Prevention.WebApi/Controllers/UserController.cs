using Cause.SecurityManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[ApiController, Route("api/[Controller]")]
	public class UserController : AuthentifiedController
	{
		private UserService userService;

		public UserController(UserService userService)
		{
			this.userService = userService;
		}

		[HttpGet("Active/Departments")]
		[ProducesResponseType(typeof(List<WebuserForWeb>), 200)]
		[ProducesResponseType(401)]
		public ActionResult GetActiveUserByAllowedFireSafetyDepartments()
		{
			return Ok(userService.GetWebUsersByAllowedFireSafetyDepartments(GetUserId()));
		}
	}
}
