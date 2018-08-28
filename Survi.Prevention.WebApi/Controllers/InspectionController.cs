using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Inspection")]
	public class InspectionController : BaseSecuredController
	{
		private readonly InspectionService service;

		public InspectionController(InspectionService service)
		{
			this.service = service;
		}

		[HttpPost, Route("{id:Guid}/approve")]
		[ProducesResponseType(typeof(bool), 200)]
		public ActionResult ApproveInspection(Guid id)
		{
			return Ok(service.SetStatus(InspectionStatus.Approved, id));
		}

        [HttpPost, Route("{id:Guid}/refuse")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult RefusedInspection(Guid id, [FromBody] string reason)
        {
	        service.SetStatus(InspectionStatus.Refused, id, reason);
	        
            return Ok(true);
        }

		[HttpPost, Route("{id:Guid}/cancel")]
		[ProducesResponseType(typeof(bool), 200)]
		public ActionResult CancelInspection(Guid id)
		{
			service.SetStatus(InspectionStatus.Canceled, id);
			service.Remove(id);

			return Ok(true);
		}

		[HttpGet, Route("{id:Guid}/configuration")]
		public ActionResult GetInspectionConfiguration(Guid id)
		{
			var configuration = service.GetInspectionConfiguration(id);
			if (configuration == null)
				return NotFound($"This inspection does not exist : {id})");
			return Ok(configuration);
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<BatchForList>), 200)]
		public ActionResult GetUserInspections([FromHeader]string languageCode)
		{
			return Ok(service.GetGroupedUserInspections(languageCode, CurrentUserId));
		}

		[HttpPost, Route("StartInspection")]
		public ActionResult StartInspection([FromBody] Guid idInspection)
		{
			if (service.StartInspection(idInspection, CurrentUserId))
				return NoContent();
			return BadRequest("Error during the starting process of the inspection");
		}

		[HttpPost, Route("CompleteInspection")]
		public ActionResult CompleteInspection([FromBody] Guid idInspection)
		{
			if (service.CompleteInspection(idInspection, CurrentUserId))
				return NoContent();
			return BadRequest("Error during the starting process of the inspection");
		}

		[HttpPost, Route("RefuseInspectionVisit")]
		public ActionResult RefuseInspectionVisit([FromBody] InspectionVisit inspectionVisit)
		{
			if (service.RefuseInspectionVisit(inspectionVisit, CurrentUserId))
				return NoContent();
			return BadRequest("Error during the starting process of the inspection");
		}

		[HttpGet, Route("{id:Guid}/UserAllowed")]
		public ActionResult CanUserAccessInspection(Guid id)
		{
			return Ok(service.CanUserAccessInspection(id, CurrentUserId));
		}
	}
}