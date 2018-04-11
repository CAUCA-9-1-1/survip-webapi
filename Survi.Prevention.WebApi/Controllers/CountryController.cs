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
    [Route("api/Country")]
    public class CountryController : Controller
    {
        private readonly CountryService service;

        public CountryController([FromServices] CountryService service, IConfiguration configuration)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(Country), 200)]
        public Country Get(Guid id)
        {
            return service.Get(id);
        }

        [HttpGet]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(List<Country>), 200)]
        public List<Country> Get()
        {
            return service.GetList();
        }

        [HttpPost]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public void Post([FromBody] Country country)
        {
            service.AddOrUpdate(country);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        public void Delete(Guid id)
        {
            service.Remove(id);
        }
    }
}