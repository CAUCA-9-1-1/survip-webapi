﻿using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/CityType")]
    public class CityTypeController : BaseCrudController<CityTypeService, CityType>
    {
        public CityTypeController(CityTypeService service) : base(service)
        {
        }

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }
    }
}