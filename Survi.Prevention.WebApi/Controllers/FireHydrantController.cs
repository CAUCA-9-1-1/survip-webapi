using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrant")]
    public class FireHydrantController : BaseCrudController<FireHydrantService, FireHydrant>
    {
	    public FireHydrantController(FireHydrantService service) : base(service)
	    {
	    }
    }
}
