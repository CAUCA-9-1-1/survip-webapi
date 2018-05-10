using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/pnaps")]
	public class InspectionBuildingPersonsRequiringAssistanceController : BaseCrudController<InspectionBuildingPersonRequiringAssistanceService, BuildingPersonRequiringAssistance>
	{
		public InspectionBuildingPersonsRequiringAssistanceController(InspectionBuildingPersonRequiringAssistanceService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/pnaps"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}