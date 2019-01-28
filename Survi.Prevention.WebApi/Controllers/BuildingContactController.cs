using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/contact")]
	public class BuildingContactController : BaseCrudControllerWithImportation<BuildingContactService, BuildingContact, ApiClient.DataTransferObjects.BuildingContact>
	{
		public BuildingContactController(BuildingContactService service) : base(service)
		{
		}

		[HttpGet, Route("/api/building/{idBuilding:Guid}/contact")]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingContactList(idBuilding));
		}

        [HttpGet, Route("Export"), AllowAnonymous]
        public ActionResult Export([FromQuery] List<string> idBuildings)
        {
            return Ok(Service.Export(idBuildings));
        }
    }
}