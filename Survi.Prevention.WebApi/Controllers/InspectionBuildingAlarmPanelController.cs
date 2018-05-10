using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/alarmpanel")]
	public class InspectionBuildingAlarmPanelController : BaseCrudController<InspectionBuildingAlarmPanelService, BuildingAlarmPanel>
	{
		public InspectionBuildingAlarmPanelController(InspectionBuildingAlarmPanelService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/alarmpanel"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}