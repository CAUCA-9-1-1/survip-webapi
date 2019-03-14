using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ApiClient.DataTransferObjects;
using Survi.Prevention.ServiceLayer.Services;
using BuildingContact = Survi.Prevention.Models.Buildings.BuildingContact;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/building/contact")]
	public class BuildingContactController : BaseCrudControllerWithImportation<BuildingContactService, BuildingContact, ApiClient.DataTransferObjects.BuildingContact>
	{
        private readonly BuildingService BuildingService;
        public BuildingContactController(BuildingContactService service, BuildingService buildingService) : base(service)
        {
            BuildingService = buildingService;
        }

        [HttpGet, Route("/api/building/{idBuilding:Guid}/contact")]
		public ActionResult GetList(Guid idBuilding)
		{
			return Ok(Service.GetBuildingContactList(idBuilding));
		}

        [HttpPost, Route("Export"), AllowAnonymous]
        public ActionResult Export([FromBody] List<string> idBuildings)
        {
            List<string> completeIdBuildList = BuildingService.GetCompleteBuildingIdListFromParentId(idBuildings);
            return Ok(Service.Export(completeIdBuildList));
        }

        [HttpPost, Route("TransferedToCad"), AllowAnonymous]
        public ActionResult SetBuildingAsTransferedToCad([FromBody] List<string> ids)
        {
            return Ok(Service.SetEntityAsTransferedToCad(ids));
        }

        [HttpPost, Route("TransferedToCad/CorrespondenceIds"), AllowAnonymous]
        public ActionResult SetBuildingAsTransferedToCad([FromBody] List<TransferIdCorrespondence> correspondenceIds)
        {
            return Ok(Service.UpdateExternalIds(correspondenceIds));
        }
    }
}