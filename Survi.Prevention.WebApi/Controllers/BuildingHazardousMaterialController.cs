using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/hazardousmaterial")]
	public class BuildingHazardousMaterialController : BaseCrudController<BuildingHazardousMaterialService, BuildingHazardousMaterial>
	{
		public BuildingHazardousMaterialController(BuildingHazardousMaterialService service) : base(service)
		{
		}

		[HttpGet, Route("/api/building/{idBuilding:Guid}/hazardousmaterial")]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingHazardousMaterialList(idBuilding));
		}
	}
}