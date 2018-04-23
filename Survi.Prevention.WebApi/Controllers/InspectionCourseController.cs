using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection")]
	public class InspectionCourseController : BaseSecuredController
    {
		private readonly InspectionBuildingCourseService service;

		public InspectionCourseController(InspectionBuildingCourseService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/course")]
		public ActionResult GetList(Guid idInspection)
		{
			return Ok(service.GetCourses(idInspection));
		}
    }
}
