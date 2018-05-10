using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InspectionQuestion")]
	public class InspectionQuestionController : BaseCrudController<InspectionQuestionService, InspectionQuestion>
	{
		public InspectionQuestionController(InspectionQuestionService service) : base(service)
		{
		}
		[HttpGet, Route("Survey/{idSurvey:Guid}"), AllowAnonymous]
		public ActionResult GetListLocalized(Guid idSurvey, [FromHeader]string languageCode)
		{
			return Ok(Service.GetListLocalized(idSurvey, languageCode));
		}
	}
}
