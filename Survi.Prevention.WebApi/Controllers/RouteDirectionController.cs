using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.WebApi.Localization.Base;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/RouteDirection")]
	public class RouteDirectionController : Controller
	{
		[HttpGet]
		public ActionResult GetList([FromHeader]string languageCode)
		{
			return Ok(typeof(CourseLaneDirection).ToList(languageCode));
		}
	}
}