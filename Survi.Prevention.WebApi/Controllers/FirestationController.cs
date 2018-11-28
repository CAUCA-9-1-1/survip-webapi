using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Firestation")]
	public class FirestationController : BaseCrudControllerWithImportation<FirestationService, Firestation, ApiClient.DataTransferObjects.Firestation>
	{
	    public FirestationController(FirestationService service) : base(service)
	    {
	    }

        [Route("/api/city/{idCity:Guid}/firestations"), HttpGet]
		public ActionResult GetLocalizedFirestations(Guid idCity)
		{
			return Ok(Service.GetListLocalized(idCity));
		}	
	}
}