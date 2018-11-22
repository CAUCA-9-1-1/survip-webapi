using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/AlarmPanelType")]
	public class AlarmPanelTypeController 
	    : BaseCrudControllerWithImportation<AlarmPanelTypeService, AlarmPanelType, ApiClient.DataTransferObjects.AlarmPanelType>
    {
		public AlarmPanelTypeController(AlarmPanelTypeService service) : base(service)
		{
		}

		[HttpGet]
		public ActionResult GetList([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(Service.GetList(languageCode));
		}
	}
}