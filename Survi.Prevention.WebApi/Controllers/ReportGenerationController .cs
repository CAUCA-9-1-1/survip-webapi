using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
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
            var fileStream = Service.Generate(id);
            var fileName = id + ".pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName); //this opens file in tab when you return it
            return File(fileStream, "application/pdf", fileName);
        }
    }
}
