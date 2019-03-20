using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Webuser")]
    public class WebuserController : BaseCrudController<WebuserService, Webuser>
    {
        private readonly string applicationName;
        private readonly PermissionObjectService permissionObjectService;

        public WebuserController(WebuserService service, IConfiguration configuration, PermissionObjectService permissionObjectService) : base(service)
        {
            applicationName = configuration.GetSection("APIConfig:PackageName").Value;
            this.permissionObjectService = permissionObjectService;
        }

	    private List<Guid> GetCurrentUserDepartmentIds()
	    {
		    return Service.GetUserFireSafetyDepartments(CurrentUserId);
	    }

		[HttpPost]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public override ActionResult Post([FromBody] Webuser entity)
        {
            if (Service.AddOrUpdate(entity, applicationName, CurrentUserId) != Guid.Empty)
            {
                permissionObjectService.CreateNewUserPermissionObject(entity.Id);
                return Ok(new {id = entity.Id});
            }

            return BadRequest();
        }

        [HttpGet, Route("Active/Departments")]
        public ActionResult GetListActive()
        {
            return Ok(Service.GetListActiveByAllowedFireSafetyDepartments(GetCurrentUserDepartmentIds()));
        }

	    [HttpGet, Route("Active")]
	    public ActionResult GetActiveUsers()
	    {
		    return Ok(Service.GetListActive());
	    }
    }
}