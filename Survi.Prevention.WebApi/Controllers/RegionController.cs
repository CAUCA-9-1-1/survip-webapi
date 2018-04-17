using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Region")]
	public class RegionController : BaseCrudController<RegionService, Region>
	{		
		public RegionController(RegionService service) : base(service)
		{
		}
	}
}