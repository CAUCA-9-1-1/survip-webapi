﻿using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/ReportConfigurationTemplate")]
    public class ReportConfigurationTemplateController : BaseCrudController<ReportConfigurationTemplateService, ReportConfigurationTemplate>
    {             
        public ReportConfigurationTemplateController(ReportConfigurationTemplateService service) : base(service)
        {
        }
    }
}
