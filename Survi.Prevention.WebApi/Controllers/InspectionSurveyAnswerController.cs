using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InspectionSurveyAnswer")]
	public class InspectionSurveyAnswerController : BaseCrudController<InspectionSurveyAnswerService, InspectionSurveyAnswer>
	{
		public InspectionSurveyAnswerController(InspectionSurveyAnswerService service) : base(service)
		{
		}
		[HttpGet, Route("Inspection/{idInspection:Guid}/Answer"), AllowAnonymous]
		public ActionResult GetAnswerListLocalized(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetAnswerListLocalized(idInspection, languageCode));
		}

		[HttpGet, Route("Inspection/{idInspection:Guid}/Question"), AllowAnonymous]
		public ActionResult GetSurveyQuestionListLocalized(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetSurveyQuestionListLocalized(idInspection, languageCode));
		}

		[HttpGet, Route("Inspection/{idInspection:Guid}/Summary"), AllowAnonymous]
		public ActionResult GetInspectionQuestionSummaryListLocalized(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetInspectionQuestionSummaryListLocalized(idInspection, languageCode));
		}

		[HttpPost, Route("Answer")]
		public ActionResult SaveQuestionAnswer([FromBody] InspectionQuestionForList inspectionQuestionAnswer)
		{
			if (Service.SaveQuestionAnswer(inspectionQuestionAnswer) != Guid.Empty)
				return Ok(new { id = inspectionQuestionAnswer.Id });
			return BadRequest("Error on question answer saving process");
		}

		[HttpPost, Route("SetSurveyStatus")]
		public ActionResult SetSurveyStatus([FromBody] InspectionSurveyCompletion surveyStatus)
		{
			if (Service.SetSurveyStatus(surveyStatus))
				return NoContent();

			return BadRequest("Error on updating the inspection survey completed status");
		}

		[HttpPut, Route("Inspection/DeleteAnswers")]
		public ActionResult DeleteSurveyAnswers([FromBody] List<Guid> answerIds)
		{
			if (Service.RemoveRange(answerIds))
				return Ok();
			return BadRequest("Error on deleteing answer group");
		}
	}
}
