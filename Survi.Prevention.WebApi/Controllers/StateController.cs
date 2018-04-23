﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/State")]
    public class StateController : BaseCrudController<StateService, State>
    {
        public StateController(StateService service) : base(service)
        {
        }
    }
}