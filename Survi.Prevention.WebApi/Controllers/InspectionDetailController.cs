using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection")]
	public class InspectionDetailController : BaseSecuredController
	{
		private readonly InspectionDetailService service;

		public InspectionDetailController(InspectionDetailService service)
		{
			this.service = service;
		}

		[HttpGet, Route("{idInspection:Guid}/detail")]
		public ActionResult GetDetailForWeb(Guid idInspection, [FromHeader]string languageCode)
		{
			var form = service.GetDetailForWeb(idInspection, languageCode);
			if (form == null)
				return NotFound();
			return Ok(form);
		}

		[HttpPost, Route("building/{idBuilding:Guid}/idLaneIntersection/{idLane:Guid?}")]	
		public ActionResult SaveIntersection(Guid idBuilding, Guid? idLane)
		{			
			if (service.TryToChangeIntersection(idBuilding, idLane))
				return NoContent();
			return BadRequest("Unknown building.");			
		}

		[HttpPost, Route("buildingdetail/{idBuildingDetail:Guid}/idPicture/{idPicture:Guid?}")]
		public ActionResult SavePicture(Guid idBuildingDetail, Guid? idPicture)
		{
			if (service.TryToChangeIdPicture(idBuildingDetail, idPicture))
				return NoContent();
			return BadRequest("Unknown building detail.");			
		}
	}
}