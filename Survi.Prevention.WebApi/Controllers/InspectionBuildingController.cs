using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects.Inspections;
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

        [HttpPost, Route("Building/TransferedToCad"), AllowAnonymous]
        public ActionResult SetBuildingAsTransferedToCad([FromBody] List<string> ids)
        {
            return Ok(service.SetBuildingAsTransferedToCad(ids));
        }
	    
		[HttpGet, Route("{idInspection:Guid/buildinglist")]
        public ActionResult<InspectionWithBuildings> GetInspectionWithBuilding(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
	    {
	        return Ok(service.GetInspectionWithBuildings(idInspection, languageCode));
	    }
	}
}