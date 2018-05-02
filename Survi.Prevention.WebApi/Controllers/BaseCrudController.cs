using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Base;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json")]
	public abstract class BaseCrudController<TService, TModel> : BaseSecuredController
		where TModel : BaseModel
		where TService : BaseCrudService<TModel>
	{
		protected readonly TService Service;

		protected BaseCrudController(TService service)
		{
			this.Service = service;
		}

		[HttpGet]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Get(Guid id)
		{
			var entity = Service.Get(id);
			return Ok(entity);
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
		public ActionResult Post([FromBody] TModel entity)
		{
			if (Service.AddOrUpdate(entity))
				return NoContent();

			return BadRequest();
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Delete(Guid id)
		{
			if (Service.Remove(id))
				return NoContent();

			return BadRequest();
		}
	}
}