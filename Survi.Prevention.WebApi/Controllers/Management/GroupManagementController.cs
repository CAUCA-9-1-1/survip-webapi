using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cause.SecurityManagement.Controllers;
using Cause.SecurityManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Survi.Prevention.WebApi.Controllers.Management
{
	[Route("api/[Controller]")]
	public class GroupManagementController : BaseGroupManagementController
	{
		public GroupManagementController(IGroupManagementService groupService) : base(groupService)
		{
		}
	}
}
