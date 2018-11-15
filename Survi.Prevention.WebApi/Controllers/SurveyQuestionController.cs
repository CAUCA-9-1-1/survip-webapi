using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;
using Survi.Prevention.Models.SurveyManagement;
using System;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/SurveyQuestion")]
	public class SurveyQuestionController : BaseCrudController<SurveyQuestionService, SurveyQuestion>
	{
		public SurveyQuestionController(SurveyQuestionService service) : base(service)
		{
		}
		[HttpGet, Route("Survey/{idSurvey:Guid}")]
		public ActionResult GetListLocalized(Guid idSurvey, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetListLocalized(idSurvey, languageCode));
		}

		[HttpPost, Route("{idSurveyQuestion:Guid}/Sequence/{sequence:int}")]
		public ActionResult Move(Guid idSurveyQuestion, int sequence)
		{
			if (Service.MoveQuestion(idSurveyQuestion, sequence))
				return NoContent();
			else
				return BadRequest("Error during the moving processs of the question");
		}
	}
}