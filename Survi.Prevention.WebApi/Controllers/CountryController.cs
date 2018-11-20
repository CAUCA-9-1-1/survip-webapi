using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Country")]
	public class CountryController 
	    : BaseCrudControllerWithImportation<CountryService, Country, ApiClient.DataTransferObjects.Country>
	{		
		public CountryController(CountryService service) : base(service)
		{
		}

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }		
    }
}