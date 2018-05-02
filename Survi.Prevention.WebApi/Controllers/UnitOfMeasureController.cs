using Microsoft.AspNetCore.Mvc;
using Survi.Prevention.Models;
using Survi.Prevention.ServiceLayer.Services;

namespace Survi.Prevention.WebApi.Controllers
{
    [Route("api/UnitOfMeasure")]
    public class UnitOfMeasureController : BaseCrudController<UnitOfMeasureService, UnitOfMeasure>
    {
	    public UnitOfMeasureController(UnitOfMeasureService service) : base(service)
	    {
	    }

	    [HttpGet, Route("rate")]
	    public ActionResult GetRateMeasuringUnits([FromHeader]string languageCode)
	    {
		    return Ok(Service.GetListLocalized<RateUnitOfMeasure>(languageCode));
	    }

	    [HttpGet, Route("diameter")]
	    public ActionResult GetDiameterMeasuringUnits([FromHeader]string languageCode)
	    {
		    return Ok(Service.GetListLocalized<DiameterUnitOfMeasure>(languageCode));
		}

	    [HttpGet, Route("pressure")]
	    public ActionResult GetPressureMeasuringUnits([FromHeader]string languageCode)
	    {
		    return Ok(Service.GetListLocalized<PressureUnitOfMeasure>(languageCode));
		}

	    [HttpGet, Route("capacity")]
	    public ActionResult GetCapacityMeasuringUnits([FromHeader]string languageCode)
	    {
		    return Ok(Service.GetListLocalized<CapacityUnitOfMeasure>(languageCode));
		}

	    [HttpGet, Route("dimension")]
	    public ActionResult GetDimensionMeasuringUnits([FromHeader]string languageCode)
	    {
		    return Ok(Service.GetListLocalized<DimensionUnitOfMeasure>(languageCode));
		}
	}
}
