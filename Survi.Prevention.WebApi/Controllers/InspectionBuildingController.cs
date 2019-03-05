﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{	
	[Route("api/inspection")]
	public class InspectionBuildingController : BaseSecuredController
	{
		private readonly InspectionBuildingService service;
        private readonly BuildingService BuildingService;

        public InspectionBuildingController(InspectionBuildingService service, BuildingService buildingService) : base(service)
        {
            this.service = service;
            BuildingService = buildingService;
        }

        [HttpGet, Route("{idInspection:Guid}/building")]
		public ActionResult GetList(Guid idInspection, [FromHeader(Name = "Language-Code")]string languageCode)
		{
			return Ok(service.GetBuildings(idInspection, languageCode));
		}

        [HttpGet, Route("{idInspection:Guid}/buildingresume")]
        public ActionResult GetResumeList(Guid idInspection)
        {
            return Ok(service.GetBuildingsResume(idInspection));
        }

        [HttpPost, Route("Building/Export"), AllowAnonymous]
        public ActionResult GetInspectionForExport()
        {
            return Ok(service.GetInspectionForExport());
        }

        [HttpPost, Route("Building/TransferedToCad"), AllowAnonymous]
        public ActionResult SetBuildingAsTransferedToCad([FromBody] List<string> ids)
        {
            List<string> completeIdBuildList = BuildingService.AddBuildingChildToParentList(ids);
            return Ok(service.SetBuildingAsTransferedToCad(completeIdBuildList));
        }
    }
}