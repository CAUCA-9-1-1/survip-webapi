using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/sprinkler")]
	public class InspectionBuildingSprinklerController : BaseCrudController<InspectionBuildingSprinklerService, InspectionBuildingSprinkler>
	{
		public InspectionBuildingSprinklerController(InspectionBuildingSprinklerService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/sprinklerlist"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetList(idBuilding));
		}
		
		[Route("/api/inspection/building/{idBuilding:Guid}/sprinkler"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}