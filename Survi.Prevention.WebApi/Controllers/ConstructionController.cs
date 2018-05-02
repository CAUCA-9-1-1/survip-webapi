using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/construction")]
	public class ConstructionController : BaseSecuredController
	{
		private readonly ConstructionService service;

		protected ConstructionController(ConstructionService service)
		{
			this.service = service;
		}

		public ActionResult GetBuildingSidingTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetBuildingSidingTypes(languageCode));
		}

		public ActionResult GetBuildingTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetBuildingTypes(languageCode));
		}

		public ActionResult GetConstructionFireResistanceTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetConstructionFireResistanceTypes(languageCode));
		}

		public ActionResult GetConstructionTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetConstructionTypes(languageCode));
		}

		public ActionResult GetRoofMaterialTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetRoofMaterialTypes(languageCode));
		}

		public ActionResult GetRoofTypes([FromHeader] string languageCode)
		{
			return Ok(service.GetRoofTypes(languageCode));
		}
	}
}