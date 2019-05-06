using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KubernetesController : ControllerBase
    {
        private readonly WebuserService service;

        public KubernetesController(WebuserService service)
        {
            this.service = service;
        }

        [HttpGet, Route("/Healthz"), AllowAnonymous]
        public ActionResult GetHealthz()
        {
            try
            {

                if (service.GetList().Any())
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}