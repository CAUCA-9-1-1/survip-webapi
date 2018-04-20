using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InterventionForm")]
	public class InterventionFormController : BaseSecuredController
	{
		private readonly InterventionFormService service;

		public InterventionFormController(InterventionFormService service)
		{
			this.service = service;
		}

		[HttpGet, Route("ForWeb/{id:Guid}")]
		public ActionResult GetFormForWeb(Guid id, [FromHeader]string languageCode)
		{
			var form = service.GetFormForWeb(id, languageCode);
			if (form == null)
				return NotFound();
			return Ok(form);
		}

		[HttpPost, Route("ForWeb/{id:Guid}/idLaneIntersection/{idLane:Guid?}")]	
		public ActionResult SaveIntersection(Guid id, Guid? idLane)
		{			
			if (service.TryToChangeIntersection(id, idLane))
				return Ok();
			return BadRequest("Unknown form.");			
		}

		[HttpPost, Route("ForWeb/{id:Guid}/idPicture/{idPicture:Guid?}")]
		public ActionResult SavePicture(Guid id, Guid? idPicture)
		{
			if (service.TryToChangeIdPicture(id, idPicture))
				return Ok();
			return BadRequest("Unknown form.");			
		}
	}
}