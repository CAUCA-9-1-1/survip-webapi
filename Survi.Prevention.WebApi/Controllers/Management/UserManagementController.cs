using System.Collections.Generic;
using System.Linq;
using Cause.SecurityManagement.Controllers;
using Cause.SecurityManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.Models.Security;
using Survi.Prevention.ServiceLayer.SecurityManagement;

namespace Survi.Prevention.WebApi.Controllers.Management
{
	[Route("api/[Controller]")]
	[ApiController]
	public class UserManagementController : BaseUserManagementController<UserManagementService<User>,User>
	{
		private readonly string applicationName;
		private readonly UserService userService;

		public UserManagementController(UserService userService, UserManagementService<User> userManagementService, IConfiguration configuration) 
			: base(userManagementService, configuration)
		{
			applicationName = configuration.GetSection("APIConfig:PackageName").Value;
			this.userService = userService;
		}

		[HttpGet("GetAllUsersWithInfo")]
		[ProducesResponseType(typeof(List<User>), 200)]
		[ProducesResponseType(401)]
		public ActionResult GetAllUsersWithInfo()
		{
			return Ok(userService.GetAllUsersWithInfo());
		}

		[HttpPost("SaveUserWithCitiesAndFireSafetyDepartments")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public ActionResult SaveUserWithCitiesAndFireSafetyDepartments(User user)
		{
			var fireSafetyDepartments = user.UserFireSafetyDepartments.ToList();
			user.UserFireSafetyDepartments = null;

			UserService.UpdateUser(user, applicationName);
			userService.UpdateUserFireSafetyDepartment(fireSafetyDepartments, user.Id);

			return Ok();
		}
	}
}
