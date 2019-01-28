using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{	
	[Route("api/inspection")]
	public class InspectionBuildingController : BaseSecuredController
	{
		private readonly InspectionBuildingService service;

		public InspectionBuildingController(InspectionBuildingService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/building")]
		public ActionResult GetList(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetBuildings(idInspection, languageCode));
		}

        [HttpPost, Route("Building/Export"), AllowAnonymous]
        public ActionResult GetInspectionForExport()
        {
            return Ok(service.GetInspectionForExport());
        }
	}
}