using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/FireSafetyDepartment")]
	public class FireSafetyDepartmentController : BaseCrudController<FireSafetyDepartmentService, FireSafetyDepartment>
	{
		public FireSafetyDepartmentController(FireSafetyDepartmentService service) : base(service)
		{
		}
	}
}