using System;
using Microsoft.AspNetCore.Mvc;
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
		public ActionResult GetList(Guid idInspection, [FromHeader]string languageCode)
		{
			return Ok(service.GetFormFireHydrants(idInspection, languageCode));
		}

		[HttpDelete, Route("buildingFireHydrant/{idBuildingFireHydrant:Guid}")]
		public ActionResult DeleteBuildingFireHydrant(Guid idBuildingFireHydrant)
		{
			if (service.DeleteBuildingFireHydrant(idBuildingFireHydrant))
				return Ok();
			return BadRequest("Unknown fire hydrant for this building.");
		}

		[HttpPost, Route("building/{idBuilding:Guid}/firehydrant/{idFireHydrant:Guid}")]
		public ActionResult AddBuildingFireHydrant(Guid idBuilding, Guid idFireHydrant)
		{
			if (service.AddBuildingFireHydrant(idBuilding, idFireHydrant))
				return Ok();
			return BadRequest("Unknown fire hydrant for this building.");
		}
	}
}