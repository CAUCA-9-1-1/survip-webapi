using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/particularrisk/picture")]
	public class InspectionBuildingParticularRiskPictureController : BaseSecuredController
	{
		protected InspectionBuildingParticularRiskPictureService Service;

		public InspectionBuildingParticularRiskPictureController(InspectionBuildingParticularRiskPictureService service)
		{
			Service = service;
		}

		[Route("/api/inspection/building/particularrisk/{idBuildingParticularRisk:Guid}/picture"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuildingParticularRisk)
		{
			return Ok(Service.GetAnomalyPictures(idBuildingParticularRisk));
		}

		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] BuildingChildPictureForWeb entity)
		{
			if (Service.AddOrUpdatePicture(entity) != Guid.Empty)
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