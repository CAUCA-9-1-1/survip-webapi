using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/County")]
    public class CountyController : BaseCrudControllerWithImportation<CountyService, County, ApiClient.DataTransferObjects.County>
    {
        public CountyController(CountyService service) : base(service)
        {
        }

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }
    }
}