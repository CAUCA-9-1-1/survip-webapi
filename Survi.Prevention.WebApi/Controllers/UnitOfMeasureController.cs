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
	    public ActionResult GetRateMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Rate));
	    }

	    [HttpGet, Route("diameter")]
	    public ActionResult GetDiameterMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Diameter));
		}

	    [HttpGet, Route("pressure")]
	    public ActionResult GetPressureMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Pressure));
		}

	    [HttpGet, Route("capacity")]
	    public ActionResult GetCapacityMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Capacity));
		}

	    [HttpGet, Route("dimension")]
	    public ActionResult GetDimensionMeasuringUnits([FromHeader(Name = "Language-Code")]string languageCode)
	    {
		    return Ok(Service.GetListLocalized(languageCode, MeasureType.Dimension));
		}
	}
}
