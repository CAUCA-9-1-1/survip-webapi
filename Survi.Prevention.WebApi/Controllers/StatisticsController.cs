using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.DataTransfertObjects;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/Statistics")]
    public class StatisticsController : Controller
    {
        private readonly StatisticsService service;

        public StatisticsController(StatisticsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult GetStatistics()
        {
            return Ok(service.GetStatistics());
        }
    }
}