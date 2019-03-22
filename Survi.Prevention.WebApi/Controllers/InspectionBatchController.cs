using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Batch")]
    public class InspectionBatchController : BaseCrudController<InspectionBatchService, Batch>
    {
		private readonly InspectionBuildingService buildingService;

	    public InspectionBatchController(InspectionBatchService service, InspectionBuildingService buildingService) : base(service)
	    {
		    this.buildingService = buildingService;
	    }

	    [HttpGet, Route("{idBatch:Guid}/buildingformanagement")]
	    public ActionResult<BatchInspectionBuilding> GetListForManagement(Guid idBatch, [FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(buildingService.GetBuildingForManagement(idBatch, languageCode));
	    }
	}
}