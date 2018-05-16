using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/anomaly")]
	public class InspectionBuildingAnomalyController : BaseCrudController<InspectionBuildingAnomalyService, BuildingAnomaly>
	{
		public InspectionBuildingAnomalyController(InspectionBuildingAnomalyService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/anomaly"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding)
		{
			return Ok(Service.GetListForWeb(idBuilding));
		}

		[Route("/api/inspection/anomalythemes"), HttpGet]
		public ActionResult GetThemeList()
		{
			return Ok(Service.GetThemes());
		}
	}
}