using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PersonRequiringAssistanceType")]
	public class PersonRequiringAssistanceTypeController : BaseSecuredController
	{
		private readonly PersonRequiringAssistanceTypeService service;

		public PersonRequiringAssistanceTypeController(PersonRequiringAssistanceTypeService service)
		{
			this.service = service;
		}

		[HttpGet]
		public ActionResult GetListForDisplay([FromHeader]string languageCode)
		{
			return Ok(service.GetListForDisplay(languageCode));
		}
	}
}