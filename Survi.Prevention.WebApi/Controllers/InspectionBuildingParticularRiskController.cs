using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
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
			return Ok(Service.Get<FoundationParticularRisk>(idBuilding));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/floor"), HttpGet]
		public ActionResult GetFloor(Guid idBuilding)
		{
			return Ok(Service.Get<FloorParticularRisk>(idBuilding));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/wall"), HttpGet]
		public ActionResult GetWall(Guid idBuilding)
		{
			return Ok(Service.Get<WallParticularRisk>(idBuilding));
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/particularrisk/roof"), HttpGet]
		public ActionResult GetRoof(Guid idBuilding)
		{
			return Ok(Service.Get<RoofParticularRisk>(idBuilding));
		}

		[HttpPost, Route("foundation"),ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostFoundation([FromBody] FoundationParticularRisk entity) => Post(entity);	

		[HttpPost, Route("floor"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostFloor([FromBody] FloorParticularRisk entity) => Post(entity);

		[HttpPost, Route("wall"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostWall([FromBody] WallParticularRisk entity) => Post(entity);

		[HttpPost, Route("roof"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult PostRoof([FromBody] RoofParticularRisk entity) => Post(entity);

		[HttpDelete, Route("floor/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteFloor(Guid id) => Delete<FloorParticularRisk>(id);

		[HttpDelete, Route("wall/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteWall(Guid id) => Delete<WallParticularRisk>(id);

		[HttpDelete, Route("roof/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteRoof(Guid id) => Delete<RoofParticularRisk>(id);

		[HttpDelete, Route("foundation/{id:Guid}"), ProducesResponseType(401), ProducesResponseType(200)]
		public virtual ActionResult DeleteFoundation(Guid id) => Delete<FoundationParticularRisk>(id);

		private ActionResult Post<T>(T entity) where T : BuildingParticularRisk
		{
			if (Service.AddOrUpdate(entity) != Guid.Empty)
				return Ok(new { id = entity.Id });
			return BadRequest();
		}

		private ActionResult Delete<T>(Guid id) where T : BuildingParticularRisk
		{
			if (Service.Remove<T>(id))
				return NoContent();
			return BadRequest();
		}
	}
}