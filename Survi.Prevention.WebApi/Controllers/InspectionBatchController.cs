using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Batch")]
    public class InspectionBatchController : BaseCrudController<InspectionBatchService, Batch>
    {
	    public InspectionBatchController(InspectionBatchService service) : base(service)
	    {
	    }
    }
}
