using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/hazardousmaterial")]
	public class InspectionBuildingHazardousMaterialController : BaseCrudController<InspectionBuildingHazardousMaterialService, InspectionBuildingHazardousMaterial>
	{
		public InspectionBuildingHazardousMaterialController(InspectionBuildingHazardousMaterialService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/hazardousmateriallist"), HttpGet]
		public ActionResult GetList(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetList(idBuilding));
		}
		
		[Route("/api/inspection/building/{idBuilding:Guid}/hazardousmaterial"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}