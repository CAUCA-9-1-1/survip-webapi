using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/SprinklerType")]
	public class SprinklerTypeController 
	    : BaseCrudControllerWithImportation<SprinklerTypeService, SprinklerType, ApiClient.DataTransferObjects.SprinklerType>
    {
		public SprinklerTypeController(SprinklerTypeService service) : base(service)
		{
		}

		[HttpGet]
		public ActionResult GetList([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetList(languageCode));
		}
	}
}