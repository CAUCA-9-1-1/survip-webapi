using Microsoft.AspNetCore.Mvc;
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
	}
}
