using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/construction")]
	public class ConstructionController : BaseSecuredController
	{
		private readonly ConstructionService service;

		public ConstructionController(ConstructionService service)
		{
			this.service = service;
		}

		[HttpGet, Route("SidingTypes")]
		public ActionResult GetBuildingSidingTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetBuildingSidingTypes(languageCode));
		}

		[HttpGet, Route("BuildingTypes")]
		public ActionResult GetBuildingTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetBuildingTypes(languageCode));
		}

		[HttpGet, Route("FireResistanceTypes")]
		public ActionResult GetConstructionFireResistanceTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetConstructionFireResistanceTypes(languageCode));
		}

		[HttpGet, Route("ConstructionTypes")]
		public ActionResult GetConstructionTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetConstructionTypes(languageCode));
		}

		[HttpGet, Route("RoofMaterialTypes")]
		public ActionResult GetRoofMaterialTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetRoofMaterialTypes(languageCode));
		}

		[HttpGet, Route("RoofTypes")]
		public ActionResult GetRoofTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetRoofTypes(languageCode));
		}
	}
}