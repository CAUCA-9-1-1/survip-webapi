using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Reporting;
using Survi.Prevention.ServiceLayer.Services;
using System;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportConfigurationTemplate")]
    public class ReportConfigurationTemplateController : BaseCrudController<ReportConfigurationTemplateService, ReportConfigurationTemplate>
    {             
        public ReportConfigurationTemplateController(ReportConfigurationTemplateService service) : base(service)
        {
        }
        
        [HttpGet("placeholders")]
        public ActionResult GetAvailablePlaceholders()
        {
	        var groups = BuildingReportTemplateFiller.GetPlaceholderGroups();
			return Ok(groups);
        }

		[HttpPost,  Route("CopyReportConfiguration")]
		public ActionResult CopyReportConfiguration([FromBody] Guid idReport)
		{
			return Ok(Service.CopyReportConfiguration(idReport));
		}
    }
}
