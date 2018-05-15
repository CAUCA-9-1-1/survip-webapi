using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
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

        [HttpPost, Route("{id:Guid}/approve")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult ApproveInspection(Guid id)
        {
            return Ok(service.SetVisitStatus(InspectionVisitStatus.Approved, id));
        }

        [HttpPost, Route("{id:Guid}/refuse")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult RefusedInspection(Guid id)
        {
            return Ok(service.SetVisitStatus(InspectionVisitStatus.Refused, id));
        }

        [HttpPost, Route("{id:Guid}/cancel")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult CancelInspection(Guid id)
        {
            service.SetVisitStatus(InspectionVisitStatus.Canceled, id);
            service.Remove(id);

            return Ok(true);
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

        [HttpGet, Route("ForApprovalInspection")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetForApprovalInspection([FromHeader]string languageCode)
        {
            return Ok(service.GetForApprovalInspection(languageCode));
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