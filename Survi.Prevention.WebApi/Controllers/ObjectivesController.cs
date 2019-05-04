using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.DataLayer;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Objectives")]
    public class ObjectivesController : BaseSecuredController
    {
        private readonly ObjectiveService objectiveService;
        private readonly WebuserService userService;
        private readonly CityService cityService;

        public ObjectivesController(ObjectiveService service, WebuserService userService, CityService cityService)
        {
            this.objectiveService = service;
            this.userService = userService;
            this.cityService = cityService;
        }

        [HttpGet, Route("Risk/{isHighRisk:bool}")]
        public ActionResult GetList(bool isHighRisk)
        {
            return Ok(objectiveService.GetList(isHighRisk));
        }

        [HttpGet, Route("Department/{idFireSafetyDepartment:Guid}")]
        public ActionResult GetListForFireSafetyDepartment(Guid idFireSafetyDepartment = new Guid())
        {
            return Ok(objectiveService.GetList(idFireSafetyDepartment));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Objectives entity)
        {
            return Ok(objectiveService.Save(entity));
        }

        [HttpDelete, Route("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            return Ok(objectiveService.Remove(id));
        }

        [HttpGet, Route("Statistics/Status")]

        [HttpGet, Route("Statistics/Status/{idFireSafetyDepartment:Guid}")]
        public ActionResult GetStatusStatistics(Guid idFireSafetyDepartment = new Guid())
        {
            return Ok(objectiveService.GetStatusStatistics(GetUserCityIds(idFireSafetyDepartment)));
        }

        [HttpGet, Route("Statistics/Inspections")]

        [HttpGet, Route("Statistics/Inspections/{idFireSafetyDepartment:Guid}")]
        public ActionResult GetInspectionsStatistics(Guid idFireSafetyDepartment = new Guid())
        {
            return Ok(objectiveService.GetInspectionsStatistics(GetUserCityIds(idFireSafetyDepartment)));
        }

        private List<Guid> GetUserCityIds(Guid idFireSafetyDepartment = new Guid())
        {
            var departmentIds = new List<Guid>();

            if (idFireSafetyDepartment != Guid.Empty)
                departmentIds.Add(idFireSafetyDepartment);
            else
                departmentIds = userService.GetUserFireSafetyDepartments(CurrentUserId);

            return cityService.GetCityIdsByFireSafetyDepartments(departmentIds);
        }
    }
}