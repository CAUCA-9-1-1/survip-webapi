using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/PermissionObject")]
	public class PermissionObjectController : BaseSecuredController
	{	
		private readonly PermissionObjectService Service;

		public PermissionObjectController(PermissionObjectService service)
		{
			Service = service;
		}

		[HttpGet]
		[ProducesResponseType(401)]
		[ProducesResponseType(200)]
		public ActionResult Get()
		{
			var result = Service.GetList();

			return Ok(result);
		}
    }
}