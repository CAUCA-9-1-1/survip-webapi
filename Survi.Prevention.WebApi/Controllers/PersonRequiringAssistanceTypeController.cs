using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PersonRequiringAssistanceType")]
	public class PersonRequiringAssistanceTypeController : BaseCrudController<PersonRequiringAssistanceTypeService, PersonRequiringAssistanceType>
    {
		private readonly PersonRequiringAssistanceTypeService service;

		public PersonRequiringAssistanceTypeController(PersonRequiringAssistanceTypeService service) : base(service)
		{
			this.service = service;
		}

		[HttpGet]
        [HttpGet, Route("localized")]
        public ActionResult GetListForDisplay([FromHeader]string languageCode)
		{
			return Ok(service.GetListForDisplay(languageCode));
		}
	}
}