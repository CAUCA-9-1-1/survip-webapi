using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Reporting;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/ReportConfigurationTemplate")]
	public class ReportConfigurationTemplateController : BaseCrudController<ReportConfigurationTemplateService, ReportConfigurationTemplate>
	{
		private readonly WebuserService userService;

		public ReportConfigurationTemplateController(ReportConfigurationTemplateService service, WebuserService userService) : base(service)
		{
			this.userService = userService;
		}
		
		[HttpGet("placeholders")]
		public ActionResult GetAvailablePlaceholders()
		{
			var groups = BuildingReportTemplateFiller.GetPlaceholderGroups();
			return Ok(groups);
		}

		[HttpGet("list")]
		public ActionResult GetAvailableReports()
		{
			List<ReportConfigurationTemplate> groups = Service.GetReports(GetDepartmentIds());
			return Ok(groups);
		}

		[HttpPost,  Route("CopyReportConfiguration")]
		public ActionResult CopyReportConfiguration([FromBody] Guid idReport)
		{
			return Ok(Service.CopyReportConfiguration(idReport));
		}

		private List<Guid> GetDepartmentIds()
		{
			return userService.GetUserFireSafetyDepartments(CurrentUserId);
		}
    }
}
