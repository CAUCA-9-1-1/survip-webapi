
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.SurveyManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/SurveyQuestionChoice")]
	public class SurveyQuestionChoiceController : BaseCrudController<SurveyQuestionChoiceService, SurveyQuestionChoice>
	{
		public SurveyQuestionChoiceController(SurveyQuestionChoiceService service) : base(service)
		{
		}

		[HttpGet, Route("SurveyQuestion/{idSurveyQuestion:Guid}")]
		public ActionResult GetListLocalized(Guid idSurveyQuestion, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetListLocalized(idSurveyQuestion, languageCode));
		}

		[HttpDelete, Route("SurveyQuestion/{idSurveyQuestion:Guid}")]
		public ActionResult DeleteQuestionChoices(Guid idSurveyQuestion)
		{
			return Ok(Service.DeleteQuestionChoices(idSurveyQuestion));
		}
	}
}