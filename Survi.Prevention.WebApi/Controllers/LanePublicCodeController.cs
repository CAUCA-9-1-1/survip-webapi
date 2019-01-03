using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/LanePublicCode")]
    public class LanePublicCodeController : BaseSecuredController
    {
        private readonly LanePublicCodeService service;

        public LanePublicCodeController(LanePublicCodeService service)
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
	    public ActionResult ImportLanePublicCodes([FromBody] List<ApiClient.DataTransferObjects.LanePublicCode> importedLanePublicCodes)
	    {
		    return Ok(service.ImportLanePublicCodes(importedLanePublicCodes));
	    }
    }
}
