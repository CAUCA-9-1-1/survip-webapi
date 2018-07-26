using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportGeneration")]
    public class ReportGenerationController : Controller
    {
        
        private ReportGenerationService Service;
        
        public ReportGenerationController(ReportGenerationService service)
        {
            Service = service;
        }

        [HttpGet("generate/{id:guid}")]
        public ActionResult Generate(Guid id, [FromHeader]string languageCode)
        {
            var fileStream = Service.Generate(id, languageCode);
            var fileName = id + ".pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
            return File(fileStream, "application/pdf", fileName);
        }
    }
}
