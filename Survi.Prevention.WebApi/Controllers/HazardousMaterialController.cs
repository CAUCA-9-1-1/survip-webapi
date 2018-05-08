using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/HazardousMaterial")]
	public class HazardousMaterialController : BaseSecuredController
	{
		private readonly HazardousMaterialService service;

		public HazardousMaterialController(HazardousMaterialService service)
		{
			this.service = service;
		}

		[HttpGet, Route("search/{searchTerm}")]
		public ActionResult GetList(string searchTerm, [FromHeader] string languageCode)
		{
			return Ok(service.GetList(languageCode, searchTerm));
		}

		[HttpGet, Route("{id:Guid}/name")]
		public ActionResult GetList(Guid idHazardousMaterial, [FromHeader] string languageCode)
		{
			return Ok(service.GetName(languageCode, idHazardousMaterial));
		}
	}
}