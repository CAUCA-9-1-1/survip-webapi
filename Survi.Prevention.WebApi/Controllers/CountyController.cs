using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models.FireSafetyDepartments;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/County")]
    public class CountyController : BaseCrudController<CountyService, County>
    {
        public CountyController(CountyService service) : base(service)
        {
        }
    }
}