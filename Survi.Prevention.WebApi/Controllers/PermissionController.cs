using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Permission")]
	public class PermissionController : BaseSecuredController
	{	
		private readonly PermissionService Service;

		public PermissionController(PermissionService service)
		{
			this.Service = service;
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Get(Guid id)
		{
			var entity = Service.GetFeatureListOfPermissionObject(id);
			return Ok(entity);
		}
		
		[HttpGet]
		[Route("webuser/{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult GetUserPermission(Guid id)
		{
			var entity = Service.GetListOfUserPermission(id);
			return Ok(entity);
		}
		
		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] Permission entity)
		{
			if (Service.Save(entity)!= Guid.Empty)			
				return Ok(new{id = entity.Id});

			return BadRequest();
		}
    }
}