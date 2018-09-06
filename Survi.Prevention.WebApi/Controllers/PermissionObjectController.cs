using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PermissionObject")]
	public class PermissionObjectController : BaseSecuredController
	{	
		private readonly PermissionObjectService service;

		public PermissionObjectController(PermissionObjectService service)
		{
			this.service = service;
		}

		[HttpGet]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Get()
		{
			var result = service.GetList();

			return Ok(result);
		}
		
		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Post([FromBody] PermissionObject entity)
		{
			if (service.AddOrUpdate(entity)!= Guid.Empty)
				return Ok(new{id = entity.Id});

			return BadRequest();
		}
		
		[HttpDelete]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Delete(Guid id)
		{
			if (service.Remove(id))
				return NoContent();

			return BadRequest();
		}
    }
}