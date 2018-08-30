using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PermissionSystemFeature")]
	public class PermissionSystemFeatureController : BaseSecuredController
	{	
		private readonly PermissionSystemFeatureService Service;

		public PermissionSystemFeatureController(PermissionSystemFeatureService service)
		{
			Service = service;
		}

		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Post([FromBody] PermissionSystemFeature entity)
		{
			if (Service.AddOrUpdate(entity)!= Guid.Empty)
				return Ok(new{id = entity.Id});

			return BadRequest();
		}
    }
}