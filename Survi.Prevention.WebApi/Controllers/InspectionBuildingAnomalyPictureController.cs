using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/anomaly/picture")]
	public class InspectionBuildingAnomalyPictureController : BaseSecuredController
	{
		protected InspectionBuildingAnomalyPictureService Service;

		public InspectionBuildingAnomalyPictureController(InspectionBuildingAnomalyPictureService service)
		{
			Service = service;
		}

		[Route("/api/inspection/building/anomaly/{idBuildingAnomaly:Guid}/picture"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuildingAnomaly)
		{
			return Ok(Service.GetAnomalyPictures(idBuildingAnomaly));
		}

		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] BuildingChildPictureForWeb entity)
		{
			if (Service.AddPicture(entity) != Guid.Empty)
				return Ok(new { id = entity.Id });

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