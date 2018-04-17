using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/State")]
    public class StateController : BaseSecuredController
    {
        private readonly StateService service;

        public StateController([FromServices] StateService service, IConfiguration configuration)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(State), 200)]
        public ActionResult Get(Guid id)
        {
            var state = service.Get(id);
            return Ok(state);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<State>), 200)]
        public ActionResult Get()
        {
            var result = service.GetList();

            if(result.Count > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult Post([FromBody] State state)
        {
            if (service.AddOrUpdate(state))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ProducesResponseType(200)]
        public ActionResult Delete(Guid id)
        {
            if (service.Remove(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}