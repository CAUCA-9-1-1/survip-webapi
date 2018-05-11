using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/SprinklerType")]
	public class SprinklerTypeController : BaseSecuredController
	{
		private readonly SprinklerTypeService service;

		public SprinklerTypeController(SprinklerTypeService service)
		{
			this.service = service;
		}

		[HttpGet]
		public ActionResult GetList([FromHeader]string languageCode)
		{
			return Ok(service.GetList(languageCode));
		}
	}
}