using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Inspection")]
	public class InspectionController : BaseSecuredController
	{
		private readonly InspectionService service;

		public InspectionController(InspectionService service)
		{
			this.service = service;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<BatchForList>), 200)]
		public ActionResult GetUserInspections([FromHeader]string languageCode)
		{
			return Ok(service.GetGroupedUserInspections(languageCode, CurrentUserId));
		}

        [HttpGet, Route("ToDoInspection")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetToDoInspection([FromHeader]string languageCode)
        {
            return Ok(service.GetToDoInspection(languageCode));
        }

        [HttpGet, Route("ApprovedInspection")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetApprovedInspection([FromHeader]string languageCode)
        {
            return Ok(service.GetApprovedInspection(languageCode));
        }

        [HttpGet, Route("BuildingWithHistory")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetBuildingWithHistory([FromHeader]string languageCode)
        {
            return Ok(service.GetBuildingWithHistory(languageCode));
        }

        [HttpGet, Route("BuildingWithoutInspection")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetBuildingWithoutInspection([FromHeader]string languageCode)
        {
            return Ok(service.GetBuildingWithoutInspection(languageCode));
        }
    }
}