using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Firestation")]
	public class FirestationController : BaseCrudControllerWithImportation<FirestationService, Firestation, ApiClient.DataTransferObjects.Firestation>
	{
		private readonly WebuserService userService;

		public FirestationController(FirestationService service, WebuserService userService): base(service)
		{
			this.userService = userService;
		}

        private List<Guid> GetDepartmentIds()
        {
            return userService.GetUserFireSafetyDepartments(CurrentUserId);
        }

		[Route("localized"), HttpGet]
		public ActionResult GetLocalizedFirestations()
		{
			return Ok(Service.GetList(this.GetDepartmentIds()));
		}

        [Route("/api/city/{idCity:Guid}/firestations"), HttpGet]
		public ActionResult GetLocalizedFirestations(Guid idCity)
		{
			return Ok(Service.GetListLocalized(idCity));
		}	
	}
}