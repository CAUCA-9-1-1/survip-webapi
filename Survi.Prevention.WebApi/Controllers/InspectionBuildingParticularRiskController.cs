using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/particularrisk")]
	public class InspectionBuildingParticularRiskController : BaseSecuredController
	{
		protected InspectionBuildingParticularRiskService Service;

		public InspectionBuildingParticularRiskController(InspectionBuildingParticularRiskService service)
		{
			Service = service;
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/foundation"), HttpGet]
		public ActionResult GetFoundation(Guid idBuilding)
		{
			return Ok(Service.Get<InspectionBuildingFoundationParticularRisk>(idBuilding, CurrentUserId));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/floor"), HttpGet]
		public ActionResult GetFloor(Guid idBuilding)
		{
			return Ok(Service.Get<InspectionBuildingFloorParticularRisk>(idBuilding, CurrentUserId));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/wall"), HttpGet]
		public ActionResult GetWall(Guid idBuilding)
		{
			return Ok(Service.Get<InspectionBuildingWallParticularRisk>(idBuilding, CurrentUserId));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/roof"), HttpGet]
		public ActionResult GetRoof(Guid idBuilding)
		{
			return Ok(Service.Get<InspectionBuildingRoofParticularRisk>(idBuilding, CurrentUserId));
		}

		[HttpPost, Route("foundation"),ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostFoundation([FromBody] InspectionBuildingFoundationParticularRisk entity) => Post(entity);	

		[HttpPost, Route("floor"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostFloor([FromBody] InspectionBuildingFloorParticularRisk entity) => Post(entity);

		[HttpPost, Route("wall"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostWall([FromBody] InspectionBuildingWallParticularRisk entity) => Post(entity);

		[HttpPost, Route("roof"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostRoof([FromBody] InspectionBuildingRoofParticularRisk entity) => Post(entity);

		[HttpDelete, Route("floor/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteFloor(Guid id) => Delete<InspectionBuildingFloorParticularRisk>(id);

		[HttpDelete, Route("wall/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteWall(Guid id) => Delete<InspectionBuildingWallParticularRisk>(id);

		[HttpDelete, Route("roof/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteRoof(Guid id) => Delete<InspectionBuildingRoofParticularRisk>(id);

		[HttpDelete, Route("foundation/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteFoundation(Guid id) => Delete<InspectionBuildingFoundationParticularRisk>(id);

		private ActionResult Post<T>(T entity) where T : InspectionBuildingParticularRisk
		{
			if (Service.AddOrUpdate(entity, CurrentUserId) != Guid.Empty)
				return Ok(new { id = entity.Id });
			return BadRequest();
		}

		private ActionResult Delete<T>(Guid id) where T : InspectionBuildingParticularRisk
		{
			if (Service.Remove<T>(id, CurrentUserId))
				return NoContent();
			return BadRequest();
		}
	}
}