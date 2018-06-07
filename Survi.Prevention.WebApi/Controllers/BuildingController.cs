using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using System;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Building")]
	public class BuildingController : BaseCrudController<BuildingService, Building>
	{
		public BuildingController(BuildingService service) : base(service)
		{
		}

		[HttpGet, Route("Active")]
		public ActionResult GetListActive([FromHeader] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode));
		}

        [HttpGet, Route("child/{idParentBuilding:Guid}")]
        public ActionResult GetChildList(Guid idParentBuilding, [FromHeader] string languageCode)
        {
            return Ok(Service.GetChildList(idParentBuilding, languageCode));
        }
    }
}