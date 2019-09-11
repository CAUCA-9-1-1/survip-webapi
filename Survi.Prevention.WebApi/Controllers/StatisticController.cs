using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using Survi.Prevention.ServiceLayer.Services;
using System;
using System.Collections.Generic;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/Statistics")]
    public class StatisticController : BaseSecuredController
    {
        private readonly StatisticService statisticService;
        private readonly UserService userService;
        private readonly CityService cityService;

        public StatisticController(StatisticService service, UserService userService, CityService cityService)
        {
            this.statisticService = service;
            this.userService = userService;
            this.cityService = cityService;
        }

        [HttpGet, Route("Objectives/Risk/{isHighRisk:bool}")]
        public ActionResult GetList(bool isHighRisk)
        {
            return Ok(statisticService.GetObjectiveList(isHighRisk));
        }

        [HttpPost, Route("Objectives")]
        public ActionResult Post([FromBody] Objectives entity)
        {
            return Ok(statisticService.Save(entity));
        }

        [HttpDelete, Route("Objectives/{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            return Ok(statisticService.Remove(id));
        }

        [HttpGet, Route("Visits")]
        public ActionResult GetInspectionsStatistics()
        {
            return Ok(statisticService.GetInspectionVisitStatistics(GetUserCityIds()));
        }

        private List<Guid> GetUserCityIds()
        {
            var departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);
            return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
        }
    }
}