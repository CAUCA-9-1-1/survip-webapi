using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.Buildings;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using Survi.Prevention.Models.DataTransfertObjects;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Building")]
	public class BuildingController : BaseCrudControllerWithImportation<BuildingService, Building, ApiClient.DataTransferObjects.Building>
	{
		private readonly WebuserService userService;
		private readonly CityService cityService;
        private readonly BuildingDetailService detailService;
	    private readonly BuildingSprinklerService sprinklerService;
	    private readonly BuildingAlarmPanelService alarmService;
	    private readonly BuildingAnomalyService anomalyService;
	    private readonly BuildingParticularRiskService riskService;
	    private readonly BuildingCourseService courseService;
        private readonly BuildingFireHydrantService hydrantService;

        public BuildingController(
		    BuildingService service, 
		    BuildingDetailService detailService, 
            BuildingSprinklerService sprinklerService,
            BuildingAlarmPanelService alarmService,
            BuildingAnomalyService anomalyService,
            BuildingParticularRiskService riskService,
            BuildingFireHydrantService hydrantService,
            BuildingCourseService courseService,
		    CityService cityService, 
		    WebuserService userService) 
		    : base(service)
		{
		    this.sprinklerService = sprinklerService;
		    this.alarmService = alarmService;
		    this.anomalyService = anomalyService;
		    this.riskService = riskService;
			this.cityService = cityService;
			this.userService = userService;
		    this.detailService = detailService;
		    this.courseService = courseService;
		    this.hydrantService = hydrantService;
		}
		
		private List<Guid> GetUserCityIds(Guid idFireSafetyDepartment = new Guid())
		{
			var departmentIds = new List<Guid>();

			if(idFireSafetyDepartment != Guid.Empty)
				departmentIds.Add(idFireSafetyDepartment);
			else
			 departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);

			return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
		}

		[HttpGet, Route("Active")]
		public ActionResult GetListActive([FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode, GetUserCityIds()));
		}

		[HttpGet, Route("Active/{idFireSafetyDepartment:Guid}")]
		public ActionResult GetListActiveForFireSafetyDepartment(Guid idFireSafetyDepartment, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetListActive(languageCode, GetUserCityIds(idFireSafetyDepartment)));
		}
		
        [HttpGet, Route("child/{idParentBuilding:Guid}")]
        public ActionResult GetChildList(Guid idParentBuilding)
        {
            return Ok(Service.GetChildList(idParentBuilding));
        }

		[HttpPost, Route("ForInspectionList")]
		public ActionResult<AvailableBuildingForManagement> GetBuildingForInspectionList([FromBody]List<Guid> buildingIds, [FromHeader(Name = "Language-Code")] string languageCode)
		{
			return Ok(Service.GetForInspectionList(languageCode, buildingIds));
		}

	    [HttpPost, Route("Detail/Import")]
	    public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.BuildingDetail> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(detailService.Import(importedEntities));
	    }

	    [HttpPost, Route("Sprinklers/Import")]
	    public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.BuildingSprinkler> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(sprinklerService.Import(importedEntities));
	    }

	    [HttpPost, Route("AlarmPanel/Import")]
	    public ActionResult Import([FromBody] List<ApiClient.DataTransferObjects.BuildingAlarmPanel> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(alarmService.Import(importedEntities));
	    }

	    [HttpPost, Route("Anomaly/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingAnomaly> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(anomalyService.ImportAnomalies(importedEntities));
	    }

	    [HttpPost, Route("ParticularRisk/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingParticularRisk> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(riskService.ImportRisks(importedEntities));
	    }

	    [HttpPost, Route("Anomaly/Picture/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingAnomalyPicture> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(anomalyService.ImportPictures(importedEntities));
	    }

	    [HttpPost, Route("ParticularRisk/Picture/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingParticularRiskPicture> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
            return Ok(riskService.ImportPictures(importedEntities));
	    }

	    [HttpPost, Route("FireHydrant/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingFireHydrant> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
	        return Ok(hydrantService.Import(importedEntities));
	    }

	    [HttpPost, Route("Course/Import")]
	    public ActionResult<List<ImportationResult>> Import([FromBody] List<ApiClient.DataTransferObjects.BuildingCourse> importedEntities)
	    {
	        if (importedEntities == null)
	            return BadRequest();
	        return Ok(courseService.Import(importedEntities));
	    }
    }
}