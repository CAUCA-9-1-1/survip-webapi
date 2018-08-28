using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PermissionObject")]
	public class PermissionObjectController : BaseSecuredController
	{	
		private readonly PermissionObjectService Service;

		public PermissionObjectController(PermissionObjectService service)
		{
			Service = service;
		}

		[HttpGet]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Get()
		{
			var result = Service.GetList();

			return Ok(result);
		}
		
		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] PermissionObject entity)
		{
			if (Service.AddOrUpdate(entity)!= Guid.Empty)
				return Ok(new{id = entity.Id});

			return BadRequest();
		}
		
		[HttpDelete]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Delete(Guid id)
		{
			if (Service.Remove(id))
				return NoContent();

			return BadRequest();
		}
    }
}