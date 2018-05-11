using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/AlarmPanelType")]
	public class AlarmPanelTypeController : BaseSecuredController
	{
		private readonly AlarmPanelTypeService service;

		public AlarmPanelTypeController(AlarmPanelTypeService service)
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