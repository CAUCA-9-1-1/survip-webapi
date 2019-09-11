using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Reporting;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/ReportConfigurationTemplate")]
	public class ReportConfigurationTemplateController : BaseCrudController<ReportConfigurationTemplateService, ReportConfigurationTemplate>
	{
		private readonly UserService userService;

		public ReportConfigurationTemplateController(ReportConfigurationTemplateService service, UserService userService) : base(service)
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
