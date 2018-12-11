using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/GeneralConfiguration")]
    public class GeneralConfigurationController : BaseSecuredController
    {
        private readonly GeneralConfigurationService service;

        public GeneralConfigurationController(GeneralConfigurationService service)
        {
            this.service = service;
        }

        [HttpGet, Route("configuration")]
        public ActionResult GetGeneralConfiguration()
        {
            return Ok(service.GetGeneralConfiguration());
        }
    }
}
