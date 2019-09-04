using Cause.SecurityManagement.Controllers;
using Cause.SecurityManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Survi.Prevention.WebApi.Controllers.Management
{
	[Route("api/[Controller]")]
	[ApiController]
	public class PermissionManagementController : BasePermissionManagementController
	{
		public PermissionManagementController(IPermissionManagementService permissionService) : base(permissionService)
		{
		}
	}
}
