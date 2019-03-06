using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection")]
	public class InspectionFireHydrantController : BaseSecuredController
	{
		private readonly InspectionBuildingFireHydrantService service;

		public InspectionFireHydrantController(InspectionBuildingFireHydrantService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/firehydrant")]
		public ActionResult<List<InspectionBuildingFireHydrantForList>> GetList(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetFormFireHydrants(idInspection, languageCode));
		}

	    [HttpGet, Route("building/{idBuilding:Guid}/firehydrant")]
	    public ActionResult<List<InspectionBuildingFireHydrantForList>> GetListByBuilding(Guid idBuilding, [FromHeader(Name = "Language-Code")]string languageCode)
	    {
	        return Ok(service.GetBuildingFireHydrants(idBuilding, languageCode));
	    }

	    [HttpPost, Route("building/{idBuilding:Guid}/firehydrants")]
	    public ActionResult SaveFireHydrants(Guid idBuilding, [FromBody]List<Guid> fireHydrantIds)
	    {
	        return Ok(service.SaveFireHydrants(idBuilding, fireHydrantIds));
	    }

        [HttpDelete, Route("buildingFireHydrant/{idBuildingFireHydrant:Guid}")]
		public ActionResult DeleteBuildingFireHydrant(Guid idBuildingFireHydrant)
		{
			if (service.DeleteBuildingFireHydrant(idBuildingFireHydrant))
				return NoContent();
			else
				return BadRequest("Unknown fire hydrant for this building.");
		}

		[HttpPost, Route("building/{idBuilding:Guid}/firehydrant/{idFireHydrant:Guid}")]
		public ActionResult AddBuildingFireHydrant(Guid idBuilding, Guid idFireHydrant)
		{
			if (service.AddBuildingFireHydrant(idBuilding, idFireHydrant))
				return NoContent();
			else
				return BadRequest("Error during the adding process of the fire hydrant");
		}
	}
}