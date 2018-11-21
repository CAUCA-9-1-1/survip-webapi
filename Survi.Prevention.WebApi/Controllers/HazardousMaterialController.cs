using System;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/HazardousMaterial")]
	public class HazardousMaterialController : BaseCrudControllerWithImportation<HazardousMaterialService, HazardousMaterial, ApiClient.DataTransferObjects.HazardousMaterial>
    {
		private readonly HazardousMaterialService service;

		public HazardousMaterialController(HazardousMaterialService service) : base(service)
		{
			this.service = service;
		}

		[HttpGet, Route("search/{searchTerm?}")]
		public ActionResult GetList([FromHeader(Name = "Language-Code")] string languageCode, string searchTerm)
		{
			searchTerm = HttpUtility.UrlDecode(searchTerm);
			return Ok(service.GetList(languageCode, searchTerm));
		}

        [HttpGet, Route("localized")]
        public ActionResult GetListForDisplay([FromHeader(Name = "Language-Code")]string languageCode)
        {
            return Ok(service.GetListForDisplay(languageCode));
        }

        [HttpGet, Route("{id:Guid}/name")]
		public ActionResult GetList(Guid id, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(service.Get(languageCode, id));
		}
	}
}