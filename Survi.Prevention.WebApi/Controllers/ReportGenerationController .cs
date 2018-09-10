using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportGeneration")]
    public class ReportGenerationController : Controller
    {        
        private readonly ReportGenerationService service;
        
        public ReportGenerationController(ReportGenerationService service)
        {
            this.service = service;
        }

        [HttpGet("building/{buildindId:guid}/template/{templateId:guid}")]
        public ActionResult Generate(Guid buildindId, Guid templateId, [FromHeader(Name = "Language-Code")]string languageCode)
        {
            var fileStream = service.Generate(buildindId, templateId, languageCode);
            var fileName = buildindId + ".pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
            return File(fileStream, "application/pdf", fileName);
        }
    }
}
