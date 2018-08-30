using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/alarmpanel")]
	public class InspectionBuildingAlarmPanelController : BaseCrudController<InspectionBuildingAlarmPanelService, InspectionBuildingAlarmPanel>
	{
		public InspectionBuildingAlarmPanelController(InspectionBuildingAlarmPanelService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/alarmpanellist"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetList(idBuilding));
		}
		
		[Route("/api/inspection/building/{idBuilding:Guid}/alarmpanel"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}