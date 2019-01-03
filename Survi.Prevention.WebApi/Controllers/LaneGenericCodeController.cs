using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/LaneGenericCode")]
    public class LaneGenericCodeController : BaseSecuredController
    {
        private readonly LaneGenericCodeService service;

        public LaneGenericCodeController(LaneGenericCodeService service)
	    {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public ActionResult Get()
        {
            var result = service.GetList();

            return Ok(result);
        }

	    [HttpPost, Route("Import")]
	    public ActionResult ImportLaneGenericCodes([FromBody] List<ApiClient.DataTransferObjects.LaneGenericCode> importedLaneGenericCodes)
	    {
		    return Ok(service.ImportLaneGenericCodes(importedLaneGenericCodes));
	    }
    }
}
