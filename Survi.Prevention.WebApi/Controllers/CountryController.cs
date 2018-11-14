using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Country")]
	public class CountryController : BaseCrudController<CountryService, Country>
	{		
		public CountryController(CountryService service) : base(service)
		{
		}

        [HttpGet, Route("localized")]
        public ActionResult GetListLocalized([FromHeader(Name = "Language-Code")] string languageCode)
        {
            return Ok(Service.GetListLocalized(languageCode));
        }

		[HttpGet, Route("import")]
		public ActionResult ImportCountry([FromBody] ApiClient.DataTransferObjects.Country importedCountry)
		{
			return Ok(Service.ImportCountry(importedCountry));
		}
    }
}