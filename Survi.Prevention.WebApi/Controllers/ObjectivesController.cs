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
        private readonly ObjectiveService service;

        public ObjectivesController(ObjectiveService service)
        {
            this.service = service;
        }

        [HttpGet, Route("{idFireSafetyDepartment:Guid}")]
        public ActionResult GetObjectives(Guid idFireSafetyDepartment)
        {
            return Ok(service.GetList(idFireSafetyDepartment));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Objectives entity)
        {
            return Ok(service.Save(entity));
        }

        [HttpDelete, Route("{id:Guid}")]
        public ActionResult Delete(Guid id)
        {
            return Ok(service.Remove(id));
        }
    }
}