using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InterventionFormFireHydrant")]
	public class InterventionFormFireHydrantController : BaseSecuredController
	{
		private readonly InterventionFormFireHydrantService service;

		public InterventionFormFireHydrantController(InterventionFormFireHydrantService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInterventionForm:Guid}")]
		public ActionResult GetList(Guid idInterventionForm, [FromHeader]string languageCode)
		{
			return Ok(service.GetFormFireHydrants(idInterventionForm, languageCode));
		}
	}
}