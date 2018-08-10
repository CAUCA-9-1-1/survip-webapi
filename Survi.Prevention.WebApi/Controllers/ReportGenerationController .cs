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

        [HttpGet("building/{buildindId:guid}/template/{templateId:guid}")]
        public ActionResult Generate(Guid buildindId, Guid templateId, [FromHeader]string languageCode)
        {
            var fileStream = Service.Generate(buildindId, templateId, languageCode);
            var fileName = buildindId + ".pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
            return File(fileStream, "application/pdf", fileName);
        }
    }
}
