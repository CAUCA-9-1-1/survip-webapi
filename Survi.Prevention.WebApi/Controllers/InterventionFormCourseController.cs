using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InterventionFormCourse")]
	public class InterventionFormCourseController : BaseSecuredController
    {
		private readonly InterventionFormCourseService service;

		public InterventionFormCourseController(InterventionFormCourseService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInterventionForm:Guid}")]
		public ActionResult GetList(Guid idInterventionForm)
		{
			return Ok(service.GetCourses(idInterventionForm));
		}
    }
}
