using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Firestation")]
	public class FirestationController : BaseCrudController<FirestationService, Firestation>
	{
		public FirestationController(FirestationService service) : base(service)
		{
		}
	}
}