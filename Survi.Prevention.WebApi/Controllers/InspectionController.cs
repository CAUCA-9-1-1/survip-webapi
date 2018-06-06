using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json"), Authorize]
	public class BuildingForDashboardController : ODataController
	{
		protected Guid CurrentUserId => Guid.Parse(User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid)?.Value);
		protected string CurrentUserName => User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

		private readonly InspectionService service;

		public BuildingForDashboardController(InspectionService service)
		{
			this.service = service;
		}

		[EnableQuery(AllowedQueryOptions = Microsoft.AspNet.OData.Query.AllowedQueryOptions.All), AllowAnonymous]
		//[ProducesResponseType(typeof(IQueryable<BuildingForDashboard>), 200)]
		public IQueryable<BuildingForDashboard> Get([FromHeader]string languageCode)
		{
			return service.GetBuildingWithoutInspectionQueryable(languageCode);
		}
	}

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
            return Ok(service.SetStatus(InspectionStatus.Approved, id));
        }

        [HttpPost, Route("{id:Guid}/refuse")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult RefusedInspection(Guid id)
        {
            return Ok(service.SetStatus(InspectionStatus.Refused, id));
        }

        [HttpPost, Route("{id:Guid}/cancel")]
        [ProducesResponseType(typeof(bool), 200)]
        public ActionResult CancelInspection(Guid id)
        {
            service.SetStatus(InspectionStatus.Canceled, id);
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
        public ActionResult GetToDoInspection([FromHeader]string languageCode, [FromHeader]string queryLoadOptions)
        {
            var result = new LimitedItemList<InspectionForDashboard>
            {
                Data = service.GetToDoInspection(languageCode, queryLoadOptions),
                TotalCount = service.GetToDoInspectionTotal()
            };

            return Ok(result);
        }

        [HttpGet, Route("ForApprovalInspection")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetForApprovalInspection([FromHeader]string languageCode, [FromHeader]string queryLoadOptions)
        {
            var result = new LimitedItemList<InspectionForDashboard>
            {
                Data = service.GetForApprovalInspection(languageCode, queryLoadOptions),
                TotalCount = service.GetForApprovalInspectionTotal()
            };

            return Ok(result);
        }

        [HttpGet, Route("BuildingWithHistory")]
        [ProducesResponseType(typeof(List<InspectionForDashboard>), 200)]
        public ActionResult GetBuildingWithHistory([FromHeader]string languageCode, [FromHeader]string queryLoadOptions)
        {
            var result = new LimitedItemList<InspectionForDashboard>
            {
                Data = service.GetBuildingWithHistory(languageCode, queryLoadOptions),
                TotalCount = service.GetBuildingWithHistoryTotal()
            };

            return Ok(result);
        }

        [HttpGet, Route("BuildingWithoutInspection")]
        [ProducesResponseType(typeof(LimitedItemList<InspectionForDashboard>), 200)]
        public ActionResult GetBuildingWithoutInspection([FromHeader]string languageCode, [FromHeader]string queryLoadOptions)
        {
            var result = new LimitedItemList<InspectionForDashboard>
            {
                Data = new List<InspectionForDashboard>(), // service.GetBuildingWithoutInspection(languageCode, queryLoadOptions),
                TotalCount = service.GetBuildingWithoutInspectionTotal()
            };

            return Ok(result);
        }

		[HttpPost, Route("StartInspection")]
		public ActionResult StartInspection([FromBody] Guid idInspection)
		{
			if(service.StartInspection(idInspection, CurrentUserId))
				return NoContent();
			else
				return BadRequest("Error during the starting process of the inspection");
		}

		[HttpPost, Route("CompleteInspection")]
		public ActionResult CompleteInspection([FromBody] Guid idInspection)
		{
			if(service.CompleteInspection(idInspection, CurrentUserId))
				return NoContent();
			else
				return BadRequest("Error during the starting process of the inspection");
		}

		[HttpPost, Route("RefuseInspectionVisit")]
		public ActionResult RefuseInspectionVisit([FromBody] InspectionVisit inspectionVisit)
		{
			if(service.RefuseInspectionVisit(inspectionVisit, CurrentUserId))
				return NoContent();
			else
				return BadRequest("Error during the starting process of the inspection");
		}
    }
}