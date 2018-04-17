﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Country")]
	public class CountryController : BaseSecuredController
	{
		private readonly CountryService service;

		public CountryController([FromServices] CountryService service)
		{
			this.service = service;
		}

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Country), 200)]
        public ActionResult Get(Guid id)
        {
            var country = service.Get(id);
            return Ok(country);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Country>), 200)]
        public ActionResult Get()
        {
            var result = service.GetList();

			if (result.Count > 0)
			{
				return Ok(result);
			}

			return BadRequest();
		}

        [HttpPost]
        [ProducesResponseType(200)]
        public ActionResult Post([FromBody] Country country)
        {
            if (service.AddOrUpdate(country))
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