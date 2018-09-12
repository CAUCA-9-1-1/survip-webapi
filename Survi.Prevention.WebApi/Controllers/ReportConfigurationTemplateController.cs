using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportConfigurationTemplate")]
    public class ReportConfigurationTemplateController : BaseCrudController<ReportConfigurationTemplateService, ReportConfigurationTemplate>
    {             
        public ReportConfigurationTemplateController(ReportConfigurationTemplateService service) : base(service)
        {
        }
        
        [HttpGet("placeholders"), AllowAnonymous]
        public ActionResult GetAvailablePlaceholders()
        {
	        var groups = BuildingReportTemplateFiller.GetPlaceholderGroups();
			//return Ok(Service.GetAvailablePlaceholders());
			return Ok(groups);
        }
    }
}
