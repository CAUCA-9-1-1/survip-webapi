using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/detail")]
    public class BuildingDetailController : BaseCrudController<BuildingDetailService, BuildingDetail>
    {
	    public BuildingDetailController(BuildingDetailService service) : base(service)
	    {
	    }

		[Route("/api/building/{idBuilding:Guid}/detail"), HttpGet]
		public ActionResult GetByBuilding(Guid idBuilding)
		{
			return Ok(Service.GetByIdBuilding(idBuilding));
		}
    }
}
