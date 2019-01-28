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
		public BuildingPersonsRequiringAssistanceController(BuildingPersonRequiringAssistanceService service) : base(service)
		{
		}

		[Route("/api/building/{idBuilding:Guid}/pnaps"), HttpGet]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingPnapsList(idBuilding));
		}

        [HttpGet, Route("Export"), AllowAnonymous]
        public ActionResult Export([FromQuery] List<string> idBuildings)
        {
            return Ok(Service.Export(idBuildings));
        }
    }
}