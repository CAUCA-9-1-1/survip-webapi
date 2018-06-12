using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/pnaps")]
	public class BuildingPersonsRequiringAssistanceController : BaseCrudController<BuildingPersonRequiringAssistanceService, BuildingPersonRequiringAssistance>
	{
		public BuildingPersonsRequiringAssistanceController(BuildingPersonRequiringAssistanceService service) : base(service)
		{
		}

		[Route("/api/building/{idBuilding:Guid}/pnaps"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingPnapsList(idBuilding));
		}
	}
}