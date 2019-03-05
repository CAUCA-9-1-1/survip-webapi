using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/pnaps")]
	public class BuildingPersonsRequiringAssistanceController : BaseCrudControllerWithImportation<BuildingPersonRequiringAssistanceService, BuildingPersonRequiringAssistance, ApiClient.DataTransferObjects.BuildingPersonRequiringAssistance>
    {
        private readonly BuildingService BuildingService;

        public BuildingPersonsRequiringAssistanceController(BuildingPersonRequiringAssistanceService service, BuildingService buildingService) : base(service)
        {
            BuildingService = buildingService;
        }

		[Route("/api/building/{idBuilding:Guid}/pnaps"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingPnapsList(idBuilding));
		}

        [HttpPost, Route("Export"), AllowAnonymous]
        public ActionResult Export([FromBody] List<string> idBuildings)
        {
            List<string> completeIdBuildList = BuildingService.AddBuildingChildToParentList(idBuildings);
            return Ok(Service.Export(completeIdBuildList));
        }
    }
}