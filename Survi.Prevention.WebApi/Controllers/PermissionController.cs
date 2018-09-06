using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Permission")]
	public class PermissionController : BaseSecuredController
	{	
		private readonly PermissionService service;

		public PermissionController(PermissionService service)
		{
			this.service = service;
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Get(Guid id)
		{
			var entity = service.GetFeatureListOfPermissionObject(id);
			return Ok(entity);
		}
		
		[HttpGet]
		[Route("webuser/{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult GetUserPermission(Guid id)
		{
			var entity = service.GetListOfUserPermission(id);
			return Ok(entity);
		}
		
		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Post([FromBody] Permission entity)
		{
			if (service.Save(entity)!= Guid.Empty)			
				return Ok(new{id = entity.Id});

			return BadRequest();
		}
    }
}