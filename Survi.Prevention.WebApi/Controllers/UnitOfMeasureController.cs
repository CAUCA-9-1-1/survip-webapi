using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/UnitOfMeasure")]
    public class UnitOfMeasureController : BaseCrudController<UnitOfMeasureService, UnitOfMeasure>
    {
	    public UnitOfMeasureController(UnitOfMeasureService service) : base(service)
	    {
	    }
    }
}
