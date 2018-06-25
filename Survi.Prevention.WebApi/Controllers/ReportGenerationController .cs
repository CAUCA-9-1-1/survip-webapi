using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.Models.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportGeneration")]
    public class ReportGenerationController : BaseCrudController<ReportGenerationService, ReportConfigurationTemplate>
    {
        
        protected ReportGenerationService Service;
        
        public ReportGenerationController(ReportGenerationService service) : base(service)
        {
            Service = service;
        }

        [HttpGet("generate/{id:guid}")]
        public ActionResult Generate(Guid id)
        {
            return Ok(Service.Generate(id));
        }
    }
}
