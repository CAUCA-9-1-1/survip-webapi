using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/OperatorType")]
    public class OperatorTypeController : BaseCrudController<OperatorTypeService, OperatorType>
    {
	    public OperatorTypeController(OperatorTypeService service) : base(service)
	    {
	    }
    }
}
