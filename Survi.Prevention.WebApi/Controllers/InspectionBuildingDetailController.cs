using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/detail")]
    public class InspectionBuildingDetailController : BaseCrudController<InspectionBuildingDetailService, InspectionBuildingDetail>
    {
	    public InspectionBuildingDetailController(InspectionBuildingDetailService service) : base(service)
	    {
	    }

		[Route("/api/inspection/building/{idBuilding:Guid}/detail"), HttpGet]
		public ActionResult GetByBuilding(Guid idBuilding)
		{
			return Ok(Service.GetByIdBuilding(idBuilding));
		}

        [Route("/api/inspection/building/{idBuilding:Guid}/detail/picture"), HttpGet]
        public ActionResult<InspectionPictureForWeb> GetPlanByBuilding(Guid idBuilding)
        {
            return Ok(Service.GetPictureByIdBuilding(idBuilding));
        }

        [Route("/api/inspection/building/{idBuilding:Guid}/detail/picture"), HttpPost]
        public ActionResult<InspectionPictureForWeb> SavePlanByBuilding(Guid idBuilding, [FromBody]List<InspectionPictureForWeb> pictures)
        {            
            if (pictures.Count > 0)
                return Ok(Service.SavePictureByIdBuilding(idBuilding, pictures.First()));
            return Ok();
        }
    }
}
