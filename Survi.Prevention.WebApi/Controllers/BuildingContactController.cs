using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/contact")]
	public class BuildingContactController : BaseCrudController<BuildingContactService, BuildingContact>
	{
		public BuildingContactController(BuildingContactService service) : base(service)
		{
		}

		[HttpGet, Route("/api/building/{idBuilding:Guid}/contact")]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingContactList(idBuilding));
		}
	}
}