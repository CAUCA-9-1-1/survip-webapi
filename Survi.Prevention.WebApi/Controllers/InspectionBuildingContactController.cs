using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/contact")]
	public class InspectionBuildingContactController : BaseCrudController<InspectionBuildingContactService, InspectionBuildingContact>
	{
		public InspectionBuildingContactController(InspectionBuildingContactService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/contactlist"), HttpGet]
		public ActionResult GetList(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetList(idBuilding));
		}
		
		[Route("/api/inspection/building/{idBuilding:Guid}/contact"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader] string languageCode)
		{
			return Ok(Service.GetListLocalized(idBuilding, languageCode));
		}
	}
}