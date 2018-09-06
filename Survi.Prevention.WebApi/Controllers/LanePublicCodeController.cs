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
    }
}
