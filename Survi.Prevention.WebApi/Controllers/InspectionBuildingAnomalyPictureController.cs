﻿using System;
using System.Collections.Generic;
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

	    [Route("/api/inspection/building/{idBuilding:Guid}/anomaly/pictures"), HttpGet]
	    public ActionResult<List<EntityPictures>> GetPicturesForBuilding(Guid idBuilding)
	    {
	        return Ok(Service.GetBuildingAnomalyPictures(idBuilding));
	    }

		[HttpPost]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] InspectionPictureForWeb entity)
		{
			if (Service.AddOrUpdatePicture(entity) != Guid.Empty)
				return Ok(new { id = entity.Id });

			return BadRequest();
		}

		[HttpPost, Route("/api/inspection/building/anomaly/pictures")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public virtual ActionResult Post([FromBody] List<InspectionPictureForWeb> entities)
		{
		    if (Service.AddUpdatePictures(entities))
                return Ok(new { result =  true});

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