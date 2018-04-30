﻿using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireHydrants;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/FireHydrantType")]
    public class FireHydrantTypeController : BaseCrudController<FireHydrantTypeService, FireHydrantType>
    {
	    public FireHydrantTypeController(FireHydrantTypeService service) : base(service)
	    {
	    }
    }
}