using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/sprinkler")]
	public class InspectionBuildingSprinklerController : BaseCrudController<InspectionBuildingSprinklerService, BuildingSprinkler>
	{
		public InspectionBuildingSprinklerController(InspectionBuildingSprinklerService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/sprinkler"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}