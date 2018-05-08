using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/detail")]
    public class InspectionBuildingDetailController : BaseCrudController<BuildingDetailService, BuildingDetail>
    {
	    public InspectionBuildingDetailController(BuildingDetailService service) : base(service)
	    {
	    }

		[Route("/api/inspection/building/{idBuilding:Guid}/detail"), HttpGet]
		public ActionResult GetByBuilding(Guid idBuilding)
		{
			return Ok(Service.GetByIdBuilding(idBuilding));
		}
    }
}
