using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.ServiceLayer.SecurityManagement;
using System;
using System.Linq;

namespace Survi.Prevention.WebApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class KubernetesController : ControllerBase
    {
        private readonly UserService service;

        public KubernetesController(UserService service)
        {
            this.service = service;
        }

        [HttpGet, Route("/Healthz"), AllowAnonymous]
        public ActionResult GetHealthz()
        {
            try
            {

                if (service.GetUserName(Guid.Parse("0540e8f7-dc44-4b2f-8e42-5004cca3700b")).Any())
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