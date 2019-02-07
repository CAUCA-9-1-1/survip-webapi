using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.SurveyManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Survey")]
	public class SurveyController : BaseCrudController<SurveyService, Survey>
	{
		public SurveyController(SurveyService service) : base(service)
		{
		}

		[HttpGet, Route("localized")]
		public ActionResult<List<GenericModelForDisplay>> GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Service.GetListLocalized(languageCode);
		}

		[HttpPost,  Route("CopySurvey")]
		public ActionResult CopySurvey([FromBody] Guid idSurvey)
		{
			return Ok(Service.CopySurvey(idSurvey));
		}

	    [HttpGet, Route("CheckIfUsed/{idSurvey:Guid}")]
	    public ActionResult<bool> CheckIfUsed(Guid idSurvey)
	    {
	        return Service.CheckIfUsed(idSurvey);
	    }
	}
}
