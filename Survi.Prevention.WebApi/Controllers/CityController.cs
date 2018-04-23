﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/City")]
    public class CityController : BaseCrudController<CityService, City>
    {
        public CityController(CityService service) : base(service)
        {
        }
    }
}