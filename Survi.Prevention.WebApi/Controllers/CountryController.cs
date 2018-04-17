using System;
using System.Collections.Generic;
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
	}
}