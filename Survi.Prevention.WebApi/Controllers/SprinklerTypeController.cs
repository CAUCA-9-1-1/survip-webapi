using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
		public ActionResult GetList([FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetList(languageCode));
		}

        [HttpPost, Route("import"), AllowAnonymous]
        public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.SprinklerType> importedEntities)
        {
            if (importedEntities == null)
                return BadRequest();
            return Ok(service.Import(importedEntities));
        }
    }
}