using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Building")]
	public class BuildingController : BaseCrudController<BuildingService, Building>
	{
		public BuildingController(BuildingService service) : base(service)
		{
		}

        [HttpGet, Route("Active")]
        public ActionResult GetListActive([FromHeader]string languageCode)
        {
            return Ok(Service.GetListActive(languageCode));
        }
    }
}