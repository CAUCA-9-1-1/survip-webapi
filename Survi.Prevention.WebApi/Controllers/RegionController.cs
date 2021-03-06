﻿using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Region")]
	public class RegionController : BaseCrudControllerWithImportation<RegionService, Region, ApiClient.DataTransferObjects.Region>
	{		
		public RegionController(RegionService service) : base(service)
		{
		}

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }
    }
}