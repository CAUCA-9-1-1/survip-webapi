using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
		public ActionResult GetList([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetList(languageCode));
		}

        [HttpPost, Route("import"), AllowAnonymous]
        public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.AlarmPanelType> importedEntities)
        {
            return Ok(service.Import(importedEntities));
        }
    }
}