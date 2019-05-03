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

        public ObjectivesController(ObjectiveService service)
        {
            this.objectiveService = service;
        }

        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(objectiveService.GetList());
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
    }
}