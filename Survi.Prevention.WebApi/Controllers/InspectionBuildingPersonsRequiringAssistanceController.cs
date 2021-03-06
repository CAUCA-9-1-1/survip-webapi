﻿using System;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.InspectionManagement.BuildingCopy;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/inspection/building/pnaps")]
	public class InspectionBuildingPersonsRequiringAssistanceController : BaseCrudController<InspectionBuildingPersonRequiringAssistanceService, InspectionBuildingPersonRequiringAssistance>
	{
		public InspectionBuildingPersonsRequiringAssistanceController(InspectionBuildingPersonRequiringAssistanceService service) : base(service)
		{
		}

		[Route("/api/inspection/building/{idBuilding:Guid}/pnapslist"), HttpGet]
		public ActionResult GetList(Guid idBuilding, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetList(idBuilding));
		}
		
		[Route("/api/inspection/building/{idBuilding:Guid}/pnaps"), HttpGet]
		public ActionResult GetListForDisplay(Guid idBuilding, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetListLocalized(languageCode, idBuilding));
		}
	}
}