using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection")]
	public class InspectionFireHydrantController : BaseSecuredController
	{
		private readonly InspectionBuildingFireHydrantService service;

		public InspectionFireHydrantController(InspectionBuildingFireHydrantService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/firehydrant")]
		public ActionResult GetList(Guid idInspection, [FromHeader]string languageCode)
		{
			return Ok(service.GetFormFireHydrants(idInspection, languageCode));
		}
	}
}