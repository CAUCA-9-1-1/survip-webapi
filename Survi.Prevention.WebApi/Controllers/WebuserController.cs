using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Webuser")]
    public class WebuserController : BaseCrudController<WebuserService, Webuser>
    {
        private readonly string applicationName;

        public WebuserController(WebuserService service, IConfiguration configuration) : base(service)
        {
            applicationName = configuration.GetSection("APIConfig:PackageName").Value;
        }

        [HttpPost]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public override ActionResult Post([FromBody] Webuser entity)
        {
            if (Service.AddOrUpdate(entity, applicationName) != Guid.Empty)
                return Ok(new { id = entity.Id });

            return BadRequest();
        }

        [HttpGet, Route("Active")]
        public ActionResult GetListActive()
        {
            return Ok(Service.GetListActive());
        }
    }
}