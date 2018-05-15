using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
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
		[HttpGet, Route("Answer/{idInspection:Guid}"), AllowAnonymous]
		public ActionResult GetAnswerListLocalized(Guid idInspection, [FromHeader]string languageCode)
		{
			return Ok(Service.GetAnswerListLocalized(idInspection, languageCode));
		}

		[HttpGet, Route("Question/{idInspection:Guid}"), AllowAnonymous]
		public ActionResult GetSurveyQuestionListLocalized(Guid idInspection, [FromHeader]string languageCode)
		{
			return Ok(Service.GetSurveyQuestionListLocalized(idInspection, languageCode));
		}

		[HttpPost, Route("Answer")]
		public ActionResult SaveQuestionAnswer([FromBody] InspectionQuestionForList inspectionQuestionAnswer)
		{
			if (Service.SaveQuestionAnswer(inspectionQuestionAnswer) != Guid.Empty)
				return Ok(new { id = inspectionQuestionAnswer.Id });
			else
				return BadRequest("Error on question answer saving process");
		}

		[HttpPost, Route("CompleteSurvey")]
		public ActionResult SaveQuestionAnswer([FromBody] Guid idInspection)
		{
			if (Service.CompleteSurvey(idInspection))
				return NoContent();
			else
				return BadRequest("Error on updating the inspection survey completed status");
		}
	}
}
