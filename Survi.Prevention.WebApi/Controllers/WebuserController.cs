using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Webuser")]
    public class WebuserController : BaseCrudController<WebuserService, Webuser>
    {
        public WebuserController(WebuserService service) : base(service)
        {
        }

        [HttpGet, Route("Active")]
        public ActionResult GetListActive()
        {
            return Ok(Service.GetListActive());
        }
    }
}