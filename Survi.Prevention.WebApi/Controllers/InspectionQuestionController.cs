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
		[HttpGet, Route("Inspection/{idInspection:Guid}"), AllowAnonymous]
		public ActionResult GetListLocalized(Guid idInspection, [FromHeader]string languageCode)
		{
			return Ok(Service.GetListLocalized(idInspection, languageCode));
		}

		[HttpPost, Route("Answer")]
		public ActionResult SaveQuestionAnswer([FromBody] InspectionQuestionForList inspectionQuestionAnswer)
		{
			if (Service.SaveQuestionAnswer(inspectionQuestionAnswer))
				return NoContent();
			else
				return BadRequest("Error during the survey question answer saving process");
		}
	}
}
