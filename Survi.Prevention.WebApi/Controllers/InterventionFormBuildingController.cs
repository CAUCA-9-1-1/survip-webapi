using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/InterventionFormBuilding")]
	public class InterventionFormBuildingController : BaseSecuredController
	{
		private readonly InterventionFormBuildingService service;

		public InterventionFormBuildingController(InterventionFormBuildingService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInterventionForm:Guid}")]
		public ActionResult GetList(Guid idInterventionForm, [FromHeader]string languageCode)
		{
			return Ok(service.GetFormBuildings(idInterventionForm, languageCode));
		}
	}
}