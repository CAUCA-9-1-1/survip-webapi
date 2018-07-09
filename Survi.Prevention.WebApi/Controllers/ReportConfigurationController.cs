using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportConfiguration")]
    public class ReportConfigurationController : BaseCrudController<ReportConfigurationService, ReportConfigurationTemplate>
    {
        
        private ReportConfigurationService Service;
        
        public ReportConfigurationController(ReportConfigurationService service) : base(service)
        {
            Service = service;
        }
        
        [HttpGet, Route("Template")]
        public ActionResult GetListActive()
        {
            return Ok(Service.GetList());
        }

        [HttpGet, Route("Template/{id}")]
        public ActionResult GetTemplate(Guid id)
        {
            return Ok(Service.Get(id));
        }
        
        [HttpPost, Route("Template")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public ActionResult SaveTemplate([FromBody] ReportConfigurationTemplate template)
        {
            if (Service.AddOrUpdate(template) != Guid.Empty)
                return Ok(new {id = template.Id});
            
            return BadRequest();
        }
    }
}
