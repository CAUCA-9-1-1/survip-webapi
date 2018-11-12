using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/anomaly")]
	public class InspectionBuildingAnomalyController : BaseCrudController<InspectionBuildingAnomalyService, InspectionBuildingAnomaly>
	{
		public InspectionBuildingAnomalyController(InspectionBuildingAnomalyService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/anomaly"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding)
		{
			return Ok(Service.GetListForWeb(idBuilding));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/anomalylist"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetList(idBuilding));
		}

		[Route("/api/inspection/anomalythemes"), HttpGet]
		public ActionResult GetThemeList()
		{
			return Ok(Service.GetThemes());
		}

		[HttpDelete]
		[Route("{idBuildingAnomaly:Guid}")]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public override ActionResult Delete(Guid idBuildingAnomaly)
		{
			if (Service.Delete(idBuildingAnomaly, CurrentUserId))
				return NoContent();

			return BadRequest();
		}

	}
}