using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/anomaly/picture")]
	public class InspectionBuildingAnomalyPictureController : BaseCrudController<InspectionBuildingAnomalyPictureService, BuildingAnomalyPicture>
	{
		public InspectionBuildingAnomalyPictureController(InspectionBuildingAnomalyPictureService service) : base(service)
		{
		}

		[Route("/api/inspection/building/anomaly/{idBuildingAnomaly:Guid}/picture"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuildingAnomaly)
		{
			return Ok(Service.GetAnomalyPictures(idBuildingAnomaly));
		}
	}
}